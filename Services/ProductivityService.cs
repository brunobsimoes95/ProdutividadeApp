using ProdutividadeApp.Models;
using SQLite;

namespace ProdutividadeApp.Services
{
    // Serviço responsável por gerir a tabela de produtividade
    public class ProductivityService
    {
        private readonly SQLiteAsyncConnection _db;

        // Construtor e criar tabela s nao existir
        public ProductivityService(SQLiteAsyncConnection db)
        {
            _db = db;
            _db.CreateTableAsync<ProductivityEntry>().Wait();
        }

        //todos os registos de produtividade da pessoa com sessão ativa
        public async Task<List<ProductivityEntry>> GetAllAsync()
        {
            return await _db.Table<ProductivityEntry>()
                            .Where(p => p.PessoaId == PessoaSessao.IdAtual)
                            .ToListAsync();
        }

        //registo específico por ID
        public async Task<ProductivityEntry?> GetByIdAsync(int id)
        {
            return await _db.Table<ProductivityEntry>()
                             .Where(p => p.Id == id)
                             .FirstOrDefaultAsync();
        }

        public async Task<int> SaveAsync(ProductivityEntry entry)
        {
            if (entry.Id != 0)
                return await _db.UpdateAsync(entry);

            return await _db.InsertAsync(entry);
        }

        public Task<int> DeleteAsync(ProductivityEntry entry)
        {
            return _db.DeleteAsync(entry);
        }
    }
}
