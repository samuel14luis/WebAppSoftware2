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
    public class ProductoController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            var da = new ProductoDA();
            var model = da.GetListaProductos();
            return View(model);
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost, Authorize]
        public IActionResult Create(Producto producto)
        {
            producto.idProducto = 0;
            var da = new ProductoDA();
            var result = da.InsertarProducto(producto);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(producto);
            }
        }
        [Authorize]
        public IActionResult Details(int id)
        {
            var da = new ProductoDA();
            var producto = da.GetProductoById(id);
            return View(producto);
        }
        [Authorize]
        public IActionResult Edit(int id)
        {
            var da = new ProductoDA();
            var producto = da.GetProductoById(id);
            return View(producto);
        }
        [HttpPost, Authorize]
        public IActionResult Edit(Producto producto)
        {
            var da = new ProductoDA();
            if (da.ActualizarProducto(producto))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(producto);
            }
        }
        [Authorize]
        public IActionResult Delete(int id)
        {
            var da = new ProductoDA();
            var producto = da.GetProductoById(id);
            return View(producto);
        }
        [HttpPost, Authorize]
        public IActionResult Delete(Producto producto)
        {
            var da = new ProductoDA();
            if (da.EliminarProducto(producto.idProducto))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(producto);
            }
        }
    }
}