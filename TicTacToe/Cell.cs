using System;

namespace TicTacToe
{
	// Клеточка на поле.
	class Cell
	{
		// Фигура, которая в клеточке.
		public Figure figure;

		public bool IsEmpty;

		// Координата левого верхнего угла клетки.
		public int xStartPoint;
		public int yStartPoint;

		// Координата правого ниженео угла клетки.
		public int xEndPoint;
		public int yEndPoint;

		// Размер клетки.
		public int width;
		public int height;

		// Конструктор класса, прописывающий координаты клетки, размеры клетки и координаты кнца клетки.
		public Cell(int xStartPoint, int yStartPoint, int width, int height)
		{
			// Координата левого верхнего угла клетки.
			this.xStartPoint = xStartPoint;
			this.yStartPoint = yStartPoint;

			// Размер клетки.
			this.width = width;
			this.height = height;

			// Координата правого ниженео угла клетки.
			this.xEndPoint = xStartPoint + width;
			this.yEndPoint = yStartPoint + height;

			IsEmpty = true;
		}

		// Проверить, попадают ли координаты в данную клетку.
		public bool IsHitsToCell(int x, int y)
		{
			return (x > xStartPoint && x < xEndPoint)
				&& (y > yStartPoint && y < yEndPoint);
		}

		// Установить в клетку фигуру.
		public void SetFigure(Figure figure)
		{
			this.figure = figure;
			IsEmpty = false;
		}
	}
}
