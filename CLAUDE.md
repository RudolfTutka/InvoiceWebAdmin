# CLAUDE.md – InvoiceWebAdmin

## Přehled projektu

WinForms admin nástroj (.NET 8) pro správu uživatelů aplikace InvoiceWeb.
Čte a upravuje sdílenou SQLite databázi InvoiceWebu.

- **Typ:** WinForms (.NET 8, `net8.0-windows`)
- **Databáze:** SQLite (EF Core 8), sdílená s InvoiceWeb – žádné EF migrace
- **Jazyk UI:** čeština

## Struktura projektu

```
InvoiceWebAdmin/
├── Database/          # AdminDbContext + DatabaseInitializer
├── Forms/             # WinForms formuláře (partial class + Designer.cs)
├── Models/            # EF Core entity (User, CompanySettings, ...)
├── Program.cs         # Entry point ([STAThread] explicit Main)
├── appsettings.json   # Cesta k DB (klíč DatabasePath)
└── InvoiceWebAdmin.csproj
```

## Build

```bash
dotnet build InvoiceWebAdmin/InvoiceWebAdmin.csproj -c Release
```

> `msbuild` není na PATH v bash – vždy používat `dotnet build`.

## Databáze

- Cesta k DB se čte z `appsettings.json` (klíč `DatabasePath`)
- Při startu: pokud soubor neexistuje → otevře se `DatabaseSetupForm`
- `DatabaseInitializer` přidává admin-specifické sloupce a tabulky přes `ALTER TABLE` / `CREATE TABLE IF NOT EXISTS` (try/catch – bezpečné opakované spuštění)
- Přidané sloupce: `Users.IsActive`, `Users.UpdatedAt`, tabulky `SubscriptionPeriods`, `AdminSettings`

## WinForms konvence

### partial class + Designer.cs

Každý formulář musí být rozdělen na:
- `FormName.cs` – business logika (constructor, event handlery, metody)
- `FormName.Designer.cs` – pouze `InitializeComponent()` + field declarations

### DPI scaling

`InitializeComponent()` musí začínat:
```csharp
AutoScaleDimensions = new SizeF(7F, 15F);
AutoScaleMode = AutoScaleMode.Font;
```

V `.csproj`:
```xml
<ApplicationHighDpiMode>PerMonitorV2</ApplicationHighDpiMode>
<ForceDesignerDpiUnaware>true</ForceDesignerDpiUnaware>
```

### Zákaz lambd a lokálních funkcí v Designer.cs

**V `*.Designer.cs` nesmí být žádné lambda výrazy ani lokální funkce.** VS Designer je neumí zpracovat.

Místo:
```csharp
// ŠPATNĚ – nesmí být v Designer.cs
_btn.Click += (_, _) => DoSomething();

// ŠPATNĚ – lokální funkce také nesmí být v Designer.cs
void AddLabel(Control parent, string text, int y) { ... }
```

Vždy:
```csharp
// SPRÁVNĚ v Designer.cs
_btn.Click += Btn_Click;
```

```csharp
// Pojmenovaná metoda patří do FormName.cs
private void Btn_Click(object sender, EventArgs e) => DoSomething();
```

Konvence pojmenování: `ControlName_EventName` (např. `SearchBox_TextChanged`, `BtnSave_Click`, `Grid_CellDoubleClick`).

### STAThread

`OpenFileDialog` a jiné OLE/COM dialogy vyžadují STA vlákno. `Program.cs` musí mít explicitní `Main` s `[STAThread]` – nelze použít top-level statements.

## Modely vs. skutečné DB schéma

InvoiceWebAdmin model musí odpovídat skutečnému schématu InvoiceWeb DB. Sloupce které jsou v modelu ale ne v DB způsobí `SqliteException: no such column`.

Skutečné sloupce `Users` tabulky InvoiceWebu: `Id`, `Name`, `Email`, `PasswordHash`, `CreatedAt`
Admin přidává přes ALTER TABLE: `IsActive`, `UpdatedAt`

Pokud model obsahuje vlastnost bez odpovídajícího sloupce v DB: přidat `ALTER TABLE` do `DatabaseInitializer`, nebo označit `[NotMapped]`.
