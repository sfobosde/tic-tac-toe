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

		// Игровое поле.
		GameField gameField;

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

		}

		// Рисовка окна.
		private void Form1_Paint(object sender, PaintEventArgs e)
		{
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
					e.Graphics.DrawRectangle(pen, new Rectangle(
						gameField.Cells[i, j].xStartPoint,
						gameField.Cells[i, j].yStartPoint,
						gameField.Cells[i, j].width,
						gameField.Cells[i, j].height));

					// Рисуем фигуры в клетках. Проверим, есть ли они там.
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
					new Point(cell.xStartPoint, cell.yStartPoint),
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
	}
}
