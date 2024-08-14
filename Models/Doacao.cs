using System.ComponentModel.DataAnnotations.Schema;

[Table ("doacao")]
public class Doacao{
  [Column("id")]
  public int? Id { get; set; }

  [Column("descricao")]
  public string? Descricao { get; set;}


  [Column("id_entidade_doador_fk")]
  public int? IdEntidadeDoadorFk { get; set; }

  [ForeignKey("IdEntidadeDoadorFk")]
  public EntidadeDoador? EntidadeDoador{ get; set;}

  [Column("id_entidade_recebedor_fk")]
  public int? IdEntidadeRecebedorFk { get; set; }

  [ForeignKey("IdEntidadeRecebedorFk")]
  public EntidadeRecebedor? EntidadeRecebedor{ get; set;}

  [Column("id_campanha_doacao_fk")]
  public int? IdCampanhaDoacaoFk { get; set; }

  [ForeignKey("IdCampanhaDoacaoFk")]
  public CampanhaDoacao? CampanhaDoacao{ get; set;}
  
}


