using Dengi.Core.DB;

namespace Dengi.ViewModels;

public abstract class ViewFinancesModel
{
    public static DengiDBContext DBContext { get; set; } = new();
}