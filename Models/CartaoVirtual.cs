using System.ComponentModel.DataAnnotations;

public class CartaoVirtual
{
  public long Id { get; set; }

  [Required]
  [EmailAddress]
  public string Email { get; set; }
  public string NumeroDoCartao { get; set; }
}