using System.Text.RegularExpressions;
using Dengi.DB.Entities;

namespace Dengi.Core.DB;

public class CurrencyConverter
{
    private static readonly Regex _regex = new("[^0-9.-]+");

    public static float ConvertCurrency(Currency user, Currency toConvert, float userAmmount)
    {
        if (user.Txt == "") return 0;
        if (toConvert.Txt == "") return 0;
        if (userAmmount <= 0) return 0;
        if (!_regex.IsMatch(user.Txt)) return 0;

        return (float)(userAmmount * user.Rate / toConvert.Rate);
    }
}