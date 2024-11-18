using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

partial class SettingsForm : MaterialForm
{
    private System.ComponentModel.IContainer components = null;
    private MaterialSkin.Controls.MaterialSwitch toggleMusic;
    private MaterialSkin.Controls.MaterialSwitch toggleSoundEffects;
    private MaterialSkin.Controls.MaterialButton btnApply;
    private MaterialSkin.Controls.MaterialButton btnCancel;
    private NumericUpDown numericBoardSize;
    private NumericUpDown numericBattleshipCount;
    private NumericUpDown numericSubmarineCount;
    private NumericUpDown numericDestroyerCount;
    private NumericUpDown numericTorpedoBoatCount;
    private MaterialLabel lblBoardSize;
    private MaterialLabel lblBattleshipCount;
    private MaterialLabel lblSubmarineCount;
    private MaterialLabel lblDestroyerCount;
    private MaterialLabel lblTorpedoBoatCount;
    private MaterialLabel lblColorScheme;
    private ComboBox comboBoxColorScheme;

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
        this.toggleMusic = new MaterialSkin.Controls.MaterialSwitch();
        this.toggleSoundEffects = new MaterialSkin.Controls.MaterialSwitch();
        this.btnApply = new MaterialSkin.Controls.MaterialButton();
        this.btnCancel = new MaterialSkin.Controls.MaterialButton();
        this.numericBoardSize = new System.Windows.Forms.NumericUpDown();
        this.numericBattleshipCount = new System.Windows.Forms.NumericUpDown();
        this.numericSubmarineCount = new System.Windows.Forms.NumericUpDown();
        this.numericDestroyerCount = new System.Windows.Forms.NumericUpDown();
        this.numericTorpedoBoatCount = new System.Windows.Forms.NumericUpDown();
        this.lblBoardSize = new MaterialSkin.Controls.MaterialLabel();
        this.lblBattleshipCount = new MaterialSkin.Controls.MaterialLabel();
        this.lblSubmarineCount = new MaterialSkin.Controls.MaterialLabel();
        this.lblDestroyerCount = new MaterialSkin.Controls.MaterialLabel();
        this.lblTorpedoBoatCount = new MaterialSkin.Controls.MaterialLabel();
        this.lblColorScheme = new MaterialSkin.Controls.MaterialLabel();
        this.comboBoxColorScheme = new System.Windows.Forms.ComboBox();
        ((System.ComponentModel.ISupportInitialize)(this.numericBoardSize)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numericBattleshipCount)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numericSubmarineCount)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numericDestroyerCount)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numericTorpedoBoatCount)).BeginInit();
        this.SuspendLayout();
        // 
        // toggleMusic
        // 
        this.toggleMusic.AutoSize = true;
        this.toggleMusic.Depth = 0;
        this.toggleMusic.Location = new System.Drawing.Point(75, 96);
        this.toggleMusic.Margin = new System.Windows.Forms.Padding(0);
        this.toggleMusic.MouseLocation = new System.Drawing.Point(-1, -1);
        this.toggleMusic.MouseState = MaterialSkin.MouseState.HOVER;
        this.toggleMusic.Name = "toggleMusic";
        this.toggleMusic.Ripple = true;
        this.toggleMusic.Size = new System.Drawing.Size(118, 37);
        this.toggleMusic.TabIndex = 0;
        this.toggleMusic.Text = "Музыка";
        this.toggleMusic.UseVisualStyleBackColor = true;
        this.toggleMusic.CheckedChanged += new System.EventHandler(this.toggleMusic_CheckedChanged);
        // 
        // toggleSoundEffects
        // 
        this.toggleSoundEffects.AutoSize = true;
        this.toggleSoundEffects.Depth = 0;
        this.toggleSoundEffects.Location = new System.Drawing.Point(75, 144);
        this.toggleSoundEffects.Margin = new System.Windows.Forms.Padding(0);
        this.toggleSoundEffects.MouseLocation = new System.Drawing.Point(-1, -1);
        this.toggleSoundEffects.MouseState = MaterialSkin.MouseState.HOVER;
        this.toggleSoundEffects.Name = "toggleSoundEffects";
        this.toggleSoundEffects.Ripple = true;
        this.toggleSoundEffects.Size = new System.Drawing.Size(205, 37);
        this.toggleSoundEffects.TabIndex = 1;
        this.toggleSoundEffects.Text = "Звуковые эффекты";
        this.toggleSoundEffects.UseVisualStyleBackColor = true;
        this.toggleSoundEffects.CheckedChanged += new System.EventHandler(this.toggleSoundEffects_CheckedChanged);
        // 
        // btnApply
        // 
        this.btnApply.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        this.btnApply.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
        this.btnApply.Depth = 0;
        this.btnApply.HighEmphasis = true;
        this.btnApply.Icon = null;
        this.btnApply.Location = new System.Drawing.Point(134, 513);
        this.btnApply.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
        this.btnApply.MouseState = MaterialSkin.MouseState.HOVER;
        this.btnApply.Name = "btnApply";
        this.btnApply.NoAccentTextColor = System.Drawing.Color.Empty;
        this.btnApply.Size = new System.Drawing.Size(92, 36);
        this.btnApply.TabIndex = 2;
        this.btnApply.Text = "Применить";
        this.btnApply.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
        this.btnApply.UseAccentColor = false;
        this.btnApply.UseVisualStyleBackColor = true;
        this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
        // 
        // btnCancel
        // 
        this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
        this.btnCancel.Depth = 0;
        this.btnCancel.HighEmphasis = true;
        this.btnCancel.Icon = null;
        this.btnCancel.Location = new System.Drawing.Point(239, 513);
        this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
        this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.NoAccentTextColor = System.Drawing.Color.Empty;
        this.btnCancel.Size = new System.Drawing.Size(64, 36);
        this.btnCancel.TabIndex = 3;
        this.btnCancel.Text = "Отмена";
        this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
        this.btnCancel.UseAccentColor = false;
        this.btnCancel.UseVisualStyleBackColor = true;
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        // 
        // numericBoardSize
        // 
        this.numericBoardSize.Location = new System.Drawing.Point(315, 200);
        this.numericBoardSize.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
        this.numericBoardSize.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
        this.numericBoardSize.Name = "numericBoardSize";
        this.numericBoardSize.Size = new System.Drawing.Size(120, 20);
        this.numericBoardSize.TabIndex = 4;
        this.numericBoardSize.Value = new decimal(new int[] { 5, 0, 0, 0 });
        // 
        // numericBattleshipCount
        // 
        this.numericBattleshipCount.Location = new System.Drawing.Point(315, 240);
        this.numericBattleshipCount.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
        this.numericBattleshipCount.Name = "numericBattleshipCount";
        this.numericBattleshipCount.Size = new System.Drawing.Size(120, 20);
        this.numericBattleshipCount.TabIndex = 5;
        // 
        // numericSubmarineCount
        // 
        this.numericSubmarineCount.Location = new System.Drawing.Point(315, 280);
        this.numericSubmarineCount.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
        this.numericSubmarineCount.Name = "numericSubmarineCount";
        this.numericSubmarineCount.Size = new System.Drawing.Size(120, 20);
        this.numericSubmarineCount.TabIndex = 6;
        // 
        // numericDestroyerCount
        // 
        this.numericDestroyerCount.Location = new System.Drawing.Point(315, 320);
        this.numericDestroyerCount.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
        this.numericDestroyerCount.Name = "numericDestroyerCount";
        this.numericDestroyerCount.Size = new System.Drawing.Size(120, 20);
        this.numericDestroyerCount.TabIndex = 7;
        // 
        // numericTorpedoBoatCount
        // 
        this.numericTorpedoBoatCount.Location = new System.Drawing.Point(315, 360);
        this.numericTorpedoBoatCount.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
        this.numericTorpedoBoatCount.Name = "numericTorpedoBoatCount";
        this.numericTorpedoBoatCount.Size = new System.Drawing.Size(120, 20);
        this.numericTorpedoBoatCount.TabIndex = 8;
        // 
        // lblBoardSize
        // 
        this.lblBoardSize.AutoSize = true;
        this.lblBoardSize.Depth = 0;
        this.lblBoardSize.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
        this.lblBoardSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.lblBoardSize.Location = new System.Drawing.Point(75, 200);
        this.lblBoardSize.MouseState = MaterialSkin.MouseState.HOVER;
        this.lblBoardSize.Name = "lblBoardSize";
        this.lblBoardSize.Size = new System.Drawing.Size(97, 20);
        this.lblBoardSize.TabIndex = 10;
        this.lblBoardSize.Text = "Размер поля";
        // 
        // lblBattleshipCount
        // 
        this.lblBattleshipCount.AutoSize = true;
        this.lblBattleshipCount.Depth = 0;
        this.lblBattleshipCount.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
        this.lblBattleshipCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.lblBattleshipCount.Location = new System.Drawing.Point(75, 240);
        this.lblBattleshipCount.MouseState = MaterialSkin.MouseState.HOVER;
        this.lblBattleshipCount.Name = "lblBattleshipCount";
        this.lblBattleshipCount.Size = new System.Drawing.Size(165, 20);
        this.lblBattleshipCount.TabIndex = 12;
        this.lblBattleshipCount.Text = "Количество линкоров";
        // 
        // lblSubmarineCount
        // 
        this.lblSubmarineCount.AutoSize = true;
        this.lblSubmarineCount.Depth = 0;
        this.lblSubmarineCount.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
        this.lblSubmarineCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.lblSubmarineCount.Location = new System.Drawing.Point(75, 280);
        this.lblSubmarineCount.MouseState = MaterialSkin.MouseState.HOVER;
        this.lblSubmarineCount.Name = "lblSubmarineCount";
        this.lblSubmarineCount.Size = new System.Drawing.Size(228, 20);
        this.lblSubmarineCount.TabIndex = 13;
        this.lblSubmarineCount.Text = "Количество подводных лодок";
        // 
        // lblDestroyerCount
        // 
        this.lblDestroyerCount.AutoSize = true;
        this.lblDestroyerCount.Depth = 0;
        this.lblDestroyerCount.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
        this.lblDestroyerCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.lblDestroyerCount.Location = new System.Drawing.Point(75, 320);
        this.lblDestroyerCount.MouseState = MaterialSkin.MouseState.HOVER;
        this.lblDestroyerCount.Name = "lblDestroyerCount";
        this.lblDestroyerCount.Size = new System.Drawing.Size(166, 20);
        this.lblDestroyerCount.TabIndex = 14;
        this.lblDestroyerCount.Text = "Количество эсминцев";
        // 
        // lblTorpedoBoatCount
        // 
        this.lblTorpedoBoatCount.AutoSize = true;
        this.lblTorpedoBoatCount.Depth = 0;
        this.lblTorpedoBoatCount.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
        this.lblTorpedoBoatCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.lblTorpedoBoatCount.Location = new System.Drawing.Point(75, 360);
        this.lblTorpedoBoatCount.MouseState = MaterialSkin.MouseState.HOVER;
        this.lblTorpedoBoatCount.Name = "lblTorpedoBoatCount";
        this.lblTorpedoBoatCount.Size = new System.Drawing.Size(200, 20);
        this.lblTorpedoBoatCount.TabIndex = 15;
        this.lblTorpedoBoatCount.Text = "Количество торпедных катеров";
        // 
        // lblColorScheme
        // 
        this.lblColorScheme.AutoSize = true;
        this.lblColorScheme.Depth = 0;
        this.lblColorScheme.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
        this.lblColorScheme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.lblColorScheme.Location = new System.Drawing.Point(75, 400);
        this.lblColorScheme.MouseState = MaterialSkin.MouseState.HOVER;
        this.lblColorScheme.Name = "lblColorScheme";
        this.lblColorScheme.Size = new System.Drawing.Size(123, 20);
        this.lblColorScheme.TabIndex = 16;
        this.lblColorScheme.Text = "Цветовая схема";
        // 
        // comboBoxColorScheme
        // 
        this.comboBoxColorScheme.FormattingEnabled = true;
        this.comboBoxColorScheme.Items.AddRange(new object[] {
            "Синяя",
            "Красная",
            "Зеленая"});
        this.comboBoxColorScheme.Location = new System.Drawing.Point(315, 400);
        this.comboBoxColorScheme.Name = "comboBoxColorScheme";
        this.comboBoxColorScheme.Size = new System.Drawing.Size(121, 21);
        this.comboBoxColorScheme.TabIndex = 17;
        // 
        // SettingsForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(463, 582);
        this.Controls.Add(this.comboBoxColorScheme);
        this.Controls.Add(this.lblColorScheme);
        this.Controls.Add(this.lblTorpedoBoatCount);
        this.Controls.Add(this.lblDestroyerCount);
        this.Controls.Add(this.lblSubmarineCount);
        this.Controls.Add(this.lblBattleshipCount);
        this.Controls.Add(this.lblBoardSize);
        this.Controls.Add(this.numericTorpedoBoatCount);
        this.Controls.Add(this.numericDestroyerCount);
        this.Controls.Add(this.numericSubmarineCount);
        this.Controls.Add(this.numericBattleshipCount);
        this.Controls.Add(this.numericBoardSize);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnApply);
        this.Controls.Add(this.toggleSoundEffects);
        this.Controls.Add(this.toggleMusic);
        this.Name = "SettingsForm";
        this.Text = "Настройки";
        this.Load += new System.EventHandler(this.SettingsForm_Load);
        ((System.ComponentModel.ISupportInitialize)(this.numericBoardSize)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numericBattleshipCount)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numericSubmarineCount)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numericDestroyerCount)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numericTorpedoBoatCount)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
