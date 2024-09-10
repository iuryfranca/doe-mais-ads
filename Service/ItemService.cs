using doe_mais_ads.Context;
using doe_mais_ads.Models;
using Microsoft.EntityFrameworkCore;

namespace doe_mais_ads.Service
{
    public class ItemService
    {
        private readonly ContextoBD _context;

        public ItemService(ContextoBD con)
        {
            _context = con;
        }

        public async Task<List<Item>>? getAllItens()
        {
            return await _context.Itens.ToListAsync();
        }

        public async Task<Item?> GetItem(int id)
        {
            return await _context.Itens.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Item>> GetPesquisaItem(string pesquisa)
        {
            return await _context
                .Itens.Where(i =>
                    (i.Nome != null && i.Nome.Contains(pesquisa))
                    || (i.Descricao != null && i.Descricao.Contains(pesquisa))
                )
                .ToListAsync();
        }

        public async Task Add(Item item)
        {
            if (item != null)
            {
                item.CreatedAt = DateTime.Now;
                await _context.Itens.AddAsync(item);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException("Item não pode ser nulo");
            }
        }

        public async Task Update(Item item)
        {
            if (item != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException("Item não pode ser nulo");
            }
        }

        public async Task Delete(int id)
        {
            var item = await _context.Itens.Where(i => i.Id == id).FirstOrDefaultAsync();
            if (item != null)
            {
                _context.Itens.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
