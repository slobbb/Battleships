// SettingsForm.cs
using System;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using SeaBattleGame.Properties;

public partial class SettingsForm : MaterialForm
{
    private MainMenu mainMenu;

    public SettingsForm(MainMenu mainMenu)
    {
        InitializeComponent();
        this.mainMenu = mainMenu;

        var materialSkinManager = MaterialSkinManager.Instance;
        materialSkinManager.AddFormToManage(this);
        ApplySavedColorScheme();

        toggleMusic.Checked = Settings.Default.MusicEnabled;
        toggleSoundEffects.Checked = Settings.Default.SoundEffectsEnabled;
        numericBoardSize.Value = Settings.Default.BoardSize;
        numericBattleshipCount.Value = Settings.Default.BattleshipCount;
        numericSubmarineCount.Value = Settings.Default.SubmarineCount;
        numericDestroyerCount.Value = Settings.Default.DestroyerCount;
        numericTorpedoBoatCount.Value = Settings.Default.TorpedoBoatCount;
        comboBoxColorScheme.SelectedIndex = Settings.Default.ColorScheme;

        SetShipCountLimits();
    }

    private void SetShipCountLimits()
    {
        int maxShips = Settings.Default.BoardSize * Settings.Default.BoardSize / 10;

        numericBattleshipCount.Maximum = maxShips;
        numericSubmarineCount.Maximum = maxShips;
        numericDestroyerCount.Maximum = maxShips;
        numericTorpedoBoatCount.Maximum = maxShips;
    }

    private void btnApply_Click(object sender, EventArgs e)
    {
        Settings.Default.MusicEnabled = toggleMusic.Checked;
        Settings.Default.SoundEffectsEnabled = toggleSoundEffects.Checked;
        Settings.Default.BoardSize = (int)numericBoardSize.Value;
        Settings.Default.BattleshipCount = (int)numericBattleshipCount.Value;
        Settings.Default.SubmarineCount = (int)numericSubmarineCount.Value;
        Settings.Default.DestroyerCount = (int)numericDestroyerCount.Value;
        Settings.Default.TorpedoBoatCount = (int)numericTorpedoBoatCount.Value;
        Settings.Default.ColorScheme = comboBoxColorScheme.SelectedIndex;
        Settings.Default.Save();
        SyncSettings();
        mainMenu.SyncSettings(); // Убедитесь, что MainMenu имеет этот метод
        this.Close();
    }

    private void ApplyColorScheme()
    {
        var materialSkinManager = MaterialSkinManager.Instance;
        materialSkinManager.AddFormToManage(this);
        switch (Settings.Default.ColorScheme)
        {
            case 0:
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue700, Primary.Blue200, Accent.LightBlue200, TextShade.WHITE);
                break;
            case 1:
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Red600, Primary.Red700, Primary.Red200, Accent.Pink200, TextShade.WHITE);
                break;
            case 2:
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green700, Primary.Green200, Accent.LightGreen200, TextShade.WHITE);
                break;
        }
    }

    private void ApplySavedColorScheme()
    {
        var materialSkinManager = MaterialSkinManager.Instance;
        switch (Settings.Default.ColorScheme)
        {
            case 0:
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue700, Primary.Blue200, Accent.LightBlue200, TextShade.WHITE);
                break;
            case 1:
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Red600, Primary.Red700, Primary.Red200, Accent.Pink200, TextShade.WHITE);
                break;
            case 2:
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green700, Primary.Green200, Accent.LightGreen200, TextShade.WHITE);
                break;
        }
    }

    private void SyncSettings()
    {
        ApplyColorScheme();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void toggleMusic_CheckedChanged(object sender, EventArgs e)
    {
        // Метод-заглушка
    }

    private void toggleSoundEffects_CheckedChanged(object sender, EventArgs e)
    {
        // Метод-заглушка
    }

    private void SettingsForm_Load(object sender, EventArgs e)
    {
        // Метод-заглушка
    }
}
