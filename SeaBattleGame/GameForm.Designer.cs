using System.Windows.Forms;
using System;

partial class GameForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.DataGridView playerField;
    private System.Windows.Forms.DataGridView computerField;
    private System.Windows.Forms.Label lblPlayerScore;
    private System.Windows.Forms.Label lblComputerScore;
    private System.Windows.Forms.Button btnSurrender;
    private System.Windows.Forms.Button btnStartGame;
    private System.Windows.Forms.Label lblShipInfo;

    private void InitializeComponent()
    {
        this.playerField = new System.Windows.Forms.DataGridView();
        this.computerField = new System.Windows.Forms.DataGridView();
        this.lblPlayerScore = new System.Windows.Forms.Label();
        this.lblComputerScore = new System.Windows.Forms.Label();
        this.btnSurrender = new System.Windows.Forms.Button();
        this.btnStartGame = new System.Windows.Forms.Button();
        this.lblShipInfo = new System.Windows.Forms.Label();
        this.lblGameTime = new System.Windows.Forms.Label(); // Инициализация lblGameTime
        ((System.ComponentModel.ISupportInitialize)(this.playerField)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.computerField)).BeginInit();
        this.SuspendLayout();
        // 
        // playerField
        // 
        this.playerField.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.playerField.Location = new System.Drawing.Point(18, 97);
        this.playerField.Name = "playerField";
        this.playerField.Size = new System.Drawing.Size(800, 800);
        this.playerField.TabIndex = 0;
        this.playerField.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.playerField_CellContentClick);
        // 
        // computerField
        // 
        this.computerField.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.computerField.Location = new System.Drawing.Point(832, 97);
        this.computerField.Name = "computerField";
        this.computerField.Size = new System.Drawing.Size(800, 800);
        this.computerField.TabIndex = 1;
        this.computerField.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.computerField_CellContentClick);
        // 
        // lblPlayerScore
        // 
        this.lblPlayerScore.AutoSize = true;
        this.lblPlayerScore.Location = new System.Drawing.Point(172, 1030);
        this.lblPlayerScore.Name = "lblPlayerScore";
        this.lblPlayerScore.Size = new System.Drawing.Size(82, 13);
        this.lblPlayerScore.TabIndex = 2;
        this.lblPlayerScore.Text = "Очки игрока: 0";
        this.lblPlayerScore.Click += new System.EventHandler(this.lblPlayerScore_Click);
        // 
        // lblComputerScore
        // 
        this.lblComputerScore.AutoSize = true;
        this.lblComputerScore.Location = new System.Drawing.Point(172, 1057);
        this.lblComputerScore.Name = "lblComputerScore";
        this.lblComputerScore.Size = new System.Drawing.Size(110, 13);
        this.lblComputerScore.TabIndex = 3;
        this.lblComputerScore.Text = "Очки компьютера: 0";
        this.lblComputerScore.Click += new System.EventHandler(this.lblComputerScore_Click);
        // 
        // btnSurrender
        // 
        this.btnSurrender.Location = new System.Drawing.Point(12, 1028);
        this.btnSurrender.Name = "btnSurrender";
        this.btnSurrender.Size = new System.Drawing.Size(75, 23);
        this.btnSurrender.TabIndex = 4;
        this.btnSurrender.Text = "Сдаться";
        this.btnSurrender.UseVisualStyleBackColor = true;
        this.btnSurrender.Click += new System.EventHandler(this.btnSurrender_Click);
        // 
        // btnStartGame
        // 
        this.btnStartGame.Location = new System.Drawing.Point(12, 1057);
        this.btnStartGame.Name = "btnStartGame";
        this.btnStartGame.Size = new System.Drawing.Size(75, 23);
        this.btnStartGame.TabIndex = 5;
        this.btnStartGame.Text = "Начать игру";
        this.btnStartGame.UseVisualStyleBackColor = true;
        this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
        // 
        // lblShipInfo
        // 
        this.lblShipInfo.AutoSize = true;
        this.lblShipInfo.Location = new System.Drawing.Point(15, 965);
        this.lblShipInfo.Name = "lblShipInfo";
        this.lblShipInfo.Size = new System.Drawing.Size(144, 13);
        this.lblShipInfo.TabIndex = 6;
        this.lblShipInfo.Text = "Информация о кораблях: 0";
        this.lblShipInfo.Click += new System.EventHandler(this.lblShipInfo_Click);
        // 
        // lblGameTime
        // 
        this.lblGameTime.AutoSize = true;
        this.lblGameTime.Location = new System.Drawing.Point(15, 75);
        this.lblGameTime.Name = "lblGameTime";
        this.lblGameTime.Size = new System.Drawing.Size(0, 13);
        this.lblGameTime.TabIndex = 7;
        this.Controls.Add(this.lblGameTime);
        // 
        // GameForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1644, 1092);
        this.Controls.Add(this.lblShipInfo);
        this.Controls.Add(this.btnStartGame);
        this.Controls.Add(this.btnSurrender);
        this.Controls.Add(this.lblComputerScore);
        this.Controls.Add(this.lblPlayerScore);
        this.Controls.Add(this.computerField);
        this.Controls.Add(this.playerField);
        this.Controls.Add(this.lblGameTime);
        this.Name = "GameForm";
        this.Text = "Морской бой - Игра";
        this.Load += new System.EventHandler(this.GameForm_Load);
        ((System.ComponentModel.ISupportInitialize)(this.playerField)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.computerField)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private void playerField_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        // Метод-заглушка для клика по ячейке поля игрока
    }

    private void computerField_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        // Метод-заглушка для клика по ячейке поля компьютера
    }

}

