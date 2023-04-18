using System;
namespace TicTacToe
{
	// Игровое поле.
	class GameField
	{
		// Координаты точек по горизонтальной и вертикально осям.
		public int horizontalStartPoint;
		public int verticalStartPont;

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
	}
}
