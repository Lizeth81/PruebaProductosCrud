using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PruebaProducto.Models;
using Microsoft.EntityFrameworkCore;
using PruebaProducto.Models.VM;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PruebaProducto.Controllers;

public class HomeController : Controller
{
    //_DBContext variable de context
    private readonly GestionProductoContext _DBContext;

    //Se cambia el parametro que esta en el constructor, se referencia a la base de datos
    public HomeController(GestionProductoContext Context)
    {
        _DBContext = Context;
    }

    public IActionResult Index()
    {
        List<Producto> Listaproductos = _DBContext.Productos.Include(c => c.oEstado).ToList();
        return View(Listaproductos);
    }
    //Metodo para Crear y editar un producto
    [HttpGet]
    public IActionResult ProductoDetalle(int id)
    {
        //Se crea el objeto oProducto
        ProductoVM oProductoVM = new ProductoVM()
        {
            //Se envia un objeto vacio
            oProducto = new Producto(),
            //Se agrega la lista de los valores desplegables de Estado
            oListaProducto = _DBContext.Estados.Select(Estado => new SelectListItem()
            {
                Text = Estado.Descripcion,
                Value = Estado.IdEstado.ToString()
            }).ToList()
        };

        if(id != 0)
        {
            oProductoVM.oProducto = _DBContext.Productos.Find(id);
        }

        Console.WriteLine("oProducto--->"+oProductoVM);
        return View(oProductoVM);
    }

    //Metodo para guardar los datos de los productos en la db
    [HttpPost]
    public IActionResult ProductoDetalle(ProductoVM oProductoVM)
    {
       if (oProductoVM.oProducto.IdProducto == 0)
        {
            _DBContext.Productos.Add(oProductoVM.oProducto);
        }
        else
        {
            _DBContext.Productos.Update(oProductoVM.oProducto);
        }
            _DBContext.SaveChanges();

        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Eliminar(int id)

    {
        Console.WriteLine("id eliminar " + id);
        Producto oProducto = _DBContext.Productos.Include(c => c.oEstado).Where(e => e.IdProducto == id).FirstOrDefault();

        return View(oProducto);
    }

    [HttpPost]
    public IActionResult Eliminar(Producto oProducto)
    {
        Console.WriteLine("Elemento a eliminar " + oProducto);
        _DBContext.Productos.Remove(oProducto);
        _DBContext.SaveChanges();

        return RedirectToAction("Index", "Home");
    }

}
