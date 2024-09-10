using doe_mais_ads.Context;
using doe_mais_ads.Models;
using Microsoft.EntityFrameworkCore;

namespace doe_mais_ads.Service
{
    public class DoacoesService
    {
        private readonly ContextoBD _context;

        public DoacoesService(ContextoBD con)
        {
            _context = con;
        }

        public async Task<List<Doacao>>? Doacoes()
        {
            return await _context.Doacoes.ToListAsync();
        }

        public async Task<Doacao?> GetDoacao(int id)
        {
            return await _context.Doacoes.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Doacao>> GetPesquisaDoacao(string pesquisa)
        {
            return await _context
                .Doacoes.Where(i => i.Descricao != null && i.Descricao.Contains(pesquisa))
                .ToListAsync();
        }

        public async Task Add(Doacao doacoes)
        {
            if (doacoes != null)
            {
                doacoes.CreatedAt = DateTime.Now;
                await _context.Doacoes.AddAsync(doacoes);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException("Doacoes não pode ser nulo");
            }
        }

        public async Task Update(Doacao doacoes)
        {
            if (doacoes != null)
            {
                _context.Update(doacoes);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException("Doacoes não pode ser nulo");
            }
        }

        public async Task Delete(int id)
        {
            var doacoes = await _context.Doacoes.Where(i => i.Id == id).FirstOrDefaultAsync();
            if (doacoes != null)
            {
                _context.Doacoes.Remove(doacoes);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException("Doacoes não pode ser nulo");
            }
        }
    }
}
