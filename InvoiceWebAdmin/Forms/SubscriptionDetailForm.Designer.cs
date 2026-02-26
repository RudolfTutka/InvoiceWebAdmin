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

        const int lx = 12, lw = 160, cx = 180, vw = 320, rowH = 30;

        // Helper to create a right-aligned label
        void AddLabel(Control parent, string text, int y)
        {
            var lbl = new Label
            {
                Text = text, Left = lx, Top = y,
                Width = lw, Height = 23,
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font(Font, FontStyle.Bold)
            };
            parent.Controls.Add(lbl);
        }

        int y = 16;

        // Firma
        AddLabel(this, "Firma:", y);
        _lblFirmaVal.Left = cx; _lblFirmaVal.Top = y; _lblFirmaVal.Width = vw; _lblFirmaVal.Height = 23;
        _lblFirmaVal.TextAlign = ContentAlignment.MiddleLeft;
        y += rowH;

        // Email
        AddLabel(this, "E-mail:", y);
        _lblEmailVal.Left = cx; _lblEmailVal.Top = y; _lblEmailVal.Width = vw; _lblEmailVal.Height = 23;
        _lblEmailVal.TextAlign = ContentAlignment.MiddleLeft;
        y += rowH + 6;

        // Separator
        var sep = new Label { Left = lx, Top = y, Width = cx + vw, Height = 1, BorderStyle = BorderStyle.Fixed3D };
        Controls.Add(sep);
        y += 10;

        // Od
        AddLabel(this, "Od:", y);
        _lblOdVal.Left = cx; _lblOdVal.Top = y; _lblOdVal.Width = vw; _lblOdVal.Height = 23;
        _lblOdVal.TextAlign = ContentAlignment.MiddleLeft;
        y += rowH;

        // Do
        AddLabel(this, "Do:", y);
        _lblDoVal.Left = cx; _lblDoVal.Top = y; _lblDoVal.Width = vw; _lblDoVal.Height = 23;
        _lblDoVal.TextAlign = ContentAlignment.MiddleLeft;
        y += rowH;

        // Var. symbol
        AddLabel(this, "Variabilní symbol:", y);
        _lblVarSymVal.Left = cx; _lblVarSymVal.Top = y; _lblVarSymVal.Width = vw; _lblVarSymVal.Height = 23;
        _lblVarSymVal.TextAlign = ContentAlignment.MiddleLeft;
        y += rowH;

        // Datum obj.
        AddLabel(this, "Datum objednávky:", y);
        _lblDatumObjVal.Left = cx; _lblDatumObjVal.Top = y; _lblDatumObjVal.Width = vw; _lblDatumObjVal.Height = 23;
        _lblDatumObjVal.TextAlign = ContentAlignment.MiddleLeft;
        y += rowH;

        // Zaplaceno
        AddLabel(this, "Zaplaceno:", y);
        _lblZaplacenoVal.Left = cx; _lblZaplacenoVal.Top = y; _lblZaplacenoVal.Width = vw; _lblZaplacenoVal.Height = 23;
        _lblZaplacenoVal.TextAlign = ContentAlignment.MiddleLeft;
        _lblZaplacenoVal.Font = new Font(Font, FontStyle.Bold);
        y += rowH;

        // Stav
        AddLabel(this, "Stav:", y);
        _lblStavVal.Left = cx; _lblStavVal.Top = y; _lblStavVal.Width = vw; _lblStavVal.Height = 23;
        _lblStavVal.TextAlign = ContentAlignment.MiddleLeft;
        _lblStavVal.Font = new Font(Font, FontStyle.Bold);
        y += rowH + 16;

        // Buttons
        _btnMarkPaid.Text = "Označit jako zaplacené";
        _btnMarkPaid.Left = lx; _btnMarkPaid.Top = y;
        _btnMarkPaid.Width = 170; _btnMarkPaid.Height = 28;
        _btnMarkPaid.Click += BtnMarkPaid_Click;

        _btnOpenUser.Text = "Otevřít uživatele";
        _btnOpenUser.Left = lx + 178; _btnOpenUser.Top = y;
        _btnOpenUser.Width = 140; _btnOpenUser.Height = 28;
        _btnOpenUser.Click += BtnOpenUser_Click;

        _btnClose.Text = "Zavřít";
        _btnClose.Left = lx + 326; _btnClose.Top = y;
        _btnClose.Width = 90; _btnClose.Height = 28;
        _btnClose.Click += BtnClose_Click;

        y += 40;

        // Add value labels
        Controls.AddRange(new Control[] {
            _lblFirmaVal, _lblEmailVal,
            _lblOdVal, _lblDoVal, _lblVarSymVal, _lblDatumObjVal, _lblZaplacenoVal, _lblStavVal,
            _btnMarkPaid, _btnOpenUser, _btnClose
        });

        // SubscriptionDetailForm
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(520, y);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Detail předplatného";

        ResumeLayout(false);
    }

    private Button _btnMarkPaid = null!;
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
