using System;
using System.Collections.Generic;
using EstoqueTIRDEB.Models;

namespace EstoqueTIRDEB.Services
{
    public class RetiradaEstoqueService
    {
        // Simulando um banco de dados em memória para armazenar os registros de retirada de estoque
        private static List<RetiradaEstoque> _registrosRetiradaEstoque = new List<RetiradaEstoque>();

        // Método para retornar todos os registros de retirada de estoque
        public IEnumerable<RetiradaEstoque> GetAll()
        {
            return _registrosRetiradaEstoque;
        }

        // Método para criar um novo registro de retirada de estoque
        public void Create(RetiradaEstoque retiradaEstoque)
        {
            // Simplesmente adiciona o novo registro à lista simulada
            _registrosRetiradaEstoque.Add(retiradaEstoque);
        }

        // Outros métodos conforme necessário (Update, Delete, etc.)
    }
}
