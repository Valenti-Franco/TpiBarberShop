﻿using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TpiBarberShop.Services;
using TpiBarberShop.Entities;
using TpiBarberShop.DTOs;
using TpiBarberShop.Migrations;

namespace TpiBarberShop.Controllers
{
    [ApiController]
    [Route("api/Compras")]
    public class ComprasController : Controller
    {
        private readonly IProductosRepository _repository;
        private readonly IComprasRepository _ComprasRepository;


        private readonly IMapper _mapper;
        public ComprasController(IProductosRepository repository, IComprasRepository ComprasRepository, IMapper mapper)
        {
            _repository = repository;
            _ComprasRepository = ComprasRepository;
            _mapper = mapper;
        }
        [HttpPost("{id}")]
        [Authorize]
        public ActionResult ComprarProducto(int id)
        {
            var producto = _repository.GetProducto(id);
            
            if (producto != null)
            {
                var usuarioId = User.FindFirstValue("sub");
                var usuarioActual = ObtenerUsuarioActual(usuarioId);

                if (usuarioActual == null)
                {
                   
                    return NotFound("No tenes los permisos para Comprar");
                }

                try
                {
                    _ComprasRepository.CrearNuevaCompra(usuarioActual.Id, producto.Id);
                    _repository.ReducirStock(producto);
                    _ComprasRepository.GuardarCambios();
                  

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message); // Return an appropriate error message when stock is 0
                }
                return Ok("Compra Realizada Correctamente");
            }


            string mensajeError = "El Producto actual no se pudo encontrar.";
            return NotFound(mensajeError);
        }

        [HttpGet("Admin")]
        [Authorize]
        public IActionResult ObtenerCompras()
        {
            var usuarioId = User.FindFirstValue("sub");
            var usuarioActual = ObtenerUsuarioActual(usuarioId);
            if (usuarioActual.Role != "Admin")
                return NotFound("No tenes los permisos para ver todas las Compras");

            var compras = _ComprasRepository.GetCompras();

        

            return Ok(_mapper.Map<IEnumerable<CompraDTO>>(compras));
        }
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult ObtenerCompras(int id)
        {
            var producto = _ComprasRepository.GetCompras(id);
            if (producto == null)
            {
                return NotFound("No existe ese Producto");
            }

            var usuarioId = User.FindFirstValue("sub");
            var usuarioActual = ObtenerUsuarioActual(usuarioId);
            if (usuarioActual.Role != "Admin")
            {
                if (usuarioActual.Id != producto.UsuarioId)
                    return NotFound("No tenes los permisos para ver esta Compra");
            }

            var compras = _ComprasRepository.GetCompras(id);

          

            return Ok(_mapper.Map<CompraDTO>(compras));
        }

        [HttpGet("Confirmadas/Admin")]
        [Authorize]
        public IActionResult ObtenerComprasConfirmadas()
        {
            var usuarioId = User.FindFirstValue("sub");
            var usuarioActual = ObtenerUsuarioActual(usuarioId);
            if (usuarioActual.Role != "Admin")
                return NotFound("No tenes los permisos para eliminar esta Compra");

            var compras = _ComprasRepository.GetComprasConfirmadas();

            var comprasDTO = _mapper.Map<IEnumerable<CompraDTO>>(compras);

            if (!comprasDTO.Any())
                return Ok("No hay Compras Confirmadas");
            return Ok(comprasDTO);
        }

        [HttpGet("Pendientes/Admin")]
        [Authorize]
        public IActionResult ObtenerComprasPendientes()
        {
            var usuarioId = User.FindFirstValue("sub");
            var usuarioActual = ObtenerUsuarioActual(usuarioId);
            if (usuarioActual.Role != "Admin")
                return NotFound("No tenes los permisos para eliminar esta Compra");
            

            var compras = _ComprasRepository.GetComprasPendientes();
            var comprasDTO = _mapper.Map<IEnumerable<CompraDTO>>(compras);
          
            if (!comprasDTO.Any())
                return Ok("No hay Compras Pendientes");
            return Ok(comprasDTO);
        }


        [HttpDelete("{idCompra}")]
        [Authorize]
        public ActionResult EliminarCompraPendiente(int idCompra)
        {
            var compraAEliminar = _ComprasRepository.GetCompras(idCompra);


            if (compraAEliminar is null)
                return NotFound(compraAEliminar);

           
            if (compraAEliminar.Estado != "pendiente")
                return NotFound(compraAEliminar);

            var usuarioId = User.FindFirstValue("sub");
            var usuarioActual = ObtenerUsuarioActual(usuarioId);
            if (usuarioActual.Role != "Admin")
            {
                if (usuarioActual.Id != compraAEliminar.UsuarioId)
                return NotFound("No tenes los permisos para eliminar esta Compra");
            }
            var productoId = compraAEliminar.ProductoId;
            var producto = _repository.GetProducto(productoId);

            _ComprasRepository.EliminarCompra(compraAEliminar);
            _repository.AumentarStock(producto);
            _repository.GuardarCambios();

            return NoContent();

        }


        [HttpPut("{id}/ConfirmarCompra/Admin")]
        [Authorize]
        public ActionResult ConfirmarCompra(int id)
        {

            var usuarioId = User.FindFirstValue("sub");
            var usuarioActual = ObtenerUsuarioActual(usuarioId);
            if (usuarioActual.Role != "Admin")
                return NotFound("No tenes los permisos actualizar Compra");

            var compra = _ComprasRepository.GetCompras(id);

            if (compra == null)
            {
                return NotFound("No existe esa Compra");
            }

            if (compra.Estado == "confirmada")
            {
                return BadRequest("La compra ya está confirmada");
            }

            compra.Estado = "confirmada";
            _repository.GuardarCambios();

            return NoContent();
        }

        private EUsuarios ObtenerUsuarioActual(string usuarioId)
        {
            var usuario = _repository.GetUsuarios(int.Parse(usuarioId));

            return usuario;
        }
    }
}
