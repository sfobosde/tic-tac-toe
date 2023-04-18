using System;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
	public partial class Form1 : Form
	{
		// Игрок за крестики.
		private Player crossesPlayer;

		// Игрок за нолики.
		private Player zerosPlayer;

		// Игрок, совершающий текущий ход.
		private Player currentPlayer;

		// Игровое поле.
		GameField gameField;

		// Запущена ли игра.
		private bool gameIsOn;

		// Конструктор формы.
		public Form1()
		{
			InitializeComponent();

			// Инициализируем объект первого игрока и ставим ему что он не готов к игре.
			crossesPlayer = new Player("", false);

			// Инициализируем объект второго игрока и ставим ему что он не готов к игре.
			zerosPlayer = new Player("", false);

			// Инициализируем игровое поле.
			InitializeGameField();

			// Ставим, что игра еще не началась.
			gameIsOn = false;
		}

		// Функция загрущки формы.
		private void Form1_Load(object sender, EventArgs e)
		{

		}

		// Игрок за крестики нажал готово.
		private void crossesPlayerNameSubmitButton_Click(object sender, EventArgs e)
		{
			// Вызываем функцию обработки нажатия кнопки.
			crossesPlayer = HandlePlayerClickedSumbitButton(
				crossesPlayer, 
				this.crossesPlayerName, 
				this.crossesPlayerNameSubmitButton, 
				Figure.Crosses);
		}

		// Игрок нолики нажал на кнопку готово/редактировать.
		private void zerosPlayerNameSubmitButton_Click(object sender, EventArgs e)
		{
			zerosPlayer = HandlePlayerClickedSumbitButton(
				zerosPlayer,
				this.zerosPlayerName,
				this.zerosPlayerNameSubmitButton,
				Figure.Zeros);
		}

		// Обработка события нажатия игроком кнопоки Готово/редактировать.
		private Player HandlePlayerClickedSumbitButton(
			Player player, 
			TextBox playerNameTextBox, 
			Button sumbitButton, 
			Figure figure)
		{
			// Проверяем, готов ли был игрок к игре.
			if (player.IsReady)
			{
				// Игрок был готов к игре.

				// Ставим, что теперь игрок не готов.
				player.IsReady = false;

				// Делаем поле имени доступным к редактированию.
				playerNameTextBox.ReadOnly = false;

				// Меняем текст кнопки на готово.
				sumbitButton.Text = "Готово";
			}
			else
			{
				try
				{
					// Инициализируем игрока.
					player = InitializePlayer(playerNameTextBox.Text, figure);

					// Делаем поле имени недоступным к редактированию.
					playerNameTextBox.ReadOnly = true;

					// Меняем текст кнопки на Редактировть.
					sumbitButton.Text = "Редактировать";
				}
				catch (Exception exc)
				{
					// Выводим сообщене об ошибке.
					MessageBox.Show(exc.Message);
				}
			}

			return player;
		}

		// Инициализация игрока.
		private Player InitializePlayer(string Name, Figure figure)
		{
			// Проверяем, ввел ли игрок имя.
			if (string.IsNullOrEmpty(Name))
			{
				// Игрок не ввел имя и сбрасываем ошибку.
				throw new Exception("Игроку необходимо ввести имя");
			}

			// Если игрок все таки ввел имя.
			var player = new Player(Name, true);

			// Ставим ему нужную фигуру.
			player.SetPlayerFigure(figure);

			return player;
		}

		// Инициализируем игровое поле.
		private void InitializeGameField()
		{
			// Координаты точек по горизонтальной и вертикально осям.
			int horizontalStartPoint = 250;
			int varticalStartPont = 25;

			// Размеры поля в пикселях.
			int width = 500;
			int height = 500;

			// Размерность поля.
			int cellCount = 10;

			gameField = new GameField(horizontalStartPoint, varticalStartPont, width, height, cellCount);
		}

		// Обработка события нажатия на кнопку начать игру.
		private void StartGameButton_Click(object sender, EventArgs e)
		{
			if (IsPlayersReady())
			{
				StartGame();
			}
			else
			{
				MessageBox.Show("Все игроки должна нажать Готово");
			}
		}

		// Проверить, готовы ли игроки начать игру.
		private bool IsPlayersReady()
		{
			return crossesPlayer.IsReady && zerosPlayer.IsReady;
		}

		// Запустить игру.
		private void StartGame()
		{
			gameIsOn = true;

			// Делаем кнопки редактирования игроков неработающими.
			this.crossesPlayerNameSubmitButton.Enabled = false;
			this.zerosPlayerNameSubmitButton.Enabled = false;

			currentPlayer = crossesPlayer;

			SendClientMessage("Игра началась.\nПервым ходит игрок Крестики");

			// Вызываем перерисовку экрана.
			Invalidate();
		}

		// Отправка сообщения пользователю.
		private void SendClientMessage(string text = "")
		{
			this.ClientMessageLabel.Text = text;
		}

		// Рисовка окна.
		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			// Провеяем, начата ли игра. Выходим из функции, если не начата.
			if (!gameIsOn)
			{
				return;
			}

			DrawGameField(e);
		}

		private void DrawGameField(PaintEventArgs e)
		{
			// Создаем квадрат, очерчиващий все поле.
			Rectangle rectangle = new Rectangle(
				gameField.horizontalStartPoint, 
				gameField.verticalStartPont,
				gameField.width, 
				gameField.height);

			Pen pen = new Pen(Color.Black);

			e.Graphics.DrawRectangle(pen, rectangle);

			DrawCells(e);
		}

		// Рисуем все клетки.
		private void DrawCells(PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Black);

			// Берем по одной клетке и отрисовываем их в поле.
			for (int i = 0; i < gameField.cellCount; i++)
			{
				for (int j = 0; j < gameField.cellCount; j++)
				{
					e.Graphics.DrawRectangle(pen, 
						new Rectangle(
							gameField.Cells[i, j].xStartPoint,
							gameField.Cells[i, j].yStartPoint,
							gameField.Cells[i, j].width,
							gameField.Cells[i, j].height));

					// Рисуем фигуры в клетках. Проверим, есть ли они там, т.е. занята ли клетка.
					if (!gameField.Cells[i, j].IsEmpty)
					{
						DrawFigureInCell(gameField.Cells[i, j], e);
					}
				}
			}
		}

		// Отрисовываем фигуру внутри клетки.
		private void DrawFigureInCell(Cell cell, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Black);

			// Если фигура крестик.
			if (cell.figure == Figure.Crosses)
			{
				e.Graphics.DrawLine(
					pen,
					new Point(cell.xStartPoint , cell.yStartPoint),
					new Point(cell.xEndPoint, cell.yEndPoint));

				e.Graphics.DrawLine(
					pen,
					new Point(cell.xStartPoint, cell.yEndPoint),
					new Point(cell.xEndPoint, cell.yStartPoint));
			}

			// Если фигура нолик.
			if (cell.figure == Figure.Zeros)
			{
				e.Graphics.DrawEllipse(
					pen,
					new Rectangle(
						cell.xStartPoint,
						cell.yStartPoint,
						cell.width,
						cell.height));
			}
		}

		// Игрок нажал на поле.
		private void Form1_DoubleClick(object sender, EventArgs e)
		{
			// Проверяем, запущена ли игра. Если нет, то выходим из функции.
			if (!gameIsOn)
			{
				return;
			}

			// Преобразуем к другому виду для получения координат клика мышки.
			MouseEventArgs me = e as MouseEventArgs;

			// Проверяем, был ли клик внутри поля.
			if (gameField.IsPointOnField(me.X, me.Y))
			{
				// Пробуем найти и поставить фигуру текущего игрока в клетку.
				try
				{
					// Ищем клетку.
					var cell = gameField.FindCell(me.X, me.Y);

					// Ставим в эту клетку фигуру.
					cell.SetFigure(currentPlayer.PlayerFigure);

					// Передаем ход другому игроку.
					SwitchPlayer();

					// Провеяем, нету ли победителя.
					MonitoreGame();

					// Перерисовываем экран.
					Invalidate();
				}
				catch (Exception excp)
				{
					// Если проищошла ошибка, отправляем сообщение с текстом ошибки.
					SendClientMessage(excp.Message);
				}
			}
		}

		// Меняем игрока.
		private void SwitchPlayer()
		{
			// Тернарный оператор.
			currentPlayer = (currentPlayer == crossesPlayer)
				? zerosPlayer
				: crossesPlayer;

			SendClientMessage($"Ход перешел к игроку:{currentPlayer.Name}");
		}

		// Проверяем состояние поля.
		private void MonitoreGame()
		{
			gameField.MonitorGameState();

			if (gameField.HasWinner)
			{
				gameIsOn = false;

				Figure? winnerFigure = gameField.WinnerFigure;

				Player winner = (crossesPlayer.PlayerFigure == winnerFigure)
					? crossesPlayer
					: zerosPlayer;

				SendClientMessage($"Победитель раунда: {winner.Name}");
			}
		}
	}
}
