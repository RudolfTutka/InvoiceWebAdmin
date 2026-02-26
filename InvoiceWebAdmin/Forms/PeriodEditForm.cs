using InvoiceWebAdmin.Models;

namespace InvoiceWebAdmin.Forms;

public partial class PeriodEditForm : Form
{
    public DateOnly PeriodFrom { get; private set; }
    public DateOnly PeriodTo { get; private set; }
    public string? PeriodNote { get; private set; }
    public string? PeriodVariabilniSymbol { get; private set; }
    public DateTime? PeriodDatumObjednavky { get; private set; }

    public PeriodEditForm(SubscriptionPeriod? existing, DateOnly defaultFrom)
    {
        InitializeComponent();
        Text = existing == null ? "Přidat období" : "Upravit období";
        _dtFrom.Value = existing != null
            ? existing.From.ToDateTime(TimeOnly.MinValue)
            : defaultFrom.ToDateTime(TimeOnly.MinValue);
        _dtTo.Value = existing != null
            ? existing.To.ToDateTime(TimeOnly.MinValue)
            : defaultFrom.AddMonths(1).AddDays(-1).ToDateTime(TimeOnly.MinValue);
        _txtNote.Text = existing?.Note ?? "";
        _txtVariabilniSymbol.Text = existing?.VariabilniSymbol ?? "";
        if (existing?.DatumObjednavky.HasValue == true)
        {
            _dtObjednavky.Checked = true;
            _dtObjednavky.Value = existing.DatumObjednavky.Value.ToLocalTime();
        }
        else
        {
            _dtObjednavky.Checked = false;
        }
    }

    private void Save(object? sender, EventArgs e)
    {
        var from = DateOnly.FromDateTime(_dtFrom.Value);
        var to = DateOnly.FromDateTime(_dtTo.Value);
        if (from > to)
        {
            MessageBox.Show("Datum 'Od' musí být před datem 'Do'.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None;
            return;
        }
        PeriodFrom = from;
        PeriodTo = to;
        PeriodNote = string.IsNullOrWhiteSpace(_txtNote.Text) ? null : _txtNote.Text.Trim();
        PeriodVariabilniSymbol = string.IsNullOrWhiteSpace(_txtVariabilniSymbol.Text) ? null : _txtVariabilniSymbol.Text.Trim();
        PeriodDatumObjednavky = _dtObjednavky.Checked ? (DateTime?)_dtObjednavky.Value.ToUniversalTime() : null;
    }
}
