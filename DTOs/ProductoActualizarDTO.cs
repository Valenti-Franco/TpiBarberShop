﻿using System.ComponentModel.DataAnnotations;

namespace TpiBarberShop.DTOs
{
    public class ProductoActualizarDTO
    {
        [Required(ErrorMessage = "Agrega un Nombre")]
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
    }
}
