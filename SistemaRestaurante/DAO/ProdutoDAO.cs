﻿using SistemaRestaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaRestaurante.DAO
{
    public class ProdutoDAO 
    {

        public void Adiciona(Produto produto)
        {
            using (var contexto = new RestauranteContext())
            {
                contexto.Produtos.Add(produto);
                contexto.SaveChanges();
            }
        }

        public IList<Produto> Listar()
        {
            using (var contexto = new RestauranteContext())
            {
                
                return contexto.Produtos.ToList();
                

            }
        }

        public void Atualizar(Produto produto)
        {
            using (var contexto = new RestauranteContext())
            {
                Produto atualizado = Listar().Where(p => p.Id == produto.Id).FirstOrDefault();
                atualizado = produto;
                contexto.SaveChanges();
            }
        }

        public void Excluir(Produto produto)
        {
            using (var contexto = new RestauranteContext())
            {
                contexto.Produtos.Remove(produto);
                contexto.SaveChanges();
                
            }
        }

        public Produto BuscaPorId(int id)
        {
            using (var contexto = new RestauranteContext())
            {
                return contexto.Produtos.Find(id);
            }
        }









    }
}