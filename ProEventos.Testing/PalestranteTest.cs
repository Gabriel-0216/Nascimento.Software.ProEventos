using ProEventos.Domain.Models;
using Xunit;

namespace ProEventos.Testing;

public class PalestranteTest
{
    [Fact]
    public void CriarPalestranteValido()
    {
        var palestrante = new Palestrante("Gabriel", "Gabriel", "foto.png");
        Assert.True(palestrante.IsValid);
    }

    [Fact]
    public void CriarPalestranteInvalido()
    {
        var palestrante = new Palestrante("", "", "foto.png");
        Assert.False(palestrante.IsValid);
    }

    [Fact]
    public void AdicionaTelefoneValido()
    {
        var palestrante = new Palestrante("Gabriel", "Gabriel", "foto.png");
        palestrante.AdicionarTelefonePalestrante(71, "213231");
        Assert.True(palestrante.IsValid);
    }

    [Fact]
    public void AdicionaTelefoneInvalido()
    {
        var palestrante = new Palestrante("Gabriel", "Gabriel", "foto.png");
        palestrante.AdicionarTelefonePalestrante(71, "");
        Assert.False(palestrante.IsValid);
    }

    [Fact]
    public void AdicionaEmailValido()
    {
        var palestrante = new Palestrante("Gabriel", "Gabriel", "foto.png");
        palestrante.AdicionarEmailPalestrante("teste@hotmail.com");
        Assert.True(palestrante.IsValid);
    }

    [Fact]
    public void AdiionaEmailInvalido()
    {
        var palestrante = new Palestrante("Gabriel", "Gabriel", "foto.png");
        palestrante.AdicionarEmailPalestrante("");
        Assert.False(palestrante.IsValid);
    }

    [Fact]
    public void EditarPalestranteValido()
    {
        var palestrante = new Palestrante("Gabriel", "Gabriel", "foto.png");
        palestrante.AlterarDados("Jorge", "Teste", "foto3.png");
        Assert.True(palestrante.IsValid);
    }

    [Fact]
    public void EditarPalestranteInvalido()
    {
        var palestrante = new Palestrante("Gabriel", "Gabriel", "foto.png");
        palestrante.AlterarDados("", "Teste", "foto3.png");
        Assert.False(palestrante.IsValid);
    }

    [Fact]
    public void AdicionarRedeSocialValida()
    {
        var palestrante = new Palestrante("Gabriel", "Gabriel", "foto.png");
        var redeSocial = new RedeSocial("Teste", "teste.com");
        palestrante.AdicionarRedeSocial(redeSocial);
        Assert.True(palestrante.IsValid);
    }

    [Fact]
    public void AdicionarRedeSocialInvalida()
    {
        var palestrante = new Palestrante("Gabriel", "Gabriel", "foto.png");
        var redeSocial = new RedeSocial("Teste", "");
        palestrante.AdicionarRedeSocial(redeSocial);
        Assert.False(palestrante.IsValid);
    }
}