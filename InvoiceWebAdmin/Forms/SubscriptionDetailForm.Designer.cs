namespace InvoiceWebAdmin.Forms;

partial class SubscriptionDetailForm
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
        _btnMarkPaid = new Button();
        _btnUnmarkPaid = new Button();
        _btnEdit = new Button();
        _btnOpenUser = new Button();
        _btnClose = new Button();
        _lblFirmaVal = new Label();
        _lblEmailVal = new Label();
        _lblOdVal = new Label();
        _lblDoVal = new Label();
        _lblVarSymVal = new Label();
        _lblDatumObjVal = new Label();
        _lblZaplacenoVal = new Label();
        _lblStavVal = new Label();
        SuspendLayout();

        const int lx = 12, lw = 160, cx = 180, vw = 320;

        // Firma
        var lblFirma = new Label { Text = "Firma:", Left = lx, Top = 16, Width = lw, Height = 23, TextAlign = ContentAlignment.MiddleRight, Font = new Font(Font, FontStyle.Bold) };
        _lblFirmaVal.Left = cx; _lblFirmaVal.Top = 16; _lblFirmaVal.Width = vw; _lblFirmaVal.Height = 23;
        _lblFirmaVal.TextAlign = ContentAlignment.MiddleLeft;

        // Email
        var lblEmail = new Label { Text = "E-mail:", Left = lx, Top = 46, Width = lw, Height = 23, TextAlign = ContentAlignment.MiddleRight, Font = new Font(Font, FontStyle.Bold) };
        _lblEmailVal.Left = cx; _lblEmailVal.Top = 46; _lblEmailVal.Width = vw; _lblEmailVal.Height = 23;
        _lblEmailVal.TextAlign = ContentAlignment.MiddleLeft;

        // Separator
        var sep = new Label { Left = lx, Top = 82, Width = cx + vw, Height = 1, BorderStyle = BorderStyle.Fixed3D };

        // Od
        var lblOd = new Label { Text = "Od:", Left = lx, Top = 92, Width = lw, Height = 23, TextAlign = ContentAlignment.MiddleRight, Font = new Font(Font, FontStyle.Bold) };
        _lblOdVal.Left = cx; _lblOdVal.Top = 92; _lblOdVal.Width = vw; _lblOdVal.Height = 23;
        _lblOdVal.TextAlign = ContentAlignment.MiddleLeft;

        // Do
        var lblDo = new Label { Text = "Do:", Left = lx, Top = 122, Width = lw, Height = 23, TextAlign = ContentAlignment.MiddleRight, Font = new Font(Font, FontStyle.Bold) };
        _lblDoVal.Left = cx; _lblDoVal.Top = 122; _lblDoVal.Width = vw; _lblDoVal.Height = 23;
        _lblDoVal.TextAlign = ContentAlignment.MiddleLeft;

        // Variabilní symbol
        var lblVarSym = new Label { Text = "Variabilní symbol:", Left = lx, Top = 152, Width = lw, Height = 23, TextAlign = ContentAlignment.MiddleRight, Font = new Font(Font, FontStyle.Bold) };
        _lblVarSymVal.Left = cx; _lblVarSymVal.Top = 152; _lblVarSymVal.Width = vw; _lblVarSymVal.Height = 23;
        _lblVarSymVal.TextAlign = ContentAlignment.MiddleLeft;

        // Datum objednávky
        var lblDatumObj = new Label { Text = "Datum objednávky:", Left = lx, Top = 182, Width = lw, Height = 23, TextAlign = ContentAlignment.MiddleRight, Font = new Font(Font, FontStyle.Bold) };
        _lblDatumObjVal.Left = cx; _lblDatumObjVal.Top = 182; _lblDatumObjVal.Width = vw; _lblDatumObjVal.Height = 23;
        _lblDatumObjVal.TextAlign = ContentAlignment.MiddleLeft;

        // Zaplaceno
        var lblZaplaceno = new Label { Text = "Zaplaceno:", Left = lx, Top = 212, Width = lw, Height = 23, TextAlign = ContentAlignment.MiddleRight, Font = new Font(Font, FontStyle.Bold) };
        _lblZaplacenoVal.Left = cx; _lblZaplacenoVal.Top = 212; _lblZaplacenoVal.Width = vw; _lblZaplacenoVal.Height = 23;
        _lblZaplacenoVal.TextAlign = ContentAlignment.MiddleLeft;
        _lblZaplacenoVal.Font = new Font(Font, FontStyle.Bold);

        // Stav
        var lblStav = new Label { Text = "Stav:", Left = lx, Top = 242, Width = lw, Height = 23, TextAlign = ContentAlignment.MiddleRight, Font = new Font(Font, FontStyle.Bold) };
        _lblStavVal.Left = cx; _lblStavVal.Top = 242; _lblStavVal.Width = vw; _lblStavVal.Height = 23;
        _lblStavVal.TextAlign = ContentAlignment.MiddleLeft;
        _lblStavVal.Font = new Font(Font, FontStyle.Bold);

        // Buttons – row 1
        _btnMarkPaid.Text = "Označit jako zaplacené";
        _btnMarkPaid.Left = lx; _btnMarkPaid.Top = 288;
        _btnMarkPaid.Width = 160; _btnMarkPaid.Height = 28;
        _btnMarkPaid.Click += BtnMarkPaid_Click;

        _btnUnmarkPaid.Text = "Zrušit zaplacení";
        _btnUnmarkPaid.Left = lx + 168; _btnUnmarkPaid.Top = 288;
        _btnUnmarkPaid.Width = 120; _btnUnmarkPaid.Height = 28;
        _btnUnmarkPaid.Click += BtnUnmarkPaid_Click;

        _btnEdit.Text = "Upravit";
        _btnEdit.Left = lx + 296; _btnEdit.Top = 288;
        _btnEdit.Width = 90; _btnEdit.Height = 28;
        _btnEdit.Click += BtnEdit_Click;

        // Buttons – row 2
        _btnOpenUser.Text = "Otevřít uživatele";
        _btnOpenUser.Left = lx; _btnOpenUser.Top = 324;
        _btnOpenUser.Width = 140; _btnOpenUser.Height = 28;
        _btnOpenUser.Click += BtnOpenUser_Click;

        _btnClose.Text = "Zavřít";
        _btnClose.Left = lx + 148; _btnClose.Top = 324;
        _btnClose.Width = 90; _btnClose.Height = 28;
        _btnClose.Click += BtnClose_Click;

        Controls.AddRange(new Control[] {
            lblFirma, _lblFirmaVal,
            lblEmail, _lblEmailVal,
            sep,
            lblOd, _lblOdVal,
            lblDo, _lblDoVal,
            lblVarSym, _lblVarSymVal,
            lblDatumObj, _lblDatumObjVal,
            lblZaplaceno, _lblZaplacenoVal,
            lblStav, _lblStavVal,
            _btnMarkPaid, _btnUnmarkPaid, _btnEdit, _btnOpenUser, _btnClose
        });

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(520, 364);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Detail předplatného";

        ResumeLayout(false);
    }

    private Button _btnMarkPaid = null!;
    private Button _btnUnmarkPaid = null!;
    private Button _btnEdit = null!;
    private Button _btnOpenUser = null!;
    private Button _btnClose = null!;
    private Label _lblFirmaVal = null!;
    private Label _lblEmailVal = null!;
    private Label _lblOdVal = null!;
    private Label _lblDoVal = null!;
    private Label _lblVarSymVal = null!;
    private Label _lblDatumObjVal = null!;
    private Label _lblZaplacenoVal = null!;
    private Label _lblStavVal = null!;
}
