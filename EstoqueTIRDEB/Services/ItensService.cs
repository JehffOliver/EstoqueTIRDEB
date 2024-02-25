using EstoqueTIRDEB.Data;
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
        private readonly RetiradaEstoqueService _retiradaEstoqueService;

        public ItensService(EstoqueTIRDEBContext context, RetiradaEstoqueService retiradaEstoqueService)
        {
            _context = context;
            _retiradaEstoqueService = retiradaEstoqueService;
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

                    // Cria um registro de retirada de estoque
                    var retiradaEstoque = new RetiradaEstoque
                    {
                        DataHoraRetirada = DateTime.Now,
                        ItemId = itemId,
                        QuantidadeRetirada = quantidade
                        
                    };

                    _context.Itens.Update(item);
                    _context.RetiradaEstoque.Add(retiradaEstoque); // Adiciona o registro de retirada de estoque ao contexto
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

        public void RemoverItem(int itemId, int quantidade)
        {
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

                // Registre a retirada de estoque
                var retiradaEstoque = new RetiradaEstoque
                {
                    ItemId = itemId,
                    QuantidadeRetirada = quantidade,
                    DataHoraRetirada = DateTime.Now
                    // Você pode adicionar outras informações relevantes aqui, como o usuário que fez a retirada, etc.
                };

                _retiradaEstoqueService.Create(retiradaEstoque); // Você precisa ter um método Create no seu serviço de RetiradaEstoque
            }
            catch (Exception ex)
            {
                // Lide com exceções, se necessário
                throw new Exception("Erro ao remover o item do estoque.", ex);
            }
        }

        public IEnumerable<Itens> GetAll()
        {
            // Lógica para obter todos os itens do serviço
            return _context.Itens.ToList();
        }

        public Itens GetById(int id)
        {
            return _context.Itens.FirstOrDefault(i => i.Id == id);
        }
    }
}