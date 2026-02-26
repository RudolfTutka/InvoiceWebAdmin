namespace InvoiceWebAdmin.Forms;

partial class PeriodEditForm
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
        _dtFrom = new DateTimePicker();
        _dtTo = new DateTimePicker();
        _txtNote = new TextBox();
        _txtVariabilniSymbol = new TextBox();
        _dtObjednavky = new DateTimePicker();
        _btnOk = new Button();
        _btnCancel = new Button();
        lblFrom = new Label();
        lblTo = new Label();
        lblNote = new Label();
        lblVariabilniSymbol = new Label();
        lblDatumObjednavky = new Label();
        SuspendLayout();
        // 
        // _dtFrom
        // 
        _dtFrom.Format = DateTimePickerFormat.Short;
        _dtFrom.Location = new Point(148, 20);
        _dtFrom.Name = "_dtFrom";
        _dtFrom.Size = new Size(210, 23);
        _dtFrom.TabIndex = 1;
        // 
        // _dtTo
        // 
        _dtTo.Format = DateTimePickerFormat.Short;
        _dtTo.Location = new Point(148, 56);
        _dtTo.Name = "_dtTo";
        _dtTo.Size = new Size(210, 23);
        _dtTo.TabIndex = 3;
        // 
        // _txtNote
        // 
        _txtNote.Location = new Point(148, 92);
        _txtNote.Name = "_txtNote";
        _txtNote.Size = new Size(210, 23);
        _txtNote.TabIndex = 5;
        // 
        // _txtVariabilniSymbol
        // 
        _txtVariabilniSymbol.Location = new Point(148, 128);
        _txtVariabilniSymbol.MaxLength = 50;
        _txtVariabilniSymbol.Name = "_txtVariabilniSymbol";
        _txtVariabilniSymbol.Size = new Size(210, 23);
        _txtVariabilniSymbol.TabIndex = 7;
        // 
        // _dtObjednavky
        // 
        _dtObjednavky.Checked = false;
        _dtObjednavky.CustomFormat = "d.M.yyyy";
        _dtObjednavky.Format = DateTimePickerFormat.Custom;
        _dtObjednavky.Location = new Point(148, 161);
        _dtObjednavky.Name = "_dtObjednavky";
        _dtObjednavky.ShowCheckBox = true;
        _dtObjednavky.Size = new Size(210, 23);
        _dtObjednavky.TabIndex = 9;
        // 
        // _btnOk
        // 
        _btnOk.DialogResult = DialogResult.OK;
        _btnOk.Location = new Point(148, 208);
        _btnOk.Name = "_btnOk";
        _btnOk.Size = new Size(90, 23);
        _btnOk.TabIndex = 10;
        _btnOk.Text = "Uložit";
        _btnOk.Click += Save;
        // 
        // _btnCancel
        // 
        _btnCancel.DialogResult = DialogResult.Cancel;
        _btnCancel.Location = new Point(148, 208);
        _btnCancel.Name = "_btnCancel";
        _btnCancel.Size = new Size(90, 23);
        _btnCancel.TabIndex = 11;
        _btnCancel.Text = "Zrušit";
        // 
        // lblFrom
        // 
        lblFrom.Location = new Point(12, 20);
        lblFrom.Name = "lblFrom";
        lblFrom.Size = new Size(130, 23);
        lblFrom.TabIndex = 0;
        lblFrom.Text = "Od:";
        lblFrom.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblTo
        // 
        lblTo.Location = new Point(12, 56);
        lblTo.Name = "lblTo";
        lblTo.Size = new Size(130, 23);
        lblTo.TabIndex = 2;
        lblTo.Text = "Do:";
        lblTo.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblNote
        // 
        lblNote.Location = new Point(12, 92);
        lblNote.Name = "lblNote";
        lblNote.Size = new Size(130, 23);
        lblNote.TabIndex = 4;
        lblNote.Text = "Poznámka:";
        lblNote.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblVariabilniSymbol
        // 
        lblVariabilniSymbol.Location = new Point(12, 128);
        lblVariabilniSymbol.Name = "lblVariabilniSymbol";
        lblVariabilniSymbol.Size = new Size(130, 23);
        lblVariabilniSymbol.TabIndex = 6;
        lblVariabilniSymbol.Text = "Variabilní symbol:";
        lblVariabilniSymbol.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblDatumObjednavky
        // 
        lblDatumObjednavky.Location = new Point(12, 164);
        lblDatumObjednavky.Name = "lblDatumObjednavky";
        lblDatumObjednavky.Size = new Size(130, 23);
        lblDatumObjednavky.TabIndex = 8;
        lblDatumObjednavky.Text = "Datum objednávky:";
        lblDatumObjednavky.TextAlign = ContentAlignment.MiddleRight;
        // 
        // PeriodEditForm
        // 
        AcceptButton = _btnOk;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = _btnCancel;
        ClientSize = new Size(380, 252);
        Controls.Add(lblFrom);
        Controls.Add(_dtFrom);
        Controls.Add(lblTo);
        Controls.Add(_dtTo);
        Controls.Add(lblNote);
        Controls.Add(_txtNote);
        Controls.Add(lblVariabilniSymbol);
        Controls.Add(_txtVariabilniSymbol);
        Controls.Add(lblDatumObjednavky);
        Controls.Add(_dtObjednavky);
        Controls.Add(_btnOk);
        Controls.Add(_btnCancel);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "PeriodEditForm";
        StartPosition = FormStartPosition.CenterParent;
        ResumeLayout(false);
        PerformLayout();
    }

    private DateTimePicker _dtFrom = null!;
    private DateTimePicker _dtTo = null!;
    private TextBox _txtNote = null!;
    private TextBox _txtVariabilniSymbol = null!;
    private DateTimePicker _dtObjednavky = null!;
    private Button _btnOk = null!;
    private Button _btnCancel = null!;
    private Label lblFrom;
    private Label lblTo;
    private Label lblNote;
    private Label lblVariabilniSymbol;
    private Label lblDatumObjednavky;
}
