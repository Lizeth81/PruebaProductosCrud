using System;
using System.Collections.Generic;

namespace PruebaProducto.Models;

public partial class Estado
{
    public int IdEstado { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
