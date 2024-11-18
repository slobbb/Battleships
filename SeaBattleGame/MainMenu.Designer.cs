using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

partial class MainMenu : MaterialForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.btnStartGame = new MaterialSkin.Controls.MaterialButton();
            this.btnResults = new MaterialSkin.Controls.MaterialButton();
            this.btnSettings = new MaterialSkin.Controls.MaterialButton();
            this.btnExit = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // btnStartGame
            // 
            this.btnStartGame.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStartGame.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnStartGame.Depth = 0;
            this.btnStartGame.HighEmphasis = true;
            this.btnStartGame.Icon = null;
            this.btnStartGame.Location = new System.Drawing.Point(42, 104);
            this.btnStartGame.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnStartGame.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnStartGame.Size = new System.Drawing.Size(105, 36);
            this.btnStartGame.TabIndex = 0;
            this.btnStartGame.Text = "Начать игру";
            this.btnStartGame.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnStartGame.UseAccentColor = false;
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // btnResults
            // 
            this.btnResults.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnResults.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnResults.Depth = 0;
            this.btnResults.HighEmphasis = true;
            this.btnResults.Icon = null;
            this.btnResults.Location = new System.Drawing.Point(42, 152);
            this.btnResults.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnResults.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnResults.Name = "btnResults";
            this.btnResults.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnResults.Size = new System.Drawing.Size(105, 36);
            this.btnResults.TabIndex = 1;
            this.btnResults.Text = "Результаты";
            this.btnResults.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnResults.UseAccentColor = false;
            this.btnResults.UseVisualStyleBackColor = true;
            this.btnResults.Click += new System.EventHandler(this.btnResults_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSettings.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSettings.Depth = 0;
            this.btnSettings.HighEmphasis = true;
            this.btnSettings.Icon = null;
            this.btnSettings.Location = new System.Drawing.Point(42, 200);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSettings.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSettings.Size = new System.Drawing.Size(105, 36);
            this.btnSettings.TabIndex = 2;
            this.btnSettings.Text = "Настройки";
            this.btnSettings.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSettings.UseAccentColor = false;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnExit
            // 
            this.btnExit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnExit.Depth = 0;
            this.btnExit.HighEmphasis = true;
            this.btnExit.Icon = null;
            this.btnExit.Location = new System.Drawing.Point(42, 248);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnExit.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnExit.Name = "btnExit";
            this.btnExit.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnExit.Size = new System.Drawing.Size(105, 36);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Выход";
            this.btnExit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnExit.UseAccentColor = false;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 321);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnResults);
            this.Controls.Add(this.btnStartGame);
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "MainMenu";
            this.Text = "Морской Бой";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private MaterialSkin.Controls.MaterialButton btnStartGame;
    private MaterialSkin.Controls.MaterialButton btnResults;
    private MaterialSkin.Controls.MaterialButton btnSettings;
    private MaterialSkin.Controls.MaterialButton btnExit;
}
