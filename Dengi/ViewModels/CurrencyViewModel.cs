using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Xml;
using Dengi.DB.Entities;

namespace Dengi.ViewModels;

public class CurrencyViewModel
{
    private List<Currency> _currencies;

    public List<Currency> GetCurrencyList
    {
        get
        {
            if (_currencies == null) LoadCurrencies();

            return _currencies;
        }
    }

    public FlowDocument FlowDocument { get; } = new();

    public void InitTable()
    {
        var table1 = new Table();
        FlowDocument.Blocks.Add(table1);

        table1.CellSpacing = 10;
        table1.Background = Brushes.White;
        var numberOfColumns = 5;
        for (var x = 0; x < numberOfColumns; x++)
        {
            table1.Columns.Add(new TableColumn());
            if (x % 2 == 0)
                table1.Columns[x].Background = Brushes.LightPink;
            else
                table1.Columns[x].Background = Brushes.Pink;
        }

        table1.RowGroups.Add(new TableRowGroup());

        table1.RowGroups[0].Rows.Add(new TableRow());

        var currentRow = table1.RowGroups[0].Rows[0];

        currentRow.FontSize = 40;
        currentRow.FontWeight = FontWeights.Bold;
        currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Currencies"))));
        currentRow.Cells[0].ColumnSpan = numberOfColumns;

        table1.RowGroups[0].Rows.Add(new TableRow());
        currentRow = table1.RowGroups[0].Rows[1];

        currentRow.FontSize = 18;
        currentRow.FontWeight = FontWeights.Bold;


        currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Currency"))));
        currentRow.Cells.Add(new TableCell(new Paragraph(new Run("CC"))));
        currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Rate"))));
        currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Exchange Date"))));
        currentRow.Cells.Add(new TableCell(new Paragraph(new Run("R030"))));

        table1.RowGroups[0].Rows.Add(new TableRow());
        currentRow = table1.RowGroups[0].Rows[2];


        var currencies = GetCurrencyList;
        var i = 3;
        foreach (var cur in currencies)
        {
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(cur.Txt))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(cur.Cc))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(cur.Rate.ToString()))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(cur.Exchangedate))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(cur.R030.ToString()))));
            currentRow.FontFamily = SystemFonts.MessageFontFamily;
            currentRow.Cells[0].FontWeight = FontWeights.Bold;
            table1.RowGroups[0].Rows.Add(new TableRow());
            currentRow = table1.RowGroups[0].Rows[i];
            i++;
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    private void LoadCurrencies()
    {
        _currencies = new List<Currency>();
        var apiUrl = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange";

        var doc1 = new XmlDocument();
        doc1.Load(apiUrl);
        var root = doc1.DocumentElement;
        var nodes = root.SelectNodes("/exchange/currency");

        foreach (XmlNode node in nodes)
        {
            var r030 = node["r030"].InnerText;
            var txt = node["txt"].InnerText;
            var rate = node["rate"].InnerText;
            var cc = node["cc"].InnerText;
            var exchangedate = node["exchangedate"].InnerText;
            _currencies.Add(new Currency
            {
                R030 = int.Parse(r030),
                Txt = txt,
                Rate = double.Parse(rate),
                Exchangedate = exchangedate,
                Cc = cc
            });
        }
    }
}