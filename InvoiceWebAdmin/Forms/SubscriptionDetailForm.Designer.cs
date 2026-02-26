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
        _lblFirmaCaption = new Label();
        _lblFirmaVal = new Label();
        _lblEmailCaption = new Label();
        _lblEmailVal = new Label();
        _sep = new Label();
        _lblOdCaption = new Label();
        _lblOdVal = new Label();
        _lblDoCaption = new Label();
        _lblDoVal = new Label();
        _lblVarSymCaption = new Label();
        _lblVarSymVal = new Label();
        _lblDatumObjCaption = new Label();
        _lblDatumObjVal = new Label();
        _lblZaplacenoCaption = new Label();
        _lblZaplacenoVal = new Label();
        _lblStavCaption = new Label();
        _lblStavVal = new Label();
        _btnMarkPaid = new Button();
        _btnUnmarkPaid = new Button();
        _btnEdit = new Button();
        _btnOpenUser = new Button();
        _btnClose = new Button();
        SuspendLayout();

        // _lblFirmaCaption
        _lblFirmaCaption.Text = "Firma:";
        _lblFirmaCaption.Left = 12; _lblFirmaCaption.Top = 16; _lblFirmaCaption.Width = 160; _lblFirmaCaption.Height = 23;
        _lblFirmaCaption.TextAlign = ContentAlignment.MiddleRight;
        _lblFirmaCaption.Font = new Font(Font, FontStyle.Bold);

        // _lblFirmaVal
        _lblFirmaVal.Left = 180; _lblFirmaVal.Top = 16; _lblFirmaVal.Width = 320; _lblFirmaVal.Height = 23;
        _lblFirmaVal.TextAlign = ContentAlignment.MiddleLeft;

        // _lblEmailCaption
        _lblEmailCaption.Text = "E-mail:";
        _lblEmailCaption.Left = 12; _lblEmailCaption.Top = 46; _lblEmailCaption.Width = 160; _lblEmailCaption.Height = 23;
        _lblEmailCaption.TextAlign = ContentAlignment.MiddleRight;
        _lblEmailCaption.Font = new Font(Font, FontStyle.Bold);

        // _lblEmailVal
        _lblEmailVal.Left = 180; _lblEmailVal.Top = 46; _lblEmailVal.Width = 320; _lblEmailVal.Height = 23;
        _lblEmailVal.TextAlign = ContentAlignment.MiddleLeft;

        // _sep
        _sep.Left = 12; _sep.Top = 82; _sep.Width = 500; _sep.Height = 1;
        _sep.BorderStyle = BorderStyle.Fixed3D;

        // _lblOdCaption
        _lblOdCaption.Text = "Od:";
        _lblOdCaption.Left = 12; _lblOdCaption.Top = 92; _lblOdCaption.Width = 160; _lblOdCaption.Height = 23;
        _lblOdCaption.TextAlign = ContentAlignment.MiddleRight;
        _lblOdCaption.Font = new Font(Font, FontStyle.Bold);

        // _lblOdVal
        _lblOdVal.Left = 180; _lblOdVal.Top = 92; _lblOdVal.Width = 320; _lblOdVal.Height = 23;
        _lblOdVal.TextAlign = ContentAlignment.MiddleLeft;

        // _lblDoCaption
        _lblDoCaption.Text = "Do:";
        _lblDoCaption.Left = 12; _lblDoCaption.Top = 122; _lblDoCaption.Width = 160; _lblDoCaption.Height = 23;
        _lblDoCaption.TextAlign = ContentAlignment.MiddleRight;
        _lblDoCaption.Font = new Font(Font, FontStyle.Bold);

        // _lblDoVal
        _lblDoVal.Left = 180; _lblDoVal.Top = 122; _lblDoVal.Width = 320; _lblDoVal.Height = 23;
        _lblDoVal.TextAlign = ContentAlignment.MiddleLeft;

        // _lblVarSymCaption
        _lblVarSymCaption.Text = "Variabilní symbol:";
        _lblVarSymCaption.Left = 12; _lblVarSymCaption.Top = 152; _lblVarSymCaption.Width = 160; _lblVarSymCaption.Height = 23;
        _lblVarSymCaption.TextAlign = ContentAlignment.MiddleRight;
        _lblVarSymCaption.Font = new Font(Font, FontStyle.Bold);

        // _lblVarSymVal
        _lblVarSymVal.Left = 180; _lblVarSymVal.Top = 152; _lblVarSymVal.Width = 320; _lblVarSymVal.Height = 23;
        _lblVarSymVal.TextAlign = ContentAlignment.MiddleLeft;

        // _lblDatumObjCaption
        _lblDatumObjCaption.Text = "Datum objednávky:";
        _lblDatumObjCaption.Left = 12; _lblDatumObjCaption.Top = 182; _lblDatumObjCaption.Width = 160; _lblDatumObjCaption.Height = 23;
        _lblDatumObjCaption.TextAlign = ContentAlignment.MiddleRight;
        _lblDatumObjCaption.Font = new Font(Font, FontStyle.Bold);

        // _lblDatumObjVal
        _lblDatumObjVal.Left = 180; _lblDatumObjVal.Top = 182; _lblDatumObjVal.Width = 320; _lblDatumObjVal.Height = 23;
        _lblDatumObjVal.TextAlign = ContentAlignment.MiddleLeft;

        // _lblZaplacenoCaption
        _lblZaplacenoCaption.Text = "Zaplaceno:";
        _lblZaplacenoCaption.Left = 12; _lblZaplacenoCaption.Top = 212; _lblZaplacenoCaption.Width = 160; _lblZaplacenoCaption.Height = 23;
        _lblZaplacenoCaption.TextAlign = ContentAlignment.MiddleRight;
        _lblZaplacenoCaption.Font = new Font(Font, FontStyle.Bold);

        // _lblZaplacenoVal
        _lblZaplacenoVal.Left = 180; _lblZaplacenoVal.Top = 212; _lblZaplacenoVal.Width = 320; _lblZaplacenoVal.Height = 23;
        _lblZaplacenoVal.TextAlign = ContentAlignment.MiddleLeft;
        _lblZaplacenoVal.Font = new Font(Font, FontStyle.Bold);

        // _lblStavCaption
        _lblStavCaption.Text = "Stav:";
        _lblStavCaption.Left = 12; _lblStavCaption.Top = 242; _lblStavCaption.Width = 160; _lblStavCaption.Height = 23;
        _lblStavCaption.TextAlign = ContentAlignment.MiddleRight;
        _lblStavCaption.Font = new Font(Font, FontStyle.Bold);

        // _lblStavVal
        _lblStavVal.Left = 180; _lblStavVal.Top = 242; _lblStavVal.Width = 320; _lblStavVal.Height = 23;
        _lblStavVal.TextAlign = ContentAlignment.MiddleLeft;
        _lblStavVal.Font = new Font(Font, FontStyle.Bold);

        // _btnMarkPaid
        _btnMarkPaid.Text = "Označit jako zaplacené";
        _btnMarkPaid.Left = 12; _btnMarkPaid.Top = 288; _btnMarkPaid.Width = 160; _btnMarkPaid.Height = 28;
        _btnMarkPaid.Click += BtnMarkPaid_Click;

        // _btnUnmarkPaid
        _btnUnmarkPaid.Text = "Zrušit zaplacení";
        _btnUnmarkPaid.Left = 180; _btnUnmarkPaid.Top = 288; _btnUnmarkPaid.Width = 120; _btnUnmarkPaid.Height = 28;
        _btnUnmarkPaid.Click += BtnUnmarkPaid_Click;

        // _btnEdit
        _btnEdit.Text = "Upravit";
        _btnEdit.Left = 308; _btnEdit.Top = 288; _btnEdit.Width = 90; _btnEdit.Height = 28;
        _btnEdit.Click += BtnEdit_Click;

        // _btnOpenUser
        _btnOpenUser.Text = "Otevřít uživatele";
        _btnOpenUser.Left = 12; _btnOpenUser.Top = 324; _btnOpenUser.Width = 140; _btnOpenUser.Height = 28;
        _btnOpenUser.Click += BtnOpenUser_Click;

        // _btnClose
        _btnClose.Text = "Zavřít";
        _btnClose.Left = 160; _btnClose.Top = 324; _btnClose.Width = 90; _btnClose.Height = 28;
        _btnClose.Click += BtnClose_Click;

        Controls.AddRange(new Control[] {
            _lblFirmaCaption, _lblFirmaVal,
            _lblEmailCaption, _lblEmailVal,
            _sep,
            _lblOdCaption, _lblOdVal,
            _lblDoCaption, _lblDoVal,
            _lblVarSymCaption, _lblVarSymVal,
            _lblDatumObjCaption, _lblDatumObjVal,
            _lblZaplacenoCaption, _lblZaplacenoVal,
            _lblStavCaption, _lblStavVal,
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

    private Label _lblFirmaCaption = null!;
    private Label _lblFirmaVal = null!;
    private Label _lblEmailCaption = null!;
    private Label _lblEmailVal = null!;
    private Label _sep = null!;
    private Label _lblOdCaption = null!;
    private Label _lblOdVal = null!;
    private Label _lblDoCaption = null!;
    private Label _lblDoVal = null!;
    private Label _lblVarSymCaption = null!;
    private Label _lblVarSymVal = null!;
    private Label _lblDatumObjCaption = null!;
    private Label _lblDatumObjVal = null!;
    private Label _lblZaplacenoCaption = null!;
    private Label _lblZaplacenoVal = null!;
    private Label _lblStavCaption = null!;
    private Label _lblStavVal = null!;
    private Button _btnMarkPaid = null!;
    private Button _btnUnmarkPaid = null!;
    private Button _btnEdit = null!;
    private Button _btnOpenUser = null!;
    private Button _btnClose = null!;
}
