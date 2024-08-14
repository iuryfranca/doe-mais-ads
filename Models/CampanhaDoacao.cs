using System.ComponentModel.DataAnnotations.Schema;

[Table ("campanha_doacao")]
public class CampanhaDoacao{
  [Column("id")]
  public int? Id { get; set; }

  [Column("nome")]
  public string? Nome { get; set; }

  [Column("descricao")]
  public string? Descricao { get; set;}

  [Column("data_inicio")]
  public DateTime? DataInicio { get; set; }

  [Column("data_fim")]
  public DateTime? DataFim { get; set; }

  [Column("id_criador_fk")]
  public int? IdCriadorFk { get; set; }

  [ForeignKey("IdCriadorFk")]
  public Criador? Criador { get; set;}
  
}


