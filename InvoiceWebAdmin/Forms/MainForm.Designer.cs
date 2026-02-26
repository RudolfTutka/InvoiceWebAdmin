namespace InvoiceWebAdmin.Forms;

partial class MainForm
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
        _toolbar = new Panel();
        _lblSearch = new Label();
        _searchBox = new TextBox();
        _btnDetail = new Button();
        _btnDelete = new Button();
        _btnSettings = new Button();
        _grid = new DataGridView();
        var colId = new DataGridViewTextBoxColumn();
        var colFirma = new DataGridViewTextBoxColumn();
        var colIco = new DataGridViewTextBoxColumn();
        var colEmail = new DataGridViewTextBoxColumn();
        var colStav = new DataGridViewTextBoxColumn();
        var colPlatnyDo = new DataGridViewTextBoxColumn();
        var colRegistrace = new DataGridViewTextBoxColumn();
        _toolbar.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_grid).BeginInit();
        SuspendLayout();

        // _lblSearch
        _lblSearch.Text = "Hledat:";
        _lblSearch.AutoSize = true;
        _lblSearch.Left = 0; _lblSearch.Top = 12;

        // _searchBox
        _searchBox.Left = 55; _searchBox.Top = 8; _searchBox.Width = 220;
        _searchBox.TextChanged += SearchBox_TextChanged;

        // _btnDetail
        _btnDetail.Text = "Detail / Upravit";
        _btnDetail.Left = 290; _btnDetail.Top = 6; _btnDetail.Width = 130; _btnDetail.Enabled = false;
        _btnDetail.Click += BtnDetail_Click;

        // _btnDelete
        _btnDelete.Text = "Smazat";
        _btnDelete.Left = 430; _btnDelete.Top = 6; _btnDelete.Width = 90; _btnDelete.Enabled = false;
        _btnDelete.Click += BtnDelete_Click;

        // _btnSettings
        _btnSettings.Text = "Nastavení";
        _btnSettings.Left = 540; _btnSettings.Top = 6; _btnSettings.Width = 100;
        _btnSettings.Click += BtnSettings_Click;

        // _toolbar
        _toolbar.Dock = DockStyle.Top; _toolbar.Height = 44;
        _toolbar.Padding = new Padding(8, 6, 8, 6);
        _toolbar.Controls.AddRange(new Control[] { _lblSearch, _searchBox, _btnDetail, _btnDelete, _btnSettings });

        // columns
        colId.Name = "colId"; colId.HeaderText = "ID"; colId.FillWeight = 30;
        colFirma.Name = "colFirma"; colFirma.HeaderText = "Firma";
        colIco.Name = "colIco"; colIco.HeaderText = "IČO"; colIco.FillWeight = 60;
        colEmail.Name = "colEmail"; colEmail.HeaderText = "E-mail";
        colStav.Name = "colStav"; colStav.HeaderText = "Stav"; colStav.FillWeight = 70;
        colPlatnyDo.Name = "colPlatnyDo"; colPlatnyDo.HeaderText = "Platné do"; colPlatnyDo.FillWeight = 70;
        colRegistrace.Name = "colRegistrace"; colRegistrace.HeaderText = "Registrace"; colRegistrace.FillWeight = 70;

        // _grid
        _grid.Dock = DockStyle.Fill;
        _grid.ReadOnly = true;
        _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        _grid.MultiSelect = false;
        _grid.AllowUserToAddRows = false;
        _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _grid.RowHeadersVisible = false;
        _grid.BackgroundColor = SystemColors.Window;
        _grid.Columns.AddRange(colId, colFirma, colIco, colEmail, colStav, colPlatnyDo, colRegistrace);
        _grid.SelectionChanged += Grid_SelectionChanged;
        _grid.CellDoubleClick += Grid_CellDoubleClick;

        // MainForm
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Text = "InvoiceWeb Admin";
        ClientSize = new Size(984, 561);
        StartPosition = FormStartPosition.CenterScreen;
        Controls.Add(_grid);
        Controls.Add(_toolbar);

        _toolbar.ResumeLayout(false);
        _toolbar.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Panel _toolbar = null!;
    private Label _lblSearch = null!;
    private TextBox _searchBox = null!;
    private Button _btnDetail = null!;
    private Button _btnDelete = null!;
    private Button _btnSettings = null!;
    private DataGridView _grid = null!;
}
