﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaRestaurante.Models
{
    public class ItemPedido
    {
        public ItemPedido()
        {
            Data = DateTime.Now;
        }

        public int Id { get; set; }
        public int PedidoId { get; set; }
        public Produto Produto { get; set; }
        public string Observacao { get; set; }
        public bool Entregue { get; set; }
        public DateTime Data { get; set; }

    }
}