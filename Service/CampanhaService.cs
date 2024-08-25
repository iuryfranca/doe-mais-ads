using doe_mais_ads.Service
using doe_mais_ads.Models;
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

    public async Task<List<Camapanha>>? Campanhas()
    {
      var camp = await _context.Campanhas.Include(c=>c.Campanha).ToListAsync();
      return camp;
    }

    public async Task<CampanhaService>? GetCampanha(string id)
    {
      var camp = await _context.Campanhas.Include(c=>c.Campanha).Where(c=>c.Id == id).FirstOrDefaultAsync();
      return camp;
    }

    
    
  }
}