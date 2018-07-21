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
    public class ClienteController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            var da = new ClienteDA();
            var clientes = da.GetListaClientes();
            return View(clientes);
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost, Authorize]
        public IActionResult Create(Cliente cliente)
        {
            cliente.idCliente = 0;
            var da = new ClienteDA();
            if (da.InsertarCliente(cliente) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(cliente);
            }
        }
        [Authorize]
        public IActionResult Edit(int id)
        {
            var da = new ClienteDA();
            var cliente = da.GetClienteById(id);
            return View(cliente);
        }
        [HttpPost, Authorize]
        public IActionResult Edit(Cliente cliente)
        {
            var da = new ClienteDA();
            if (da.ActualizarCliente(cliente))
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(cliente);
            }
        }
        [Authorize]
        public IActionResult Details(int id)
        {
            var da = new ClienteDA();
            var cliente = da.GetClienteById(id);
            return View(cliente);
        }
        [Authorize]
        public IActionResult Delete(int id)
        {
            var da = new ClienteDA();
            var cliente = da.GetClienteById(id);
            return View(cliente);
        }
        [HttpPost, Authorize]
        public IActionResult Delete(Cliente cliente)
        {
            var da = new ClienteDA();
            if (da.EliminarCliente(cliente.idCliente)){
                return RedirectToAction("index");
            }
            else
            {
                return View(cliente);
            }
        }
    }
}