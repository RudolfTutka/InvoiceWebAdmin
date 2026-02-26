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
        _btnOk = new Button();
        _btnCancel = new Button();
        var lblFrom = new Label();
        var lblTo = new Label();
        var lblNote = new Label();
        SuspendLayout();

        int lw = 110, cx = 140, fw = 200;

        // lblFrom
        lblFrom.Text = "Od:";
        lblFrom.Left = 12; lblFrom.Top = 20;
        lblFrom.Width = lw; lblFrom.Height = 23;
        lblFrom.TextAlign = ContentAlignment.MiddleRight;

        // _dtFrom
        _dtFrom.Left = cx; _dtFrom.Top = 20; _dtFrom.Width = fw;
        _dtFrom.Format = DateTimePickerFormat.Short;

        // lblTo
        lblTo.Text = "Do:";
        lblTo.Left = 12; lblTo.Top = 56;
        lblTo.Width = lw; lblTo.Height = 23;
        lblTo.TextAlign = ContentAlignment.MiddleRight;

        // _dtTo
        _dtTo.Left = cx; _dtTo.Top = 56; _dtTo.Width = fw;
        _dtTo.Format = DateTimePickerFormat.Short;

        // lblNote
        lblNote.Text = "Poznámka:";
        lblNote.Left = 12; lblNote.Top = 92;
        lblNote.Width = lw; lblNote.Height = 23;
        lblNote.TextAlign = ContentAlignment.MiddleRight;

        // _txtNote
        _txtNote.Left = cx; _txtNote.Top = 92; _txtNote.Width = fw;

        // _btnOk
        _btnOk.Text = "Uložit";
        _btnOk.Left = cx; _btnOk.Top = 132; _btnOk.Width = 90;
        _btnOk.DialogResult = DialogResult.OK;
        _btnOk.Click += Save;

        // _btnCancel
        _btnCancel.Text = "Zrušit";
        _btnCancel.Left = cx + 98; _btnCancel.Top = 132; _btnCancel.Width = 90;
        _btnCancel.DialogResult = DialogResult.Cancel;

        // PeriodEditForm
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(360, 176);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false; MinimizeBox = false;
        StartPosition = FormStartPosition.CenterParent;
        AcceptButton = _btnOk;
        CancelButton = _btnCancel;
        Controls.AddRange(new Control[] { lblFrom, _dtFrom, lblTo, _dtTo, lblNote, _txtNote, _btnOk, _btnCancel });

        ResumeLayout(false);
        PerformLayout();
    }

    private DateTimePicker _dtFrom = null!;
    private DateTimePicker _dtTo = null!;
    private TextBox _txtNote = null!;
    private Button _btnOk = null!;
    private Button _btnCancel = null!;
}
