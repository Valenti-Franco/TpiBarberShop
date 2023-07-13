﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TpiBarberShop.Entities
{
    public class EUsuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MaxLength(150)]
        public string Email { get; set; } 

        [Required]
        public string Role { get; set; }

        public EUsuarios(string nombre)
        {
            Nombre = nombre;
        }
    }
}
