using System;
using System.Collections.Generic;

namespace PruebaProducto.Models;

public partial class Imagen
{
    public int IdImg { get; set; }

    public string? Nombre { get; set; }

    public string? Extension { get; set; }

    public byte[]? Contenido { get; set; }
}
