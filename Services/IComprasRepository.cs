﻿using TpiBarberShop.DTOs.Compra;
using TpiBarberShop.Entities;

namespace TpiBarberShop.Services
{
    public interface IComprasRepository
    {
        void CrearNuevaCompra(int usuarioId, int productoId, int Cantidad);


        public IEnumerable<ECompras> GetCompras();
        public ECompras GetCompras(int id);

        public IEnumerable<ECompras> GetComprasConfirmadas();

        public IEnumerable<ECompras> GetComprasPendientes();
        void EliminarCompra(ECompras compra);
        bool GuardarCambios();
        List<CompraDTO> GetComprasByUsuarioId(int usuarioId);
        void EliminarCompraUser(int usuarioid);
        IEnumerable<CompraDTO> GetCompraUser(int idUsuario);
    }
}
