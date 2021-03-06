﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Web;
using SistemaRestaurante.Models;

namespace SistemaRestaurante.DAO
{
    public class ItemPedidoDAO
    {
        public void Adiciona(ItemPedido item)
        {
            using (var contexto = new RestauranteContext())
            {
                contexto.ItensPedido.Add(item);
                contexto.SaveChanges();
            }
        }

        public IList<ItemPedido> Listar()
        {
            using (var contexto = new RestauranteContext())
            {

                return contexto.ItensPedido.Include(ItemPedido => ItemPedido.Produto).ToList();
            }

        }

        public IList<ItemPedido> ListarPorPedido(int pedidoId)
        {
            using (var contexto = new RestauranteContext())
            {

                return contexto.ItensPedido.Include(ItemPedido => ItemPedido.Produto).Where(i => i.PedidoId == pedidoId).ToList();
            }

        }

        public IList<ItemPedido> ListarNaoEntregues()
        {
            using (var contexto = new RestauranteContext())
            {

                return contexto.ItensPedido.Include(ItemPedido => ItemPedido.Produto).Where(i => i.Entregue == false).ToList();
            }

        }

        public IList<ItemPedido> ListarNaoEntreguesPorPedido(int pedidoId)
        {
            using (var contexto = new RestauranteContext())
            {

                return contexto.ItensPedido.Include(ItemPedido => ItemPedido.Produto).Where(i => i.Entregue == false).Where(i => i.PedidoId == pedidoId).ToList();
            }

        }

        public IList<ItemPedido> ListarPorNomeProduto(string nomeProduto)
        {
            using (var contexto = new RestauranteContext())
            {

                return contexto.ItensPedido.Include(ItemPedido => ItemPedido.Produto).Where(i => i.Produto.Nome == nomeProduto).ToList();
            }

        }

        public IList<ItemPedido> ListarEntregues(int pedidoId)
        {
            using (var contexto = new RestauranteContext())
            {

                return contexto.ItensPedido.Include(ItemPedido => ItemPedido.Produto).Where(i => i.Entregue == true).Where(i => i.PedidoId == pedidoId).ToList();
            }

        }

        public void Atualizar(ItemPedido pedido)
        {

            using (var contexto = new RestauranteContext())
            {
                contexto.ItensPedido.Update(pedido);
                contexto.SaveChanges();
            }
        }

        public void Excluir(ItemPedido pedido)
        {
            using (var contexto = new RestauranteContext())
            {
                contexto.ItensPedido.Remove(pedido);
                contexto.SaveChanges();

            }
        }

        public ItemPedido BuscaPorId(int id)
        {
            using (var contexto = new RestauranteContext())
            {
                return contexto.ItensPedido.Find(id);
            }
        }

        public ItemPedido BuscaUltimo()
        {
            using (var contexto = new RestauranteContext())
            {
                return contexto.ItensPedido.LastOrDefault();
            }
        }

        public ItemPedido BuscaPorIdComProduto(int id)
        {
            using (var contexto = new RestauranteContext())
            {
                return contexto.ItensPedido.Include(Item => Item.Produto).FirstOrDefault(i => i.Id == id);
            }
        }
        
       

    }
}