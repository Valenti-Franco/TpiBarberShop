﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TpiBarberShop.Entities
{
    public class EImagenUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }

        public EUsuarios Usuario { get; set; }



        public string URL { get; set; }

        public DateTime FechaPublicado { get; private set; }

        public EImagenUsuario()
        {

            FechaPublicado = DateTime.Now;
        }
    }
}
