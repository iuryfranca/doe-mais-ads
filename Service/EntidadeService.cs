using doe_mais_ads.Context;
using doe_mais_ads.Models;
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

        public async Task<List<Entity>> GetAllEntidades()
        {
            return await _context.Entities.ToListAsync();
        }

        public async Task<List<Entity>> GetPesquisaEntidade(string pesquisa)
        {
            return await _context
                .Entities.Where(c =>
                    (c.Nome != null && c.Nome.Contains(pesquisa))
                    || (c.Email != null && c.Email.Contains(pesquisa))
                    || (c.Cpf != null && c.Cpf.Contains(pesquisa))
                    || (c.NomeFantasia != null && c.NomeFantasia.Contains(pesquisa))
                    || (c.Cnpj != null && c.Cnpj.Contains(pesquisa))
                )
                .ToListAsync();
        }

        public async Task<Entity?> GetEntidade(int id)
        {
            return await _context.Entities.Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddEntidade(Entity entidade)
        {
            if (entidade != null)
            {
                await _context.Entities.AddAsync(entidade);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException("Entity não pode ser nula");
            }
        }

        public async Task UpdateEntidade(Entity entidade)
        {
            var entityToUpdate = await _context
                .Entities.Where(e => e.Id == entidade.Id)
                .FirstOrDefaultAsync();

            if (entityToUpdate == null)
            {
                throw new ArgumentNullException("Entity não encontrada");
            }

            entityToUpdate.Nome = entidade.Nome;
            entityToUpdate.NomeFantasia = entidade.NomeFantasia;
            entityToUpdate.Cpf = entidade.Cpf;
            entityToUpdate.Cnpj = entidade.Cnpj;
            entityToUpdate.Email = entidade.Email;
            entityToUpdate.Telefone = entidade.Telefone;
            entityToUpdate.IsPessoaFisica = entidade.IsPessoaFisica;

            _context.Update(entityToUpdate);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntidade(int id)
        {
            var entidade = await _context.Entities.Where(e => e.Id == id).FirstOrDefaultAsync();
            if (entidade != null)
            {
                _context.Entities.Remove(entidade);
                await _context.SaveChangesAsync();
            }
        }
    }
}
