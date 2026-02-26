namespace InvoiceWebAdmin.Forms;

partial class SubscriptionsListForm
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
        _lblFilter = new Label();
        _cmbFilter = new ComboBox();
        _btnDetail = new Button();
        _btnOpenUser = new Button();
        _btnMarkPaid = new Button();
        _grid = new DataGridView();
        var colFirma = new DataGridViewTextBoxColumn();
        var colOd = new DataGridViewTextBoxColumn();
        var colDo = new DataGridViewTextBoxColumn();
        var colVarSymbol = new DataGridViewTextBoxColumn();
        var colDatumObj = new DataGridViewTextBoxColumn();
        var colZaplaceno = new DataGridViewTextBoxColumn();
        var colStav = new DataGridViewTextBoxColumn();
        _toolbar.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_grid).BeginInit();
        SuspendLayout();

        // _lblFilter
        _lblFilter.Text = "Filtr:";
        _lblFilter.AutoSize = true;
        _lblFilter.Left = 8; _lblFilter.Top = 13;

        // _cmbFilter
        _cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
        _cmbFilter.Items.AddRange(new object[] { "Všechny", "Aktivní", "Nezaplacené", "Expirované" });
        _cmbFilter.SelectedIndex = 0;
        _cmbFilter.Left = 50; _cmbFilter.Top = 8; _cmbFilter.Width = 140;
        _cmbFilter.SelectedIndexChanged += CmbFilter_SelectedIndexChanged;

        // _btnDetail
        _btnDetail.Text = "Otevřít detail";
        _btnDetail.Left = 204; _btnDetail.Top = 6; _btnDetail.Width = 120; _btnDetail.Enabled = false;
        _btnDetail.Click += BtnDetail_Click;

        // _btnOpenUser
        _btnOpenUser.Text = "Otevřít uživatele";
        _btnOpenUser.Left = 332; _btnOpenUser.Top = 6; _btnOpenUser.Width = 130; _btnOpenUser.Enabled = false;
        _btnOpenUser.Click += BtnOpenUser_Click;

        // _btnMarkPaid
        _btnMarkPaid.Text = "Označit zaplacené";
        _btnMarkPaid.Left = 470; _btnMarkPaid.Top = 6; _btnMarkPaid.Width = 140; _btnMarkPaid.Enabled = false;
        _btnMarkPaid.Click += BtnMarkPaid_Click;

        // _toolbar
        _toolbar.Dock = DockStyle.Top; _toolbar.Height = 44;
        _toolbar.Padding = new Padding(8, 6, 8, 6);
        _toolbar.Controls.AddRange(new Control[] { _lblFilter, _cmbFilter, _btnDetail, _btnOpenUser, _btnMarkPaid });

        // columns
        colFirma.Name = "colFirma"; colFirma.HeaderText = "Firma";
        colOd.Name = "colOd"; colOd.HeaderText = "Od"; colOd.FillWeight = 65F;
        colDo.Name = "colDo"; colDo.HeaderText = "Do"; colDo.FillWeight = 65F;
        colVarSymbol.Name = "colVarSymbol"; colVarSymbol.HeaderText = "Var. symbol"; colVarSymbol.FillWeight = 80F;
        colDatumObj.Name = "colDatumObj"; colDatumObj.HeaderText = "Datum obj."; colDatumObj.FillWeight = 70F;
        colZaplaceno.Name = "colZaplaceno"; colZaplaceno.HeaderText = "Zaplaceno"; colZaplaceno.FillWeight = 55F;
        colStav.Name = "colStav"; colStav.HeaderText = "Stav"; colStav.FillWeight = 60F;

        // _grid
        _grid.Dock = DockStyle.Fill;
        _grid.ReadOnly = true;
        _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        _grid.MultiSelect = false;
        _grid.AllowUserToAddRows = false;
        _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _grid.RowHeadersVisible = false;
        _grid.BackgroundColor = SystemColors.Window;
        _grid.Columns.AddRange(colFirma, colOd, colDo, colVarSymbol, colDatumObj, colZaplaceno, colStav);
        _grid.SelectionChanged += Grid_SelectionChanged;
        _grid.CellDoubleClick += Grid_CellDoubleClick;

        // SubscriptionsListForm
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Text = "Správa předplatných";
        ClientSize = new Size(1000, 580);
        StartPosition = FormStartPosition.CenterParent;
        Controls.Add(_grid);
        Controls.Add(_toolbar);

        _toolbar.ResumeLayout(false);
        _toolbar.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Panel _toolbar = null!;
    private Label _lblFilter = null!;
    private ComboBox _cmbFilter = null!;
    private Button _btnDetail = null!;
    private Button _btnOpenUser = null!;
    private Button _btnMarkPaid = null!;
    private DataGridView _grid = null!;
}
