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
        _sep1 = new Label();
        _lblOdCaption = new Label();
        _dtFrom = new DateTimePicker();
        _lblDoCaption = new Label();
        _dtTo = new DateTimePicker();
        _lblVarSymCaption = new Label();
        _txtVarSym = new TextBox();
        _lblDatumObjCaption = new Label();
        _dtObjednavky = new DateTimePicker();
        _lblNoteCaption = new Label();
        _txtNote = new TextBox();
        _sep2 = new Label();
        _lblZaplacenoCaption = new Label();
        _lblZaplacenoVal = new Label();
        _lblStavCaption = new Label();
        _lblStavVal = new Label();
        _sep3 = new Label();
        _btnSave = new Button();
        _btnMarkPaid = new Button();
        _btnUnmarkPaid = new Button();
        _btnOpenUser = new Button();
        _btnClose = new Button();
        SuspendLayout();

        // _lblFirmaCaption
        _lblFirmaCaption.Text = "Firma:";
        _lblFirmaCaption.Left = 12; _lblFirmaCaption.Top = 16; _lblFirmaCaption.Width = 160; _lblFirmaCaption.Height = 23;
        _lblFirmaCaption.TextAlign = ContentAlignment.MiddleRight;
        _lblFirmaCaption.Font = new Font(Font, FontStyle.Bold);

        // _lblFirmaVal
        _lblFirmaVal.Left = 180; _lblFirmaVal.Top = 16; _lblFirmaVal.Width = 310; _lblFirmaVal.Height = 23;
        _lblFirmaVal.TextAlign = ContentAlignment.MiddleLeft;

        // _lblEmailCaption
        _lblEmailCaption.Text = "E-mail:";
        _lblEmailCaption.Left = 12; _lblEmailCaption.Top = 46; _lblEmailCaption.Width = 160; _lblEmailCaption.Height = 23;
        _lblEmailCaption.TextAlign = ContentAlignment.MiddleRight;
        _lblEmailCaption.Font = new Font(Font, FontStyle.Bold);

        // _lblEmailVal
        _lblEmailVal.Left = 180; _lblEmailVal.Top = 46; _lblEmailVal.Width = 310; _lblEmailVal.Height = 23;
        _lblEmailVal.TextAlign = ContentAlignment.MiddleLeft;

        // _sep1
        _sep1.Left = 12; _sep1.Top = 78; _sep1.Width = 490; _sep1.Height = 1;
        _sep1.BorderStyle = BorderStyle.Fixed3D;

        // _lblOdCaption
        _lblOdCaption.Text = "Od:";
        _lblOdCaption.Left = 12; _lblOdCaption.Top = 92; _lblOdCaption.Width = 160; _lblOdCaption.Height = 23;
        _lblOdCaption.TextAlign = ContentAlignment.MiddleRight;
        _lblOdCaption.Font = new Font(Font, FontStyle.Bold);

        // _dtFrom
        _dtFrom.Left = 180; _dtFrom.Top = 92; _dtFrom.Width = 180;
        _dtFrom.Format = DateTimePickerFormat.Short;

        // _lblDoCaption
        _lblDoCaption.Text = "Do:";
        _lblDoCaption.Left = 12; _lblDoCaption.Top = 126; _lblDoCaption.Width = 160; _lblDoCaption.Height = 23;
        _lblDoCaption.TextAlign = ContentAlignment.MiddleRight;
        _lblDoCaption.Font = new Font(Font, FontStyle.Bold);

        // _dtTo
        _dtTo.Left = 180; _dtTo.Top = 126; _dtTo.Width = 180;
        _dtTo.Format = DateTimePickerFormat.Short;

        // _lblVarSymCaption
        _lblVarSymCaption.Text = "Variabilní symbol:";
        _lblVarSymCaption.Left = 12; _lblVarSymCaption.Top = 160; _lblVarSymCaption.Width = 160; _lblVarSymCaption.Height = 23;
        _lblVarSymCaption.TextAlign = ContentAlignment.MiddleRight;
        _lblVarSymCaption.Font = new Font(Font, FontStyle.Bold);

        // _txtVarSym
        _txtVarSym.Left = 180; _txtVarSym.Top = 160; _txtVarSym.Width = 200;
        _txtVarSym.MaxLength = 50;

        // _lblDatumObjCaption
        _lblDatumObjCaption.Text = "Datum objednávky:";
        _lblDatumObjCaption.Left = 12; _lblDatumObjCaption.Top = 194; _lblDatumObjCaption.Width = 160; _lblDatumObjCaption.Height = 23;
        _lblDatumObjCaption.TextAlign = ContentAlignment.MiddleRight;
        _lblDatumObjCaption.Font = new Font(Font, FontStyle.Bold);

        // _dtObjednavky
        _dtObjednavky.Left = 180; _dtObjednavky.Top = 192; _dtObjednavky.Width = 200;
        _dtObjednavky.Format = DateTimePickerFormat.Short;

        // _lblNoteCaption
        _lblNoteCaption.Text = "Poznámka:";
        _lblNoteCaption.Left = 12; _lblNoteCaption.Top = 228; _lblNoteCaption.Width = 160; _lblNoteCaption.Height = 23;
        _lblNoteCaption.TextAlign = ContentAlignment.MiddleRight;
        _lblNoteCaption.Font = new Font(Font, FontStyle.Bold);

        // _txtNote
        _txtNote.Left = 180; _txtNote.Top = 228; _txtNote.Width = 310;

        // _sep2
        _sep2.Left = 12; _sep2.Top = 262; _sep2.Width = 490; _sep2.Height = 1;
        _sep2.BorderStyle = BorderStyle.Fixed3D;

        // _lblZaplacenoCaption
        _lblZaplacenoCaption.Text = "Zaplaceno:";
        _lblZaplacenoCaption.Left = 12; _lblZaplacenoCaption.Top = 272; _lblZaplacenoCaption.Width = 160; _lblZaplacenoCaption.Height = 23;
        _lblZaplacenoCaption.TextAlign = ContentAlignment.MiddleRight;
        _lblZaplacenoCaption.Font = new Font(Font, FontStyle.Bold);

        // _lblZaplacenoVal
        _lblZaplacenoVal.Left = 180; _lblZaplacenoVal.Top = 272; _lblZaplacenoVal.Width = 310; _lblZaplacenoVal.Height = 23;
        _lblZaplacenoVal.TextAlign = ContentAlignment.MiddleLeft;
        _lblZaplacenoVal.Font = new Font(Font, FontStyle.Bold);

        // _lblStavCaption
        _lblStavCaption.Text = "Stav:";
        _lblStavCaption.Left = 12; _lblStavCaption.Top = 302; _lblStavCaption.Width = 160; _lblStavCaption.Height = 23;
        _lblStavCaption.TextAlign = ContentAlignment.MiddleRight;
        _lblStavCaption.Font = new Font(Font, FontStyle.Bold);

        // _lblStavVal
        _lblStavVal.Left = 180; _lblStavVal.Top = 302; _lblStavVal.Width = 310; _lblStavVal.Height = 23;
        _lblStavVal.TextAlign = ContentAlignment.MiddleLeft;
        _lblStavVal.Font = new Font(Font, FontStyle.Bold);

        // _sep3
        _sep3.Left = 12; _sep3.Top = 334; _sep3.Width = 490; _sep3.Height = 1;
        _sep3.BorderStyle = BorderStyle.Fixed3D;

        // _btnSave
        _btnSave.Text = "Uložit";
        _btnSave.Left = 12; _btnSave.Top = 344; _btnSave.Width = 80; _btnSave.Height = 28;
        _btnSave.Click += BtnSave_Click;

        // _btnMarkPaid
        _btnMarkPaid.Text = "Označit jako zaplacené";
        _btnMarkPaid.Left = 100; _btnMarkPaid.Top = 344; _btnMarkPaid.Width = 160; _btnMarkPaid.Height = 28;
        _btnMarkPaid.Click += BtnMarkPaid_Click;

        // _btnUnmarkPaid
        _btnUnmarkPaid.Text = "Zrušit zaplacení";
        _btnUnmarkPaid.Left = 268; _btnUnmarkPaid.Top = 344; _btnUnmarkPaid.Width = 120; _btnUnmarkPaid.Height = 28;
        _btnUnmarkPaid.Click += BtnUnmarkPaid_Click;

        // _btnOpenUser
        _btnOpenUser.Text = "Otevřít uživatele";
        _btnOpenUser.Left = 12; _btnOpenUser.Top = 380; _btnOpenUser.Width = 140; _btnOpenUser.Height = 28;
        _btnOpenUser.Click += BtnOpenUser_Click;

        // _btnClose
        _btnClose.Text = "Zavřít";
        _btnClose.Left = 160; _btnClose.Top = 380; _btnClose.Width = 90; _btnClose.Height = 28;
        _btnClose.Click += BtnClose_Click;

        Controls.AddRange(new Control[] {
            _lblFirmaCaption, _lblFirmaVal,
            _lblEmailCaption, _lblEmailVal,
            _sep1,
            _lblOdCaption, _dtFrom,
            _lblDoCaption, _dtTo,
            _lblVarSymCaption, _txtVarSym,
            _lblDatumObjCaption, _dtObjednavky,
            _lblNoteCaption, _txtNote,
            _sep2,
            _lblZaplacenoCaption, _lblZaplacenoVal,
            _lblStavCaption, _lblStavVal,
            _sep3,
            _btnSave, _btnMarkPaid, _btnUnmarkPaid, _btnOpenUser, _btnClose
        });

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(520, 420);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Detail předplatného";

        ResumeLayout(false);
        PerformLayout();
    }

    private Label _lblFirmaCaption = null!;
    private Label _lblFirmaVal = null!;
    private Label _lblEmailCaption = null!;
    private Label _lblEmailVal = null!;
    private Label _sep1 = null!;
    private Label _lblOdCaption = null!;
    private DateTimePicker _dtFrom = null!;
    private Label _lblDoCaption = null!;
    private DateTimePicker _dtTo = null!;
    private Label _lblVarSymCaption = null!;
    private TextBox _txtVarSym = null!;
    private Label _lblDatumObjCaption = null!;
    private DateTimePicker _dtObjednavky = null!;
    private Label _lblNoteCaption = null!;
    private TextBox _txtNote = null!;
    private Label _sep2 = null!;
    private Label _lblZaplacenoCaption = null!;
    private Label _lblZaplacenoVal = null!;
    private Label _lblStavCaption = null!;
    private Label _lblStavVal = null!;
    private Label _sep3 = null!;
    private Button _btnSave = null!;
    private Button _btnMarkPaid = null!;
    private Button _btnUnmarkPaid = null!;
    private Button _btnOpenUser = null!;
    private Button _btnClose = null!;
}
