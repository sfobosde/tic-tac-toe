using System;
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

		// Клеточки на поле.
		public Cell[,] Cells;

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
	}
}
