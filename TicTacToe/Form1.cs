using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
	public partial class Form1 : Form
	{
		// Игрок за крестики.
		private Player crossesPlayer;

		// Игрок за нолики.
		private Player zerosPlayer;

		// Конструктор формы.
		public Form1()
		{
			InitializeComponent();

			// Инициализируем объект первого игрока и ставим ему что он не готов к игре.
			crossesPlayer = new Player("", false);

			// Инициализируем объект второго игрока и ставим ему что он не готов к игре.
			zerosPlayer = new Player("", false);
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

		}

		// Рисовка окна.
		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			var rectangle = new Rectangle(200, 50, 500, 500);
			var pen = new Pen(Color.Black);

			e.Graphics.DrawRectangle(pen, rectangle);
		}
	}
}
