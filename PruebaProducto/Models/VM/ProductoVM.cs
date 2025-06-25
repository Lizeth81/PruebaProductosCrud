using Microsoft.AspNetCore.Mvc.Rendering;

namespace PruebaProducto.Models.VM
{
    public class ProductoVM
    {
        public Producto oProducto { get; set; }


        public List<SelectListItem> oListaProducto { get; set; }
    }
}
