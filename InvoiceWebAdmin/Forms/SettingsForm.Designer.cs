namespace InvoiceWebAdmin.Forms;

partial class SettingsForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        _nudTrialDays = new NumericUpDown();
        _txtMonthlyPrice = new TextBox();
        var lblTrialDays = new Label();
        var lblMonthlyPrice = new Label();
        var btnSave = new Button();
        ((System.ComponentModel.ISupportInitialize)_nudTrialDays).BeginInit();
        SuspendLayout();

        // lblTrialDays
        lblTrialDays.Text = "Trial dní pro nového uživatele:";
        lblTrialDays.Left = 12; lblTrialDays.Top = 20;
        lblTrialDays.Width = 180; lblTrialDays.Height = 23;
        lblTrialDays.TextAlign = ContentAlignment.MiddleRight;

        // _nudTrialDays
        _nudTrialDays.Left = 200; _nudTrialDays.Top = 20; _nudTrialDays.Width = 120;
        _nudTrialDays.Minimum = 0; _nudTrialDays.Maximum = 365;

        // lblMonthlyPrice
        lblMonthlyPrice.Text = "Měsíční cena bez DPH (Kč):";
        lblMonthlyPrice.Left = 12; lblMonthlyPrice.Top = 56;
        lblMonthlyPrice.Width = 180; lblMonthlyPrice.Height = 23;
        lblMonthlyPrice.TextAlign = ContentAlignment.MiddleRight;

        // _txtMonthlyPrice
        _txtMonthlyPrice.Left = 200; _txtMonthlyPrice.Top = 56; _txtMonthlyPrice.Width = 120;

        // btnSave
        btnSave.Text = "Uložit";
        btnSave.Left = 200; btnSave.Top = 100; btnSave.Width = 90;
        btnSave.Click += Save;

        // SettingsForm
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Text = "Globální nastavení";
        ClientSize = new Size(340, 148);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false; MinimizeBox = false;
        StartPosition = FormStartPosition.CenterParent;
        Controls.AddRange(new Control[] { lblTrialDays, _nudTrialDays, lblMonthlyPrice, _txtMonthlyPrice, btnSave });

        ((System.ComponentModel.ISupportInitialize)_nudTrialDays).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private NumericUpDown _nudTrialDays = null!;
    private TextBox _txtMonthlyPrice = null!;
}
