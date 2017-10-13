namespace Go_Fish
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose( );
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent( )
		{
			this.label1 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.listHand = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnStart = new System.Windows.Forms.Button();
			this.txtProgress = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCompleteBooks = new System.Windows.Forms.TextBox();
			this.btnAsk = new System.Windows.Forms.Button();
			this.btnQuit = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Your name";
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(13, 33);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(178, 22);
			this.txtName.TabIndex = 1;
			// 
			// listHand
			// 
			this.listHand.Enabled = false;
			this.listHand.FormattingEnabled = true;
			this.listHand.ItemHeight = 16;
			this.listHand.Location = new System.Drawing.Point(297, 33);
			this.listHand.Name = "listHand";
			this.listHand.Size = new System.Drawing.Size(175, 468);
			this.listHand.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(297, 13);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Your hand";
			// 
			// btnStart
			// 
			this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnStart.Location = new System.Drawing.Point(12, 524);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(103, 25);
			this.btnStart.TabIndex = 4;
			this.btnStart.Text = "&Start game";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// txtProgress
			// 
			this.txtProgress.Location = new System.Drawing.Point(12, 91);
			this.txtProgress.Multiline = true;
			this.txtProgress.Name = "txtProgress";
			this.txtProgress.ReadOnly = true;
			this.txtProgress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtProgress.Size = new System.Drawing.Size(267, 296);
			this.txtProgress.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 390);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(115, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "Completed books";
			// 
			// txtCompleteBooks
			// 
			this.txtCompleteBooks.Location = new System.Drawing.Point(12, 409);
			this.txtCompleteBooks.Multiline = true;
			this.txtCompleteBooks.Name = "txtCompleteBooks";
			this.txtCompleteBooks.ReadOnly = true;
			this.txtCompleteBooks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtCompleteBooks.Size = new System.Drawing.Size(267, 94);
			this.txtCompleteBooks.TabIndex = 7;
			// 
			// btnAsk
			// 
			this.btnAsk.BackColor = System.Drawing.SystemColors.Control;
			this.btnAsk.Enabled = false;
			this.btnAsk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAsk.Location = new System.Drawing.Point(297, 524);
			this.btnAsk.Name = "btnAsk";
			this.btnAsk.Size = new System.Drawing.Size(175, 65);
			this.btnAsk.TabIndex = 8;
			this.btnAsk.Text = "&Ask for a card";
			this.btnAsk.UseVisualStyleBackColor = false;
			this.btnAsk.Click += new System.EventHandler(this.btnAsk_Click);
			// 
			// btnQuit
			// 
			this.btnQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnQuit.Location = new System.Drawing.Point(12, 564);
			this.btnQuit.Name = "btnQuit";
			this.btnQuit.Size = new System.Drawing.Size(103, 25);
			this.btnQuit.TabIndex = 9;
			this.btnQuit.Text = "&Quit";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 72);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(102, 16);
			this.label4.TabIndex = 10;
			this.label4.Text = "Game progress";
			// 
			// MainForm
			// 
			this.AcceptButton = this.btnAsk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.AliceBlue;
			this.ClientSize = new System.Drawing.Size(484, 601);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnQuit);
			this.Controls.Add(this.btnAsk);
			this.Controls.Add(this.txtCompleteBooks);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtProgress);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.listHand);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MainForm";
			this.Text = "Go Fish";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.ListBox listHand;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.TextBox txtProgress;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtCompleteBooks;
		private System.Windows.Forms.Button btnAsk;
		private System.Windows.Forms.Button btnQuit;
		private System.Windows.Forms.Label label4;
	}
}

