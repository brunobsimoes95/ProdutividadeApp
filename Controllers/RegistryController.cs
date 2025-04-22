using ProdutividadeApp.Models;
using ProdutividadeApp.Services;


namespace ProdutividadeApp.Controllers
{
    // Controlador responsável por criar registos de ligação entre Mood e Produtividade
    public static class RegistryController
    {
        // Método cria uma ligação entre um registo de humor e um registo de produtividade
        public static async Task CriarLigacao(RegistryService service, int moodId, int prodId)
        {
            var registo = new Registry
            {
                MoodEntryId = moodId,
                ProductivityEntryId = prodId,
                PessoaId = PessoaSessao.IdAtual,
                Data = DateTime.Now
            };

            await service.SaveAsync(registo);
        }


    }

}
