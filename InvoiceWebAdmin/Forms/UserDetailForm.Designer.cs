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
        tabInfo = new TabPage();
        lblEmail = new Label();
        _txtEmail = new TextBox();
        lblCompany = new Label();
        _txtCompanyName = new TextBox();
        lblIco = new Label();
        _txtIco = new TextBox();
        lblDic = new Label();
        _txtDic = new TextBox();
        _chkActive = new CheckBox();
        lblSepPass = new Label();
        lblNewPass = new Label();
        _txtNewPassword = new TextBox();
        lblConfPass = new Label();
        _txtConfirmPassword = new TextBox();
        lblSepInfo = new Label();
        lblReg = new Label();
        _lblRegistrace = new Label();
        lblTrial = new Label();
        _lblTrialDo = new Label();
        btnSaveInfo = new Button();
        tabSubs = new TabPage();
        subsToolbar = new Panel();
        _btnAddPeriod = new Button();
        _btnEditPeriod = new Button();
        _btnDeletePeriod = new Button();
        _btnMarkPaid = new Button();
        _gridSubs = new DataGridView();
        colFrom = new DataGridViewTextBoxColumn();
        colTo = new DataGridViewTextBoxColumn();
        colVarSymbol = new DataGridViewTextBoxColumn();
        colDatumObj = new DataGridViewTextBoxColumn();
        colZaplaceno = new DataGridViewTextBoxColumn();
        colStav = new DataGridViewTextBoxColumn();
        _tabs.SuspendLayout();
        tabInfo.SuspendLayout();
        tabSubs.SuspendLayout();
        subsToolbar.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_gridSubs).BeginInit();
        SuspendLayout();
        // 
        // _tabs
        // 
        _tabs.Controls.Add(tabInfo);
        _tabs.Controls.Add(tabSubs);
        _tabs.Dock = DockStyle.Fill;
        _tabs.Location = new Point(0, 0);
        _tabs.Name = "_tabs";
        _tabs.SelectedIndex = 0;
        _tabs.Size = new Size(684, 521);
        _tabs.TabIndex = 0;
        // 
        // tabInfo
        // 
        tabInfo.Controls.Add(lblEmail);
        tabInfo.Controls.Add(_txtEmail);
        tabInfo.Controls.Add(lblCompany);
        tabInfo.Controls.Add(_txtCompanyName);
        tabInfo.Controls.Add(lblIco);
        tabInfo.Controls.Add(_txtIco);
        tabInfo.Controls.Add(lblDic);
        tabInfo.Controls.Add(_txtDic);
        tabInfo.Controls.Add(_chkActive);
        tabInfo.Controls.Add(lblSepPass);
        tabInfo.Controls.Add(lblNewPass);
        tabInfo.Controls.Add(_txtNewPassword);
        tabInfo.Controls.Add(lblConfPass);
        tabInfo.Controls.Add(_txtConfirmPassword);
        tabInfo.Controls.Add(lblSepInfo);
        tabInfo.Controls.Add(lblReg);
        tabInfo.Controls.Add(_lblRegistrace);
        tabInfo.Controls.Add(lblTrial);
        tabInfo.Controls.Add(_lblTrialDo);
        tabInfo.Controls.Add(btnSaveInfo);
        tabInfo.Location = new Point(4, 24);
        tabInfo.Name = "tabInfo";
        tabInfo.Size = new Size(676, 493);
        tabInfo.TabIndex = 0;
        tabInfo.Text = "Základní údaje";
        // 
        // lblEmail
        // 
        lblEmail.Location = new Point(12, 20);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(140, 23);
        lblEmail.TabIndex = 0;
        lblEmail.Text = "E-mail:";
        lblEmail.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _txtEmail
        // 
        _txtEmail.Location = new Point(168, 20);
        _txtEmail.Name = "_txtEmail";
        _txtEmail.Size = new Size(300, 23);
        _txtEmail.TabIndex = 1;
        // 
        // lblCompany
        // 
        lblCompany.Location = new Point(12, 52);
        lblCompany.Name = "lblCompany";
        lblCompany.Size = new Size(140, 23);
        lblCompany.TabIndex = 2;
        lblCompany.Text = "Název firmy:";
        lblCompany.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _txtCompanyName
        // 
        _txtCompanyName.Location = new Point(168, 52);
        _txtCompanyName.Name = "_txtCompanyName";
        _txtCompanyName.Size = new Size(300, 23);
        _txtCompanyName.TabIndex = 3;
        // 
        // lblIco
        // 
        lblIco.Location = new Point(12, 84);
        lblIco.Name = "lblIco";
        lblIco.Size = new Size(140, 23);
        lblIco.TabIndex = 4;
        lblIco.Text = "IČO:";
        lblIco.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _txtIco
        // 
        _txtIco.Location = new Point(168, 84);
        _txtIco.Name = "_txtIco";
        _txtIco.Size = new Size(300, 23);
        _txtIco.TabIndex = 5;
        // 
        // lblDic
        // 
        lblDic.Location = new Point(12, 116);
        lblDic.Name = "lblDic";
        lblDic.Size = new Size(140, 23);
        lblDic.TabIndex = 6;
        lblDic.Text = "DIČ:";
        lblDic.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _txtDic
        // 
        _txtDic.Location = new Point(168, 116);
        _txtDic.Name = "_txtDic";
        _txtDic.Size = new Size(300, 23);
        _txtDic.TabIndex = 7;
        // 
        // _chkActive
        // 
        _chkActive.AutoSize = true;
        _chkActive.Location = new Point(168, 148);
        _chkActive.Name = "_chkActive";
        _chkActive.Size = new Size(117, 19);
        _chkActive.TabIndex = 8;
        _chkActive.Text = "Uživatel je aktivní";
        // 
        // lblSepPass
        // 
        lblSepPass.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
        lblSepPass.Location = new Point(12, 188);
        lblSepPass.Name = "lblSepPass";
        lblSepPass.Size = new Size(420, 23);
        lblSepPass.TabIndex = 9;
        lblSepPass.Text = "──── Změna hesla ────";
        // 
        // lblNewPass
        // 
        lblNewPass.Location = new Point(12, 216);
        lblNewPass.Name = "lblNewPass";
        lblNewPass.Size = new Size(140, 23);
        lblNewPass.TabIndex = 10;
        lblNewPass.Text = "Nové heslo:";
        lblNewPass.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _txtNewPassword
        // 
        _txtNewPassword.Location = new Point(168, 216);
        _txtNewPassword.Name = "_txtNewPassword";
        _txtNewPassword.Size = new Size(300, 23);
        _txtNewPassword.TabIndex = 11;
        _txtNewPassword.UseSystemPasswordChar = true;
        // 
        // lblConfPass
        // 
        lblConfPass.Location = new Point(12, 248);
        lblConfPass.Name = "lblConfPass";
        lblConfPass.Size = new Size(140, 23);
        lblConfPass.TabIndex = 12;
        lblConfPass.Text = "Potvrdit heslo:";
        lblConfPass.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _txtConfirmPassword
        // 
        _txtConfirmPassword.Location = new Point(168, 248);
        _txtConfirmPassword.Name = "_txtConfirmPassword";
        _txtConfirmPassword.Size = new Size(300, 23);
        _txtConfirmPassword.TabIndex = 13;
        _txtConfirmPassword.UseSystemPasswordChar = true;
        // 
        // lblSepInfo
        // 
        lblSepInfo.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
        lblSepInfo.Location = new Point(12, 288);
        lblSepInfo.Name = "lblSepInfo";
        lblSepInfo.Size = new Size(420, 23);
        lblSepInfo.TabIndex = 14;
        lblSepInfo.Text = "──── Informace ────";
        // 
        // lblReg
        // 
        lblReg.Location = new Point(12, 316);
        lblReg.Name = "lblReg";
        lblReg.Size = new Size(140, 23);
        lblReg.TabIndex = 15;
        lblReg.Text = "Registrace:";
        lblReg.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _lblRegistrace
        // 
        _lblRegistrace.Location = new Point(168, 316);
        _lblRegistrace.Name = "_lblRegistrace";
        _lblRegistrace.Size = new Size(300, 23);
        _lblRegistrace.TabIndex = 16;
        // 
        // lblTrial
        // 
        lblTrial.Location = new Point(12, 344);
        lblTrial.Name = "lblTrial";
        lblTrial.Size = new Size(140, 23);
        lblTrial.TabIndex = 17;
        lblTrial.Text = "Trial vyprší:";
        lblTrial.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _lblTrialDo
        // 
        _lblTrialDo.Location = new Point(168, 344);
        _lblTrialDo.Name = "_lblTrialDo";
        _lblTrialDo.Size = new Size(300, 23);
        _lblTrialDo.TabIndex = 18;
        // 
        // btnSaveInfo
        // 
        btnSaveInfo.Location = new Point(168, 380);
        btnSaveInfo.Name = "btnSaveInfo";
        btnSaveInfo.Size = new Size(120, 23);
        btnSaveInfo.TabIndex = 19;
        btnSaveInfo.Text = "Uložit změny";
        btnSaveInfo.Click += SaveBasicInfo;
        // 
        // tabSubs
        // 
        tabSubs.Controls.Add(subsToolbar);
        tabSubs.Controls.Add(_gridSubs);
        tabSubs.Location = new Point(4, 24);
        tabSubs.Name = "tabSubs";
        tabSubs.Size = new Size(676, 493);
        tabSubs.TabIndex = 1;
        tabSubs.Text = "Předplatné";
        // 
        // subsToolbar
        // 
        subsToolbar.Controls.Add(_btnAddPeriod);
        subsToolbar.Controls.Add(_btnEditPeriod);
        subsToolbar.Controls.Add(_btnDeletePeriod);
        subsToolbar.Controls.Add(_btnMarkPaid);
        subsToolbar.Dock = DockStyle.Top;
        subsToolbar.Location = new Point(0, 0);
        subsToolbar.Name = "subsToolbar";
        subsToolbar.Padding = new Padding(4, 6, 4, 4);
        subsToolbar.Size = new Size(676, 40);
        subsToolbar.TabIndex = 0;
        // 
        // _btnAddPeriod
        // 
        _btnAddPeriod.Location = new Point(4, 6);
        _btnAddPeriod.Name = "_btnAddPeriod";
        _btnAddPeriod.Size = new Size(120, 23);
        _btnAddPeriod.TabIndex = 0;
        _btnAddPeriod.Text = "Přidat období";
        _btnAddPeriod.Click += BtnAddPeriod_Click;
        // 
        // _btnEditPeriod
        // 
        _btnEditPeriod.Enabled = false;
        _btnEditPeriod.Location = new Point(132, 6);
        _btnEditPeriod.Name = "_btnEditPeriod";
        _btnEditPeriod.Size = new Size(90, 23);
        _btnEditPeriod.TabIndex = 1;
        _btnEditPeriod.Text = "Upravit";
        _btnEditPeriod.Click += BtnEditPeriod_Click;
        // 
        // _btnDeletePeriod
        // 
        _btnDeletePeriod.Enabled = false;
        _btnDeletePeriod.Location = new Point(230, 6);
        _btnDeletePeriod.Name = "_btnDeletePeriod";
        _btnDeletePeriod.Size = new Size(90, 23);
        _btnDeletePeriod.TabIndex = 2;
        _btnDeletePeriod.Text = "Smazat";
        _btnDeletePeriod.Click += BtnDeletePeriod_Click;
        // 
        // _btnMarkPaid
        // 
        _btnMarkPaid.Enabled = false;
        _btnMarkPaid.Location = new Point(328, 6);
        _btnMarkPaid.Name = "_btnMarkPaid";
        _btnMarkPaid.Size = new Size(140, 23);
        _btnMarkPaid.TabIndex = 3;
        _btnMarkPaid.Text = "Označit zaplacené";
        _btnMarkPaid.Click += BtnMarkPaid_Click;
        // 
        // _gridSubs
        // 
        _gridSubs.AllowUserToAddRows = false;
        _gridSubs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        _gridSubs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _gridSubs.BackgroundColor = SystemColors.Window;
        _gridSubs.Columns.AddRange(new DataGridViewColumn[] { colFrom, colTo, colVarSymbol, colDatumObj, colZaplaceno, colStav });
        _gridSubs.Location = new Point(0, 46);
        _gridSubs.MultiSelect = false;
        _gridSubs.Name = "_gridSubs";
        _gridSubs.ReadOnly = true;
        _gridSubs.RowHeadersVisible = false;
        _gridSubs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        _gridSubs.Size = new Size(676, 447);
        _gridSubs.TabIndex = 1;
        _gridSubs.CellDoubleClick += GridSubs_CellDoubleClick;
        _gridSubs.SelectionChanged += GridSubs_SelectionChanged;
        // 
        // colFrom
        // 
        colFrom.FillWeight = 70F;
        colFrom.HeaderText = "Od";
        colFrom.Name = "colFrom";
        colFrom.ReadOnly = true;
        // 
        // colTo
        // 
        colTo.FillWeight = 70F;
        colTo.HeaderText = "Do";
        colTo.Name = "colTo";
        colTo.ReadOnly = true;
        // 
        // colVarSymbol
        // 
        colVarSymbol.HeaderText = "Variabilní symbol";
        colVarSymbol.Name = "colVarSymbol";
        colVarSymbol.ReadOnly = true;
        // 
        // colDatumObj
        // 
        colDatumObj.FillWeight = 80F;
        colDatumObj.HeaderText = "Datum obj.";
        colDatumObj.Name = "colDatumObj";
        colDatumObj.ReadOnly = true;
        // 
        // colZaplaceno
        // 
        colZaplaceno.FillWeight = 55F;
        colZaplaceno.HeaderText = "Zaplaceno";
        colZaplaceno.Name = "colZaplaceno";
        colZaplaceno.ReadOnly = true;
        // 
        // colStav
        // 
        colStav.FillWeight = 65F;
        colStav.HeaderText = "Stav";
        colStav.Name = "colStav";
        colStav.ReadOnly = true;
        // 
        // UserDetailForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(684, 521);
        Controls.Add(_tabs);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "UserDetailForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Detail uživatele";
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
    private Button _btnMarkPaid = null!;
    private TabPage tabInfo;
    private TabPage tabSubs;
    private Panel subsToolbar;
    private Label lblEmail;
    private Label lblCompany;
    private Label lblIco;
    private Label lblDic;
    private Label lblSepPass;
    private Label lblNewPass;
    private Label lblConfPass;
    private Label lblSepInfo;
    private Label lblReg;
    private Label lblTrial;
    private Button btnSaveInfo;
    private DataGridViewTextBoxColumn colFrom;
    private DataGridViewTextBoxColumn colTo;
    private DataGridViewTextBoxColumn colVarSymbol;
    private DataGridViewTextBoxColumn colDatumObj;
    private DataGridViewTextBoxColumn colZaplaceno;
    private DataGridViewTextBoxColumn colStav;
}
