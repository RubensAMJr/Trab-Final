﻿using SistemaRestaurante.DAO;
using SistemaRestaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaRestaurante.Controllers
{
    public class RegistroController : Controller
    {
        [Route("Registro", Name = "ViewRegistros")]
        public ActionResult Index()
        {
            MesasDAO dao = new MesasDAO();
            UsuarioDAO userDao = new UsuarioDAO();
            ComandaDAO comandaDao = new ComandaDAO();
            ProdutoDAO prodDao = new ProdutoDAO();
            IList<Mesa> mesas = dao.Listar().OrderBy(m => m.Numero).ToList();
            ViewBag.Mesas = mesas;
            ViewBag.Usuarios = userDao.Listar();
            ViewBag.Comandas = comandaDao.Listar();
            return View();
        }

        [Route("AdicionaMesa")]
        public ActionResult AdicionaMesa(int numeroMesa)
        {
            MesasDAO dao = new MesasDAO();
            if (dao.BuscaPorNumero(numeroMesa) != null)
            {
                ModelState.AddModelError("mesaJaExiste", "Mesa com esse numero já existe");
            }
            if (ModelState.IsValid)
            {
                dao.Adiciona(new Mesa(numeroMesa));
                return RedirectToRoute("ViewRegistros");
            }
            else
            {
                return RedirectToRoute("ViewRegistros");
            }
        }

        [Route("RemoveMesa")]
        public ActionResult RemoverMesa(int numeroMesa)
        {
            MesasDAO dao = new MesasDAO();
            if (dao.BuscaPorNumero(numeroMesa) == null)
            {
                ModelState.AddModelError("mesaNaoExiste", "Mesa com esse numero não existe");
            }
            if (ModelState.IsValid)
            {
                dao.Excluir(numeroMesa);
                return RedirectToRoute("ViewRegistros");
            }
            else
            {
                return RedirectToRoute("ViewRegistros");
            }
        }




    }
}