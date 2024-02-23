﻿using EstoqueTIRDEB.Data;
using EstoqueTIRDEB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueTIRDEB.Services
{
    public class ItensService
    {
        private readonly EstoqueTIRDEBContext _context;

        public ItensService(EstoqueTIRDEBContext context)
        {
            _context = context;
        }

        public List<Itens> FindAll()
        {
            return _context.Itens.ToList();
        }

        public Itens FindById(int id)
        {
            return _context.Itens.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Itens.Find(id);
            _context.Itens.Remove(obj);
            _context.SaveChanges();
        }

        public void Insert(Itens obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public void Update(Itens obj)
        {
            _context.Entry(obj).State = EntityState.Modified; // Informar que o objeto foi modificado
            _context.SaveChanges(); // Salvar as alterações
        }

        public List<Itens> ListarPorCategoria(int categoriaId)
        {
            return _context.Itens.Where(i => i.CategoriaId == categoriaId).ToList();
        }

        public void AdicionarItemAoEstoque(Itens item, int categoriaId)
        {
            var categoria = _context.Categoria.Find(categoriaId);
            if (categoria == null)
            {
                // Tratar erro de categoria não encontrada
                return;
            }

            item.CategoriaId = categoriaId;
            _context.Itens.Add(item);
            _context.SaveChanges();
        }

        public List<Itens> FindAllWithCategoria()
        {
            return _context.Itens.Include(i => i.Categoria).ToList();
        }

        public void RemoverItemPorId(int itemId, int quantidade)
        {
            var item = _context.Itens.Find(itemId);

            if (item != null)
            {
                // Verifica se a quantidade a ser removida é menor ou igual à quantidade disponível
                if (quantidade <= item.Quantidade)
                {
                    item.Quantidade -= quantidade;

                    // Atualiza o item no banco de dados
                    _context.Itens.Update(item);
                    _context.SaveChanges();
                }
                else
                {
                    // Caso a quantidade especificada seja maior do que a disponível, lançar uma exceção ou lidar de acordo com a lógica do seu sistema
                    throw new InvalidOperationException("Quantidade especificada maior do que a quantidade disponível.");
                }
            }
            else
            {
                // Caso o item não seja encontrado, lançar uma exceção ou lidar de acordo com a lógica do seu sistema
                throw new KeyNotFoundException("Item não encontrado.");
            }
        }

        public void RemoverItem(int itemId)
        {
            // Encontre o item pelo ID
            var item = _context.Itens.Find(itemId);

            if (item == null)
            {
                throw new ArgumentException("Item não encontrado.");
            }

            try
            {
                // Remova o item do banco de dados
                _context.Itens.Remove(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Lide com exceções, se necessário
                throw new Exception("Erro ao remover o item do estoque.", ex);
            }
        }
    }
}