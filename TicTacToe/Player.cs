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

		// Конструктор.
		public Player(string Name, bool IsReady)
		{
			this.Name = Name;
			this.IsReady = IsReady;
		}
	}
}
