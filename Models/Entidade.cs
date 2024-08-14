using System.ComponentModel.DataAnnotations.Schema;

[Table ("entidade")]
public class Entidade{
  [Column("id")]
  public int? Id { get; set; }

  [Column("nome")]
  public string? Nome { get; set; }

  [Column("nome_fantasia")]
  public string? NomeFantasia { get; set;}

  [Column("cpf")]
  public String? Cpf { get; set; }

  [Column("cnpj")]
  public string? Cnpj { get; set; }

  [Column("email")]
  public string? Email { get; set; }

  [Column("telefone")]
  public string? Telefone { get; set; }
  
}


