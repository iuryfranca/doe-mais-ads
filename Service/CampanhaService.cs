using doe_mais_ads.Context;
using doe_mais_ads.Models;
using Microsoft.EntityFrameworkCore;

namespace doe_mais_ads.Service
{
    public class CampanhaService
    {
        private readonly ContextoBD _context;

        public CampanhaService(ContextoBD con)
        {
            _context = con;
        }

        public async Task<List<CampanhaDoacao>>? GetAllCampanhas()
        {
            return await _context.Campanhas.Include(c => c.Criador).ToListAsync();
        }

        public async Task<List<CampanhaDoacao>> GetPesquisaCampanha(string pesquisa)
        {
            return await _context
                .Campanhas.Include(c => c.Criador)
                .Where(c =>
                    (c.Descricao != null && c.Descricao.Contains(pesquisa))
                    || (c.Nome != null && c.Nome.Contains(pesquisa))
                )
                .ToListAsync();
        }

        public async Task<CampanhaDoacao?> GetCampanha(int id)
        {
            return await _context
                .Campanhas.Include(c => c.Criador)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task AddCampanha(CampanhaDoacao campanha)
        {
            if (campanha != null)
            {
                await _context.Campanhas.AddAsync(campanha);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException("Campanha não pode ser nula");
            }
        }

        public async Task UpdateCampanha(CampanhaDoacao campanha)
        {
            var campanhaToUpdate = await _context
                .Campanhas.Where(e => e.Id == campanha.Id)
                .FirstOrDefaultAsync();

            if (campanhaToUpdate == null)
            {
                throw new ArgumentNullException("Campanha não pode ser nula");
            }

            campanhaToUpdate.Id = campanha.Id;
            campanhaToUpdate.Nome = campanha.Nome;
            campanhaToUpdate.Descricao = campanha.Descricao;
            campanhaToUpdate.DataInicio = campanha.DataInicio;
            campanhaToUpdate.DataFim = campanha.DataFim;
            campanhaToUpdate.Criador = campanha.Criador;
            campanhaToUpdate.IdCriadorFk = campanha.IdCriadorFk;

            _context.Update(campanhaToUpdate);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var campanha = await _context.Campanhas.FindAsync(id);
            if (campanha != null)
            {
                _context.Campanhas.Remove(campanha);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException("Campanha não pode ser nula");
            }
        }
    }
}
