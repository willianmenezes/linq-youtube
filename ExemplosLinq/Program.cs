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
                new Produto
                {
                    Id = 9, CategoriaId = 2, Nome = "Geladeira", Status = true, Valor = 10,
                    Categorias = new List<Categoria>()
                    {
                        new Categoria()
                        {
                            Id = 1, Nome = "Categoria 01", Status = true
                        },
                        new Categoria()
                        {
                            Id = 2, Nome = "Categoria 02", Status = true
                        }
                    }
                },
                new Produto
                {
                    Id = 2, CategoriaId = 3, Nome = "Short", Status = true, Valor = 1,
                    Categorias = new List<Categoria>()
                    {
                        new Categoria()
                        {
                            Id = 3, Nome = "Categoria 03", Status = true
                        },
                        new Categoria()
                        {
                            Id = 4, Nome = "Categoria 04", Status = true
                        }
                    }
                },
            };

            // select Many 
            var listaCategoria = listaProdutos.SelectMany(prod => new
                List<string>(prod.Categorias.Select(cat => cat.Nome)));

            foreach (var nome in listaCategoria)
            {
                Console.WriteLine($"{nome}");
            }
        }

        class ProdutoResponse
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public decimal Valor { get; set; }
        }

        class Produto
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public bool Status { get; set; }
            public decimal Valor { get; set; }
            public int CategoriaId { get; set; }
            public List<Categoria> Categorias { get; set; }
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
}