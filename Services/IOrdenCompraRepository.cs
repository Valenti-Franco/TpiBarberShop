﻿using TpiBarberShop.DTOs;
using TpiBarberShop.Entities;

namespace TpiBarberShop.Services
{
    public interface IOrdenCompraRepository
    {
        public IEnumerable<OrdenCompraDTO> GetOrdenCompra();
        public EOrdenCompra GetOrdenCompra(int id);
        bool GuardarCambios();

        public IEnumerable<OrdenCompraDTO> GetOrdenCompraUser(int idUsuario);
        void EliminarOrdenCompra(EOrdenCompra ordencompra);

        void CrearOrdenCompra(int usuarioId);


    }
}
