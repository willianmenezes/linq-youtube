using System;
using System.Collections.Generic;
using System.Linq;

namespace ExemplosLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            // FONTE DE DADOS
            var listaProdutos = new List<Produto>()
            {
                new Produto{Id = 9, CategoriaId = 2, Nome = "Geladeira", Status = true, Valor = 10},
                new Produto{Id = 2, CategoriaId = 3, Nome = "Short", Status = true, Valor = 1},
                new Produto{Id = 4, CategoriaId = 1, Nome = "Maquina de lavar", Status = false, Valor = 32},
                new Produto{Id = 3, CategoriaId = 1, Nome = "Video Game", Status = true, Valor = 99},
                new Produto{Id = 6, CategoriaId = 2, Nome = "Arroz", Status = true, Valor = 55},
                new Produto{Id = 8, CategoriaId = 1, Nome = "TV", Status = true, Valor = 45},
                new Produto{Id = 1, CategoriaId = 3, Nome = "Camiseta", Status = true, Valor = 100},
                new Produto{Id = 5, CategoriaId = 1, Nome = "Microondas", Status = true, Valor = 90},
                new Produto{Id = 7, CategoriaId = 2, Nome = "Feijão", Status = true, Valor = 12},
            };

            var listaCategorias = new List<Categoria>()
            {
                new Categoria{Id = 1, Status = true, Nome = "Eletronicos"},
                new Categoria{Id = 2, Status = true, Nome = "Alimentos"},
                new Categoria{Id = 3, Status = true, Nome = "Vestuario"},
            };

            var resultado = from prod in listaProdutos
                            join cat in listaCategorias
                            on prod.CategoriaId equals cat.Id
                            select new
                            {
                                Produto = prod,
                                Categoria = cat
                            };

            //EXECUTAR A CONSULTA
            foreach (var result in resultado)
            {
                Console.WriteLine($"Nome: {result.Produto.Nome} | Categoria: {result.Categoria.Nome}");
            }
        }
    }

    class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }
        public decimal Valor { get; set; }
        public int CategoriaId { get; set; }
    }

    class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }
    }

    class ProdutoDto
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public bool Status { get; set; }
    }
}
