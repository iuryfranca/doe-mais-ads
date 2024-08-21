using doe_mais_ads.Service
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

  }
}