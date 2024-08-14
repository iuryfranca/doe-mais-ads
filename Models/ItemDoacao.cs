using System.ComponentModel.DataAnnotations.Schema;

[Table("item_doacao")]
public class ItemDoacao{
  [Column ("id")]
  public int? Id { get; set; }

  [Column ("quantidade")]
  public int? Quantidade { get; set; }

  [Column("id_doacao_fk")]
  public int? IdDoacaoFk { get; set; }

  [ForeignKey("IdDoacaoFk")]
  public Doacao? Doacao{ get; set;}

  [Column("id_item_fk")]
  public int? IdItemFk { get; set; }

  [ForeignKey("IdItemFk")]
  public Item? Item{ get; set;}
}