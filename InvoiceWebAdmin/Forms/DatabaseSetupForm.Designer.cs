namespace InvoiceWebAdmin.Forms;

partial class DatabaseSetupForm
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
        _outer = new TableLayoutPanel();
        _pathRow = new TableLayoutPanel();
        _btnRow = new FlowLayoutPanel();
        _lblInfo = new Label();
        _txtPath = new TextBox();
        _btnBrowse = new Button();
        _lblStatus = new Label();
        _btnTest = new Button();
        _btnOk = new Button();
        _btnCancel = new Button();
        _outer.SuspendLayout();
        _pathRow.SuspendLayout();
        _btnRow.SuspendLayout();
        SuspendLayout();

        // _outer
        _outer.Dock = DockStyle.Fill;
        _outer.Padding = new Padding(12);
        _outer.RowCount = 5; _outer.ColumnCount = 1;
        _outer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _outer.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        _outer.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        _outer.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        _outer.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        _outer.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _outer.Controls.Add(_lblInfo, 0, 0);
        _outer.Controls.Add(_pathRow, 0, 1);
        _outer.Controls.Add(_lblStatus, 0, 2);
        _outer.Controls.Add(_btnTest, 0, 3);
        _outer.Controls.Add(_btnRow, 0, 4);

        // _lblInfo
        _lblInfo.Text = "Databáze nebyla nalezena. Zadejte cestu k souboru invoice.db:";
        _lblInfo.Dock = DockStyle.Fill;
        _lblInfo.AutoSize = true;
        _lblInfo.Padding = new Padding(0, 0, 0, 6);

        // _pathRow
        _pathRow.Dock = DockStyle.Fill;
        _pathRow.ColumnCount = 2; _pathRow.RowCount = 1;
        _pathRow.AutoSize = true;
        _pathRow.Margin = new Padding(0, 0, 0, 6);
        _pathRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _pathRow.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        _pathRow.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        _pathRow.Controls.Add(_txtPath, 0, 0);
        _pathRow.Controls.Add(_btnBrowse, 1, 0);

        // _txtPath
        _txtPath.Dock = DockStyle.Fill;

        // _btnBrowse
        _btnBrowse.Text = "Procházet…";
        _btnBrowse.AutoSize = true;
        _btnBrowse.Margin = new Padding(6, 0, 0, 0);
        _btnBrowse.Click += Browse;

        // _lblStatus
        _lblStatus.Dock = DockStyle.Fill;
        _lblStatus.AutoSize = true;
        _lblStatus.ForeColor = Color.Gray;
        _lblStatus.Padding = new Padding(0, 0, 0, 6);

        // _btnTest
        _btnTest.Text = "Otestovat připojení";
        _btnTest.AutoSize = true;
        _btnTest.Margin = new Padding(0, 0, 0, 12);
        _btnTest.Click += TestConnection;

        // _btnRow
        _btnRow.Dock = DockStyle.Fill;
        _btnRow.FlowDirection = FlowDirection.RightToLeft;
        _btnRow.AutoSize = true;
        _btnRow.WrapContents = false;
        _btnRow.Controls.Add(_btnCancel);
        _btnRow.Controls.Add(_btnOk);

        // _btnCancel
        _btnCancel.Text = "Zrušit";
        _btnCancel.DialogResult = DialogResult.Cancel;
        _btnCancel.AutoSize = true;
        _btnCancel.Margin = new Padding(0);

        // _btnOk
        _btnOk.Text = "Uložit a spustit";
        _btnOk.DialogResult = DialogResult.OK;
        _btnOk.Enabled = false;
        _btnOk.AutoSize = true;
        _btnOk.Margin = new Padding(0, 0, 6, 0);

        // DatabaseSetupForm
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Text = "Nastavení cesty k databázi";
        MinimumSize = new Size(500, 240);
        ClientSize = new Size(580, 220);
        FormBorderStyle = FormBorderStyle.Sizable;
        MaximizeBox = false; MinimizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        AcceptButton = _btnOk;
        CancelButton = _btnCancel;
        Controls.Add(_outer);

        _outer.ResumeLayout(false);
        _outer.PerformLayout();
        _pathRow.ResumeLayout(false);
        _pathRow.PerformLayout();
        _btnRow.ResumeLayout(false);
        _btnRow.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    private TableLayoutPanel _outer = null!;
    private TableLayoutPanel _pathRow = null!;
    private FlowLayoutPanel _btnRow = null!;
    private Label _lblInfo = null!;
    private TextBox _txtPath = null!;
    private Button _btnBrowse = null!;
    private Label _lblStatus = null!;
    private Button _btnTest = null!;
    private Button _btnOk = null!;
    private Button _btnCancel = null!;
}
