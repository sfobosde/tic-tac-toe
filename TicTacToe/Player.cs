namespace TicTacToe
{
	// Класс игрока.
	class Player
	{
		// Имя игрока.
		public string Name;

		// Игрок готов.
		public bool IsReady;

		// Количество побед.
		public int WinCount;

		// Количество поражений.
		public int LoseCount;

		// Фигура.
		public Figure PlayerFigure;

		// Конструктор.
		public Player(string Name, bool IsReady)
		{
			this.Name = Name;
			this.IsReady = IsReady;
		}

		// Устанавливаем фигуру игроку.
		public void SetPlayerFigure(Figure PlayerFigure)
		{
			this.PlayerFigure = PlayerFigure;
		}
	}
}
