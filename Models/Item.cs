using System.ComponentModel.DataAnnotations.Schema;

namespace doe_mais_ads.Models;

[Table("item")]
public class Item
{
    [Column("id")]
    public int? Id { get; set; }

    [Column("nome")]
    public string? Nome { get; set; }

    [Column("descricao")]
    public string? Descricao { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}
