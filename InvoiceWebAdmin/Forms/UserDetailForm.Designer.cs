namespace InvoiceWebAdmin.Forms;

partial class UserDetailForm
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
        _tabs = new TabControl();
        var tabInfo = new TabPage();
        var tabSubs = new TabPage();
        _txtEmail = new TextBox();
        _txtCompanyName = new TextBox();
        _txtIco = new TextBox();
        _txtDic = new TextBox();
        _chkActive = new CheckBox();
        _txtNewPassword = new TextBox();
        _txtConfirmPassword = new TextBox();
        _lblRegistrace = new Label();
        _lblTrialDo = new Label();
        var subsToolbar = new Panel();
        _btnAddPeriod = new Button();
        _btnEditPeriod = new Button();
        _btnDeletePeriod = new Button();
        _gridSubs = new DataGridView();
        var colFrom = new DataGridViewTextBoxColumn();
        var colTo = new DataGridViewTextBoxColumn();
        var colNote = new DataGridViewTextBoxColumn();
        var colCreated = new DataGridViewTextBoxColumn();
        _tabs.SuspendLayout();
        tabInfo.SuspendLayout();
        tabSubs.SuspendLayout();
        subsToolbar.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_gridSubs).BeginInit();
        SuspendLayout();

        int lw = 140, cx = 168, fw = 300;

        // tabInfo controls
        var lblEmail = new Label { Text = "E-mail:", Left = 12, Top = 20, Width = lw, Height = 23, TextAlign = ContentAlignment.MiddleRight };
        _txtEmail.Left = cx; _txtEmail.Top = 20; _txtEmail.Width = fw;

        var lblCompany = new Label { Text = "Název firmy:", Left = 12, Top = 52, Width = lw, Height = 23, TextAlign = ContentAlignment.MiddleRight };
        _txtCompanyName.Left = cx; _txtCompanyName.Top = 52; _txtCompanyName.Width = fw;

        var lblIco = new Label { Text = "IČO:", Left = 12, Top = 84, Width = lw, Height = 23, TextAlign = ContentAlignment.MiddleRight };
        _txtIco.Left = cx; _txtIco.Top = 84; _txtIco.Width = fw;

        var lblDic = new Label { Text = "DIČ:", Left = 12, Top = 116, Width = lw, Height = 23, TextAlign = ContentAlignment.MiddleRight };
        _txtDic.Left = cx; _txtDic.Top = 116; _txtDic.Width = fw;

        _chkActive.Text = "Uživatel je aktivní";
        _chkActive.Left = cx; _chkActive.Top = 148; _chkActive.AutoSize = true;

        var lblSepPass = new Label { Text = "──── Změna hesla ────", Left = 12, Top = 188, Width = 420, Font = new Font(Font, FontStyle.Italic) };

        var lblNewPass = new Label { Text = "Nové heslo:", Left = 12, Top = 216, Width = lw, Height = 23, TextAlign = ContentAlignment.MiddleRight };
        _txtNewPassword.Left = cx; _txtNewPassword.Top = 216; _txtNewPassword.Width = fw; _txtNewPassword.UseSystemPasswordChar = true;

        var lblConfPass = new Label { Text = "Potvrdit heslo:", Left = 12, Top = 248, Width = lw, Height = 23, TextAlign = ContentAlignment.MiddleRight };
        _txtConfirmPassword.Left = cx; _txtConfirmPassword.Top = 248; _txtConfirmPassword.Width = fw; _txtConfirmPassword.UseSystemPasswordChar = true;

        var lblSepInfo = new Label { Text = "──── Informace ────", Left = 12, Top = 288, Width = 420, Font = new Font(Font, FontStyle.Italic) };

        var lblReg = new Label { Text = "Registrace:", Left = 12, Top = 316, Width = lw, Height = 23, TextAlign = ContentAlignment.MiddleRight };
        _lblRegistrace.Left = cx; _lblRegistrace.Top = 316; _lblRegistrace.Width = fw; _lblRegistrace.Height = 23;

        var lblTrial = new Label { Text = "Trial vyprší:", Left = 12, Top = 344, Width = lw, Height = 23, TextAlign = ContentAlignment.MiddleRight };
        _lblTrialDo.Left = cx; _lblTrialDo.Top = 344; _lblTrialDo.Width = fw; _lblTrialDo.Height = 23;

        var btnSaveInfo = new Button { Text = "Uložit změny", Left = cx, Top = 380, Width = 120 };
        btnSaveInfo.Click += SaveBasicInfo;

        tabInfo.Text = "Základní údaje";
        tabInfo.Controls.AddRange(new Control[] {
            lblEmail, _txtEmail, lblCompany, _txtCompanyName,
            lblIco, _txtIco, lblDic, _txtDic, _chkActive,
            lblSepPass, lblNewPass, _txtNewPassword, lblConfPass, _txtConfirmPassword,
            lblSepInfo, lblReg, _lblRegistrace, lblTrial, _lblTrialDo,
            btnSaveInfo
        });

        // subsToolbar
        _btnAddPeriod.Text = "Přidat období"; _btnAddPeriod.Left = 4; _btnAddPeriod.Top = 6; _btnAddPeriod.Width = 120;
        _btnAddPeriod.Click += BtnAddPeriod_Click;
        _btnEditPeriod.Text = "Upravit"; _btnEditPeriod.Left = 132; _btnEditPeriod.Top = 6; _btnEditPeriod.Width = 90; _btnEditPeriod.Enabled = false;
        _btnEditPeriod.Click += BtnEditPeriod_Click;
        _btnDeletePeriod.Text = "Smazat"; _btnDeletePeriod.Left = 230; _btnDeletePeriod.Top = 6; _btnDeletePeriod.Width = 90; _btnDeletePeriod.Enabled = false;
        _btnDeletePeriod.Click += BtnDeletePeriod_Click;
        subsToolbar.Dock = DockStyle.Top; subsToolbar.Height = 40; subsToolbar.Padding = new Padding(4, 6, 4, 4);
        subsToolbar.Controls.AddRange(new Control[] { _btnAddPeriod, _btnEditPeriod, _btnDeletePeriod });

        // _gridSubs
        _gridSubs.Dock = DockStyle.Fill;
        _gridSubs.ReadOnly = true;
        _gridSubs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        _gridSubs.MultiSelect = false;
        _gridSubs.AllowUserToAddRows = false;
        _gridSubs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _gridSubs.RowHeadersVisible = false;
        _gridSubs.BackgroundColor = SystemColors.Window;
        _gridSubs.SelectionChanged += GridSubs_SelectionChanged;
        _gridSubs.CellDoubleClick += GridSubs_CellDoubleClick;

        colFrom.Name = "colFrom"; colFrom.HeaderText = "Od"; colFrom.FillWeight = 80;
        colTo.Name = "colTo"; colTo.HeaderText = "Do"; colTo.FillWeight = 80;
        colNote.Name = "colNote"; colNote.HeaderText = "Poznámka";
        colCreated.Name = "colCreated"; colCreated.HeaderText = "Vytvořeno"; colCreated.FillWeight = 80;
        _gridSubs.Columns.AddRange(colFrom, colTo, colNote, colCreated);

        tabSubs.Text = "Předplatné";
        tabSubs.Controls.Add(subsToolbar);
        tabSubs.Controls.Add(_gridSubs);

        // _tabs
        _tabs.Dock = DockStyle.Fill;
        _tabs.TabPages.Add(tabInfo);
        _tabs.TabPages.Add(tabSubs);

        // UserDetailForm
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Text = "Detail uživatele";
        ClientSize = new Size(684, 521);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterParent;
        Controls.Add(_tabs);

        _tabs.ResumeLayout(false);
        tabInfo.ResumeLayout(false);
        tabInfo.PerformLayout();
        tabSubs.ResumeLayout(false);
        subsToolbar.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)_gridSubs).EndInit();
        ResumeLayout(false);
    }

    private TabControl _tabs = null!;
    private TextBox _txtEmail = null!;
    private TextBox _txtCompanyName = null!;
    private TextBox _txtIco = null!;
    private TextBox _txtDic = null!;
    private CheckBox _chkActive = null!;
    private TextBox _txtNewPassword = null!;
    private TextBox _txtConfirmPassword = null!;
    private Label _lblRegistrace = null!;
    private Label _lblTrialDo = null!;
    private DataGridView _gridSubs = null!;
    private Button _btnAddPeriod = null!;
    private Button _btnEditPeriod = null!;
    private Button _btnDeletePeriod = null!;
}
