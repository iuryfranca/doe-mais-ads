using Microsoft.EntityFrameworkCore;

public class ContextoBD : DbContext
{
    public ContextoBD(DbContextOptions<ContextoBD> options)
        : base(options) { }

    public DbSet<Entidade> Entidade { get; set; }
    public DbSet<Item> Itens { get; set; }
    public DbSet<Doacao> Doacoes { get; set; }
    public DbSet<ItemDoacao> Items { get; set; }
    public DbSet<CampanhaDoacao> Campanhas { get; set; }

    internal async Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}
