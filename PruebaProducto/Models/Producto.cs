using System;
using System.Collections.Generic;

namespace PruebaProducto.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? Precio { get; set; }

    public string? FechaCreacion { get; set; }

    public int? IdEstado { get; set; }

    public virtual Estado? oEstado { get; set; }
}
