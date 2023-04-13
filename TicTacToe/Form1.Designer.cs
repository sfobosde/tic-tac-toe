
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
			this.zerosPlayerNameLabel.Size = new System.Drawing.Size(136, 15);
			this.zerosPlayerNameLabel.TabIndex = 2;
			this.zerosPlayerNameLabel.Text = "Имя игрока \"Крестики\"";
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
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.Controls.Add(this.zerosPlayerNameSubmitButton);
			this.Controls.Add(this.crossesPlayerNameSubmitButton);
			this.Controls.Add(this.zerosPlayerName);
			this.Controls.Add(this.zerosPlayerNameLabel);
			this.Controls.Add(this.crossesPlayerNameLabel);
			this.Controls.Add(this.crossesPlayerName);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
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
	}
}

