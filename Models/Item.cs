using System.ComponentModel.DataAnnotations.Schema;

[Table ("item")]
public class Item{
  [Column("id")]
  public int? Id { get; set; }

  [Column("nome")]
  public string? Nome { get; set; }

  [Column("descricao")]
  public string? Descricao { get; set;}

  
}


