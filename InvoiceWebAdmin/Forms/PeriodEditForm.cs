using InvoiceWebAdmin.Models;

namespace InvoiceWebAdmin.Forms;

public class PeriodEditForm : Form
{
    public DateOnly PeriodFrom { get; private set; }
    public DateOnly PeriodTo { get; private set; }
    public string? PeriodNote { get; private set; }

    private DateTimePicker _dtFrom = null!, _dtTo = null!;
    private TextBox _txtNote = null!;

    public PeriodEditForm(SubscriptionPeriod? existing, DateOnly defaultFrom)
    {
        Text = existing == null ? "Přidat období" : "Upravit období";
        Size = new Size(380, 230);
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;

        int y = 16, lw = 110, fw = 200;
        Label L(string text) => new Label { Text = text, Left = 12, Top = y, Width = lw, TextAlign = ContentAlignment.MiddleRight, AutoSize = false };

        Controls.Add(L("Od:"));
        _dtFrom = new DateTimePicker { Left = lw + 20, Top = y, Width = fw, Format = DateTimePickerFormat.Short };
        _dtFrom.Value = existing != null
            ? existing.From.ToDateTime(TimeOnly.MinValue)
            : defaultFrom.ToDateTime(TimeOnly.MinValue);
        Controls.Add(_dtFrom); y += 36;

        Controls.Add(L("Do:"));
        _dtTo = new DateTimePicker { Left = lw + 20, Top = y, Width = fw, Format = DateTimePickerFormat.Short };
        _dtTo.Value = existing != null
            ? existing.To.ToDateTime(TimeOnly.MinValue)
            : defaultFrom.AddMonths(1).AddDays(-1).ToDateTime(TimeOnly.MinValue);
        Controls.Add(_dtTo); y += 36;

        Controls.Add(L("Poznámka:"));
        _txtNote = new TextBox { Left = lw + 20, Top = y, Width = fw, Text = existing?.Note ?? "" };
        Controls.Add(_txtNote); y += 36;

        y += 4;
        var btnOk = new Button { Text = "Uložit", Left = lw + 20, Top = y, Width = 90, DialogResult = DialogResult.OK };
        btnOk.Click += Save;
        var btnCancel = new Button { Text = "Zrušit", Left = lw + 120, Top = y, Width = 90, DialogResult = DialogResult.Cancel };
        Controls.AddRange([btnOk, btnCancel]);
        AcceptButton = btnOk;
        CancelButton = btnCancel;
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
    }
}
