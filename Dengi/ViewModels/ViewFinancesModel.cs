using Dengi.Core.DB;

namespace Dengi.ViewModels
{
    abstract public class ViewFinancesModel
    {
        public static DengiDBContext DBContext { get; set; } = new DengiDBContext();
    }
}
