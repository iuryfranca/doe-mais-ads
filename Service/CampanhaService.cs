using doe_mais_ads.Service;
using Microsoft.EntityFrameworkCore;

namespace doe_mais_ads.Services
{
  public class CampanhaService
  {
    private readonly ContextoBD _context;

    public CampanhaService(ContextoBD con)
    {
      _context = con;
    }

    public async Task<List<CampanhaDoacao>>? Campanhas()
    {
      var camp = await _context.CampanhasDoacoes.Include(c=>c.Criador).ToListAsync();
      return camp;
    }

    public async Task<CampanhaDoacao>? GetCampanha(int id)
    {
      var camp = await _context.CampanhasDoacoes.Include(c=>c.Criador).Where(c=>c.Id == id).FirstOrDefaultAsync();
      return camp;
    }

    
    
  }
}