using doe_mais_ads.Models;
using Microsoft.EntityFrameworkCore;

namespace doe_mais_ads.Context;

public class ContextoBD : DbContext
{
    public ContextoBD(DbContextOptions<ContextoBD> options)
        : base(options) { }

    public DbSet<Entity> Entities { get; set; }
    public DbSet<Item> Itens { get; set; }
    public DbSet<Doacao> Doacoes { get; set; }
    public DbSet<ItemDoacao> ItemsDoacaoes { get; set; }
    public DbSet<CampanhaDoacao> Campanhas { get; set; }
}
