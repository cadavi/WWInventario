
using WWInventario.Models;

namespace WWInventario.Data.ViewModels
{
    public class NewSucursalDropdownVM
    {
        public List<Compania> Companias { get; set; }

        public NewSucursalDropdownVM()
        {
            Companias = new List<Compania>();
        }
    }
}
