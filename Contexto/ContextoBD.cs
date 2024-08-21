using Microsoft.EntityFrameworkCore;
public class ContextoBD: DbContext
{
  public ContextoBD(DbContextOptions<ContextoBD> options) : base (options)
  {}

  public DbSet<Entidade> Entidades { get; set; }
  public DbSet<Item> Itens { get; set; }
  public DbSet<Doacao> Doacoes { get; set; }
  public DbSet<ItemDoacao> ItensDoacoes { get; set; }
  public DbSet<CampanhaDoacao> CampanhasDoacoes { get; set; }

    internal async Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}