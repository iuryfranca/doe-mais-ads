using doe_mais_ads.Service
using doe_mais_ads.Models;
using Microsoft.EntityFrameworkCore;


namespace doe_mais_ads.Service 
{
  public class EntidadeService
  {
    private readonly ContextoBD _contexto;

    public EntidadeService(ContextoBD con)
    {
      _contexto = con;
    }

    public async Task<List<Entidade>>? Entidade()
    {
      var entidades = await _contexto.Entidade.Include(e=>e.Entidade).ToListAsync();
      return entidades;
    }

    public async Task<Entidade>? GetEntidade(string entidade)
    {
      var entidade = await _context.Entidade(e=>e.Entidade).Where(e=>e.Nome = nome).FirstOrDefaultAsunc();
      return entidade;
    }

    public async Task Add(Entidade entidade)
    {
      if (entidade != null)
      {
        await _contexto.Entidades.AddAsync(entidade);
      }
    }

    public async Task Salvar()
    {
      await _contexto.SaveChangesAsync();
    }
    

  }
}