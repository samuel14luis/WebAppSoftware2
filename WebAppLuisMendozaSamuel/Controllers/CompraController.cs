using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppLuisMendozaSamuel.Data.DataAccess;
using WebAppLuisMendozaSamuel.Models.Entidades;

namespace WebAppLuisMendozaSamuel.Controllers
{
    public class CompraController : Controller
    {
        public IActionResult Index()
        {
            var da = new CompraDA();
            var compras = da.GetListaCompras();
            return View(compras);
        }
        [Authorize]
        public IActionResult Create()
        {
            var da = new ProductoDA();
            var daclientes = new ClienteDA();
            ViewBag.productos = da.GetListaProductos();
            ViewBag.clientes = daclientes.GetListaClientes();
            ViewBag.alerta = "";
            return View();
        }
        [HttpPost, Authorize]
        public IActionResult Create(Compra compra)
        {
            var auxDA = new ProductoDA();
            var productoComprado = auxDA.GetProductoById(compra.idProducto);

            if (compra.cantidad <= productoComprado.stock)
            {
                var da = new CompraDA();
                compra.precioTotal = productoComprado.precioUnitario * compra.cantidad;
                productoComprado.stock = productoComprado.stock - compra.cantidad;
                auxDA.ActualizarProducto(productoComprado);
                if (da.InsertarCompra(compra) > 0)
                {
                    return RedirectToAction("index");
                }
            }
            var daclientes = new ClienteDA();
            ViewBag.productos = auxDA.GetListaProductos();
            ViewBag.clientes = daclientes.GetListaClientes();
            ViewBag.alerta = "Se ha superado el stock máximo de "+productoComprado.stock+" unidades para el producto.";
            return View();
        }
    }
}