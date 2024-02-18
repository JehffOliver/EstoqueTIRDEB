namespace EstoqueTIRDEB.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        // Construtor sem parâmetros para atender aos requisitos do ASP.NET Core
        public Categoria()
        {
        }

        // Construtor que aceita os parâmetros necessários para criar uma categoria
        public Categoria(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        // Método para adicionar uma nova categoria
        public static Categoria AdicionarCategoria(string nome)
        {
            // Lógica para adicionar uma nova categoria ao sistema
            // Aqui você pode usar o Entity Framework para persistir a categoria no banco de dados
            return new Categoria { Nome = nome }; // Retorna uma nova instância de Categoria com o nome fornecido
        }

        // Método para remover uma categoria existente (opcional)
        public static void RemoverCategoria(Categoria categoria)
        {
            // Lógica para remover a categoria do sistema
            // Aqui você pode usar o Entity Framework para excluir a categoria do banco de dados
            // Exemplo: _context.Categorias.Remove(categoria);
        }
    }
}
