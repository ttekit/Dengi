using System;

namespace Dengi.DB.Entities;

public class Currency
{
    private string cc;
    private string exchangedate;
    private string txt;

    public int R030 { get; set; }

    public string Txt
    {
        get => txt;
        set => txt = value ?? throw new ArgumentNullException(nameof(value));
    }

    public double Rate { get; set; }

    public string Cc
    {
        get => cc;
        set => cc = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Exchangedate
    {
        get => exchangedate;
        set => exchangedate = value ?? throw new ArgumentNullException(nameof(value));
    }

    public override string ToString()
    {
        return Txt;
    }
}