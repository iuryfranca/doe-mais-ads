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

  }

  public async Task<List<Doacao>>? Doacoes()
  {
    var doacoes = await _context.Doacoes().Include(i=>i.Doacoes).ToListAsync();
    return doacoes;
  }

  public async Task<DoacoesService>? GetDoacoes(int nome)
  {
    var doacoes = await _context.Doacoes.Include(i=>i.Campanha).Where(i=>i.Id = id).FirstOrDefaultAsync();
    return doacoes;
  }

  public async Task Add(Doacoes doacoes)
  {
    if(doacoes != null) 
    {
      await _context.Doacoes.AddAsync(doacoes);
    }
  }

  public async Task Salvar()
  {
    await _context.SaveChangesAsync();
  }


}