
namespace TicTacToe
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.crossesPlayerName = new System.Windows.Forms.TextBox();
			this.crossesPlayerNameLabel = new System.Windows.Forms.Label();
			this.zerosPlayerNameLabel = new System.Windows.Forms.Label();
			this.zerosPlayerName = new System.Windows.Forms.TextBox();
			this.crossesPlayerNameSubmitButton = new System.Windows.Forms.Button();
			this.zerosPlayerNameSubmitButton = new System.Windows.Forms.Button();
			this.StartGameButton = new System.Windows.Forms.Button();
			this.ClientMessageLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// crossesPlayerName
			// 
			this.crossesPlayerName.Location = new System.Drawing.Point(12, 39);
			this.crossesPlayerName.Name = "crossesPlayerName";
			this.crossesPlayerName.Size = new System.Drawing.Size(100, 23);
			this.crossesPlayerName.TabIndex = 0;
			// 
			// crossesPlayerNameLabel
			// 
			this.crossesPlayerNameLabel.AutoSize = true;
			this.crossesPlayerNameLabel.Location = new System.Drawing.Point(13, 18);
			this.crossesPlayerNameLabel.Name = "crossesPlayerNameLabel";
			this.crossesPlayerNameLabel.Size = new System.Drawing.Size(136, 15);
			this.crossesPlayerNameLabel.TabIndex = 1;
			this.crossesPlayerNameLabel.Text = "Имя игрока \"Крестики\"";
			// 
			// zerosPlayerNameLabel
			// 
			this.zerosPlayerNameLabel.AutoSize = true;
			this.zerosPlayerNameLabel.Location = new System.Drawing.Point(13, 69);
			this.zerosPlayerNameLabel.Name = "zerosPlayerNameLabel";
			this.zerosPlayerNameLabel.Size = new System.Drawing.Size(128, 15);
			this.zerosPlayerNameLabel.TabIndex = 2;
			this.zerosPlayerNameLabel.Text = "Имя игрока \"Нолики\"";
			// 
			// zerosPlayerName
			// 
			this.zerosPlayerName.Location = new System.Drawing.Point(13, 88);
			this.zerosPlayerName.Name = "zerosPlayerName";
			this.zerosPlayerName.Size = new System.Drawing.Size(100, 23);
			this.zerosPlayerName.TabIndex = 3;
			// 
			// crossesPlayerNameSubmitButton
			// 
			this.crossesPlayerNameSubmitButton.Location = new System.Drawing.Point(119, 39);
			this.crossesPlayerNameSubmitButton.Name = "crossesPlayerNameSubmitButton";
			this.crossesPlayerNameSubmitButton.Size = new System.Drawing.Size(75, 23);
			this.crossesPlayerNameSubmitButton.TabIndex = 4;
			this.crossesPlayerNameSubmitButton.Text = "Готово";
			this.crossesPlayerNameSubmitButton.UseVisualStyleBackColor = true;
			this.crossesPlayerNameSubmitButton.Click += new System.EventHandler(this.crossesPlayerNameSubmitButton_Click);
			// 
			// zerosPlayerNameSubmitButton
			// 
			this.zerosPlayerNameSubmitButton.Location = new System.Drawing.Point(120, 88);
			this.zerosPlayerNameSubmitButton.Name = "zerosPlayerNameSubmitButton";
			this.zerosPlayerNameSubmitButton.Size = new System.Drawing.Size(75, 23);
			this.zerosPlayerNameSubmitButton.TabIndex = 5;
			this.zerosPlayerNameSubmitButton.Text = "Готово";
			this.zerosPlayerNameSubmitButton.UseVisualStyleBackColor = true;
			this.zerosPlayerNameSubmitButton.Click += new System.EventHandler(this.zerosPlayerNameSubmitButton_Click);
			// 
			// StartGameButton
			// 
			this.StartGameButton.Location = new System.Drawing.Point(12, 140);
			this.StartGameButton.Name = "StartGameButton";
			this.StartGameButton.Size = new System.Drawing.Size(100, 28);
			this.StartGameButton.TabIndex = 6;
			this.StartGameButton.Text = "Новая игра";
			this.StartGameButton.UseVisualStyleBackColor = true;
			this.StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
			// 
			// ClientMessageLabel
			// 
			this.ClientMessageLabel.AutoSize = true;
			this.ClientMessageLabel.Location = new System.Drawing.Point(13, 175);
			this.ClientMessageLabel.Name = "ClientMessageLabel";
			this.ClientMessageLabel.Size = new System.Drawing.Size(0, 15);
			this.ClientMessageLabel.TabIndex = 7;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.Controls.Add(this.ClientMessageLabel);
			this.Controls.Add(this.StartGameButton);
			this.Controls.Add(this.zerosPlayerNameSubmitButton);
			this.Controls.Add(this.crossesPlayerNameSubmitButton);
			this.Controls.Add(this.zerosPlayerName);
			this.Controls.Add(this.zerosPlayerNameLabel);
			this.Controls.Add(this.crossesPlayerNameLabel);
			this.Controls.Add(this.crossesPlayerName);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
			this.DoubleClick += new System.EventHandler(this.Form1_DoubleClick);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox crossesPlayerName;
		private System.Windows.Forms.Label crossesPlayerNameLabel;
		private System.Windows.Forms.Label zerosPlayerNameLabel;
		private System.Windows.Forms.TextBox zerosPlayerName;
		private System.Windows.Forms.Button crossesPlayerNameSubmitButton;
		private System.Windows.Forms.Button zerosPlayerNameSubmitButton;
		private System.Windows.Forms.Button StartGameButton;
		private System.Windows.Forms.Label ClientMessageLabel;
	}
}

