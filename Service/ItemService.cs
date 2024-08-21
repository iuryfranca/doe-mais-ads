namespace doe_mais_ads.Service
{
  public class ItemService
  {
    private readonly ContextoBD _context;

    public ItemService(ContextoBD con) 
    {
      _context = con;
    }

    public async Task<List<Item>>? Itens()
    {
      var itens = await _context.Itens.Include(i=>i.Doacoes).ToListAsync();
      return itens;
    }

    public async Task<Item>? GetItem(int id)
    {
      var itens = await _context.Itens.Include(i=>i.Doacoes).Where(i=>i.Id == id).FirstOrDefaultAsync();
      return itens;
    }

    public async Task<Item>? GetItem(string nome)
    {
      var itens = await _context.Itens.Include(i=>i.Item).Where(i=> i.Nome == nome).FirstOrDefaultAsync();
      return itens;
    }
    public async Task Add(Item item)
    {
      if(item != null)
      {
        await _context.Itens.AddAsync(item);
      }
    }

    public async Task Salvar()
    {
     await _context.SaveChangesAsync();
    }

  }
  
}
