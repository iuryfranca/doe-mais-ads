using Microsoft.EntityFrameworkCore;

namespace doe_mais_ads.Service
{
    public class EntidadeService
    {
        private readonly ContextoBD _context;

        public EntidadeService(ContextoBD con)
        {
            _context = con;
        }

        public async Task<List<Entidade>>? GetAllEntidades()
        {
            return await _context.Entidade.ToListAsync();
        }

        public async Task<List<Entidade>> GetPesquisaEntidade(string pesquisa)
        {
            return await _context
                .Entidade.Where(c =>
                    (c.Nome != null && c.Nome.Contains(pesquisa))
                    || (c.Email != null && c.Email.Contains(pesquisa))
                    || (c.Cpf != null && c.Cpf.Contains(pesquisa))
                    || (c.NomeFantasia != null && c.NomeFantasia.Contains(pesquisa))
                    || (c.Cnpj != null && c.Cnpj.Contains(pesquisa))
                )
                .ToListAsync();
        }

        public async Task<Entidade?> GetEntidade(int id)
        {
            return await _context.Entidade.Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task Add(Entidade entidade)
        {
            if (entidade != null)
            {
                await _context.Entidade.AddAsync(entidade);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException("Entidade não pode ser nula");
            }
        }

        public async Task Update(Entidade entidade)
        {
            if (entidade != null)
            {
                _context.Entidade.Update(entidade);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException("Entidade não pode ser nula");
            }
        }

        public async Task Delete(int id)
        {
            var entidade = await _context.Entidade.Where(e => e.Id == id).FirstOrDefaultAsync();
            if (entidade != null)
            {
                _context.Entidade.Remove(entidade);
                await _context.SaveChangesAsync();
            }
        }
    }
}
