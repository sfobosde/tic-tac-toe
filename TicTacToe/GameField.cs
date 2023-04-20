using System;
using System.Collections.Generic;

namespace TicTacToe
{
	// Игровое поле.
	class GameField
	{
		// Координаты точек начала по горизонтальной и вертикально осям.
		public int horizontalStartPoint;
		public int verticalStartPont;

		// Координаты точек конца по горизонтальной и вертикально осям.
		public int horizontalEndPoint;
		public int verticalEndPont;

		// Размеры поля в пикселях.
		public int width;
		public int height;

		// Размерность поля.
		public int cellCount;

		// Размер стороны одного квадрата.
		public int cellSizeHorizontal;
		public int cellSizeVertical;

		// Количество вряд идущих для победы.
		private int winCount;

		// Клеточки на поле.
		public Cell[,] Cells;

		// Найден победитель.
		public bool HasWinner;

		// Фигура победителя.
		public Figure? WinnerFigure;

		public List<Cell> winnerCells;

		// Конструктор по умолчанию.
		public GameField(int horizontalStartPoint, int verticalStartPont, int width, int height, int cellCount)
		{
			// Координаты точек по горизонтальной и вертикально осям.
			this.horizontalStartPoint = horizontalStartPoint;
			this.verticalStartPont = verticalStartPont;

			horizontalEndPoint = horizontalStartPoint + width;
			verticalEndPont = verticalStartPont + height;

			// Размеры поля в пикселях.
			this.width = width;
			this.height = height;

			// Размерность поля.
			this.cellCount = cellCount;

			// Размер стороны одного квадрата.
			cellSizeHorizontal = width / cellCount;
			cellSizeVertical = height / cellCount;

			Cells = new Cell[cellCount, cellCount];

			winCount = 5;

			HasWinner = false;

			WinnerFigure = null;

			// Проинициализируем все ячейки.
			for (int i = 0; i < cellCount; i++)
			{
				for (int j = 0; j < cellCount; j++)
				{
					Cells[i, j] = new Cell(
						horizontalStartPoint + i * cellSizeHorizontal,
						verticalStartPont + j * cellSizeVertical,
						cellSizeHorizontal,
						cellSizeVertical);
				}
			}
		}

		// Проверка, был ли клик по полю.
		public bool IsPointOnField(int x, int y)
		{
			return (x > horizontalStartPoint && x < horizontalEndPoint)
				&& (y > verticalStartPont && y < verticalEndPont);
		}

		// Поиск клетки по координатам.
		public Cell FindCell(int x, int y)
		{
			for (int i = 0; i < cellCount; i++)
			{
				for (int j = 0; j < cellCount; j++)
				{
					// Если попали в клетку.
					if (Cells[i, j].IsHitsToCell(x, y))
					{
						// Если клетка пустая, то возвращаем ее как найденную.
						if (Cells[i, j].IsEmpty)
						{
							return Cells[i, j];
						}
						// Если клетка занята, то выбросим ошибку.
						else
						{
							throw new Exception("Данная клетка занята!");
						}
					}
				}
			}

			// Если до этого момента функция не закончилась, значит клетка не нашлась.
			// Сбрасываем ошибку.
			throw new Exception("Не удалось найти клетку, попробуйте еще раз.");
		}

		// Ищем, есть ли на поле победная комбинация.
		public void MonitorGameState()
		{
			CheckVertical();
			CheckHorizontal();

			CheckDiagonal();
		}

		// Просмотр ячеек по столбцам.
		private void CheckVertical()
		{
			// Фигура, по которой будем проверять.
			Figure? currentFigure;

			// Фигур подряд.
			int inRowCount;

			for (int i = 0; i < cellCount; i++)
			{
				inRowCount = 1;
				winnerCells = new List<Cell>();

				for (int j = 0; j < cellCount - 1; j++)
				{
					// Берем фигуру первой клетки, которую проверяем.
					currentFigure = Cells[i, j].figure;

					// Если текущая фигура совпала со следущющей, то увеличиваем счет.
					if (Cells[i, j + 1].figure != null
						&& currentFigure != null
						&& Cells[i, j + 1].figure == currentFigure)
					{
						inRowCount++;

						winnerCells.Add(Cells[i, j]);

						if (inRowCount == 5)
						{
							HasWinner = true;
							WinnerFigure = currentFigure;

							return;
						}
					}
					else
					{
						inRowCount = 1;
						currentFigure = Cells[i, j + 1].figure;
					}
				}
			}
		}

		// Просмотр ячеек по столбцам.
		private void CheckHorizontal()
		{
			// Фигура, по которой будем проверять.
			Figure? currentFigure;

			// Фигур подряд. 
			int inRowCount;

			for (int i = 0; i < cellCount; i++)
			{
				inRowCount = 1;

				winnerCells = new List<Cell>();

				for (int j = 0; j < cellCount - 1; j++)
				{
					// Берем фигуру первой клетки, которую проверяем.
					currentFigure = Cells[j, i].figure;

					// Если текущая фигура совпала со следущющей по диагонали, то увеличиваем счет.
					if (Cells[j + 1, i].figure != null
						&& currentFigure != null
						&& Cells[j + 1, i].figure == currentFigure)
					{
						inRowCount++;

						winnerCells.Add(Cells[j, i]);

						if (inRowCount == 5)
						{
							HasWinner = true;
							WinnerFigure = currentFigure;

							return;
						}
					}
					else
					{
						inRowCount = 1;
						currentFigure = Cells[j + 1, i].figure;
					}
				}
			}
		}

		// Просмотр ячеек по диагоналям.
		private void CheckDiagonal()
		{
			// Фигура, по которой будем проверять.
			Figure? currentFigure;

			// Фигур подряд. 
			int inRowCount;

			// Проверяем слева сверху направо вниз
			for (int i = 0; i < cellCount - 1; i++)
			{
				for (int j = 0; j < cellCount - 1; j++)
				{
					inRowCount = 1;

					// Берем фигуру первой клетки, которую проверяем.
					currentFigure = Cells[i, j].figure;

					winnerCells = new List<Cell>();

					int k = 1;

					while (
						(k < 5) 
						&& (i + k < cellCount) 
						&& (j + k < cellCount)
						&& Cells[i + k, j + k].figure != null
						&& currentFigure != null
						&& Cells[i + k, j + k].figure == currentFigure)
					{
						inRowCount++;
						k++;

						winnerCells.Add(Cells[i, j]);

						if (inRowCount == 5)
						{
							HasWinner = true;
							WinnerFigure = currentFigure;

							return;
						}
					}
				}
			}

			// Проверяем слева снизу направо вверх
			for (int i = 0; i < cellCount; i++)
			{
				for (int j = cellCount - 1; j >= 0; j--)
				{
					inRowCount = 1;

					

					// Берем фигуру первой клетки, которую проверяем.
					currentFigure = Cells[i, j].figure;

					if (currentFigure != null)
					{
						int k = 1;

						winnerCells = new List<Cell>();

						while (
						(k <= 5)
						&& (j + k < cellCount)
						&& (i - k > 0)
						&& Cells[i - k, j + k].figure != null
						&& currentFigure != null
						&& Cells[i - k, j + k].figure == currentFigure)
						{
							inRowCount++;
							k++;

							winnerCells.Add(Cells[i, j]);

							if (inRowCount == 5)
							{
								HasWinner = true;
								WinnerFigure = currentFigure;

								return;
							}
						}
					}
				}
			}
		}

		// Проверка на ничью.
		public bool IsDraw()
		{
			for (int i = 0; i < cellCount; i++)
			{
				for (int j = 0; j < cellCount; j++)
				{
					// Если есть хоть еще 1 свободная клетка, то играть можно.
					if (Cells[i, j].figure == null)
					{
						return false;
					}
				}
			}

			return true;
		}
	}
}
