using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiVaiVoa.Models;
using System.Linq;
using System;

namespace apiVaiVoa.Controllers
{
  [Route("v1/vaivoa/cartoes")]
  [ApiController]
  public class CartaoVirtualController : ControllerBase
  {
    private static Random random = new Random();

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<string>> PostCartao(
      [FromServices] CartaoVirtualContext context,
      [FromBody] CartaoVirtual cartao)
    {
      const string chars = "0123456789";
      string novoNumero = new string(Enumerable.Repeat(chars, 16)
      .Select(s => s[random.Next(s.Length)]).ToArray());

      cartao.Email = cartao.Email;
      cartao.NumeroDoCartao = String.Format("{0:#### #### #### ####}", long.Parse(novoNumero));

      context.CarataoVirtual.Add(cartao);
      await context.SaveChangesAsync();

      return cartao.NumeroDoCartao;
    }

    [HttpGet]
    [Route("{email}")]
    public async Task<ActionResult<List<CartaoVirtual>>> GetCartoes(
      [FromServices] CartaoVirtualContext context, string email)
    {
      var cartoes = await context.CarataoVirtual
      .Where(x => x.Email == email)
      .ToListAsync();

      if (!cartoes.Any())
      {
        return NotFound("Nenhum cartão encontrado, solicite um novo cartão e tente novamente!");
      }

      return cartoes;
    }
  }
}