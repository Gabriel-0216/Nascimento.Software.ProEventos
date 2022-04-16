using System;
using ProEventos.Domain.Models;
using Xunit;

namespace ProEventos.Testing;

public class EventoTest
{
    [Fact]
    public void CriarEventoCorretamenteRetornaValido()
    {
        var evento = new Evento("Angular", "Salvador", 30,
            Convert.ToDateTime("2022-12-11"), "foto.png");
        Assert.True(evento.IsValid);
    }

    [Fact]
    public void CriarEventoComParametrosNullRetornarInvalido()
    {
        var evento = new Evento(string.Empty, "Salvador", 30, Convert.ToDateTime("2022-12-11"),
            "foto.png");
        Assert.False(evento.IsValid);
    }

    [Fact]
    public void DataMenorQueAtualRetornarInvalido()
    {
        var evento = new Evento(string.Empty, "Salvador", 30, Convert.ToDateTime("2021-12-11"),
            "foto.png");
        Assert.False(evento.IsValid);
    }

    [Fact]
    public void QtdePessoasMenorQueZeroRetornarInvalido()
    {
        var evento = new Evento(string.Empty, "Salvador", 0,
            Convert.ToDateTime("2021-12-11"),
            "foto.png");
        Assert.False(evento.IsValid);
    }

    [Fact]
    public void AdicionaTelefoneValido()
    {
        var evento = new Evento("Angular", "Salvador", 30,
            Convert.ToDateTime("2022-12-11"), "foto.png");
        evento.AdicionaTelefoneEvento(71, "23213213");
        Assert.True(evento.IsValid);
    }

    [Fact]
    public void AdicionarEmailValido()
    {
        var evento = new Evento("Angular", "Salvador", 30,
            Convert.ToDateTime("2022-12-11"), "foto.png");
        evento.AdicionaEmailEvento("gabriel@hotmail.com");
        Assert.True(evento.IsValid);
    }


    [Fact]
    public void AdicionarTelefoneInvalido()
    {
        var evento = new Evento("Angular", "Salvador", 30,
            Convert.ToDateTime("2022-12-11"), "foto.png");
        evento.AdicionaTelefoneEvento(0, string.Empty);
        Assert.False(evento.IsValid);
    }

    [Fact]
    public void AdicionarEmailInvalido()
    {
        var evento = new Evento("Angular", "Salvador", 30,
            Convert.ToDateTime("2022-12-11"), "foto.png");
        evento.AdicionaEmailEvento(string.Empty);
        Assert.False(evento.IsValid);
    }

    [Fact]
    public void AdicionarLoteValido()
    {
        var evento = new Evento("Angular", "Salvador", 30,
            Convert.ToDateTime("2022-12-11"), "foto.png");
        var lote = new Lote("Lote 1", 30.00M, Convert.ToDateTime("2022-12-31"), null, 30, evento);
        evento.AdicionarLote(lote);
        Assert.True(evento.IsValid);
    }

    [Fact]
    public void AdicionarLoteInvalido()
    {
        var evento = new Evento("Angular", "Salvador", 30,
            Convert.ToDateTime("2022-12-11"), "foto.png");
        var lote = new Lote(string.Empty, 30.00M, Convert.ToDateTime("2022-12-31"), null, 30, evento);
        evento.AdicionarLote(lote);
        Assert.False(evento.IsValid);
    }

    [Fact]
    public void AdicionarPalestranteValido()
    {
        var evento = new Evento("Angular", "Salvador", 30,
            Convert.ToDateTime("2022-12-11"), "foto.png");
        var palestrante = new Palestrante("Gabriel", "GABRIEL NASCIMENTO", "foto.png");
        evento.AdicionarPalestrante(palestrante);
        Assert.True(evento.IsValid);
    }

    [Fact]
    public void AdicionarPalestranteInvalido()
    {
        var evento = new Evento("Angular", "Salvador", 30,
            Convert.ToDateTime("2022-12-11"), "foto.png");
        var palestrante = new Palestrante("", "GABRIEL NASCIMENTO", "foto.png");
        evento.AdicionarPalestrante(palestrante);
        Assert.False(evento.IsValid);
    }

    [Fact]
    public void AdicionarRedeSocialValida()
    {
        var evento = new Evento("Angular", "Salvador", 30,
            Convert.ToDateTime("2022-12-11"), "foto.png");
        var redeSocial = new RedeSocial("Teste", "teste.com");
        evento.AdicionaRedeSocial(redeSocial);
        Assert.True(evento.IsValid);
    }

    [Fact]
    public void AdicionarRedeSocialInvalida()
    {
        var evento = new Evento("Angular", "Salvador", 30,
            Convert.ToDateTime("2022-12-11"), "foto.png");
        var redeSocial = new RedeSocial("", "");
        evento.AdicionaRedeSocial(redeSocial);
        Assert.False(evento.IsValid);
    }

    [Fact]
    public void EditarDadosRedeSocialValido()
    {
        var evento = new Evento("Angular", "Salvador", 30,
            Convert.ToDateTime("2022-12-11"), "foto.png");

        evento.EditarDadosEvento("dotnet", "São Paulo", 31,
            Convert.ToDateTime("2022-12-30"), "teste.png");
        Assert.True(evento.IsValid);
    }

    [Fact]
    public void EditarDadosRedeSocialInvalido()
    {
        var evento = new Evento("Angular", "Salvador", 30,
            Convert.ToDateTime("2022-12-11"), "foto.png");

        evento.EditarDadosEvento("", "São Paulo", 31,
            Convert.ToDateTime("2022-12-30"), "teste.png");
        Assert.False(evento.IsValid);
    }

    [Fact]
    public void AdicionarLoteSuperaQtdeIngressos()
    {
        var evento = new Evento("Angular", "Salvador", 30,
            Convert.ToDateTime("2022-12-11"), "foto.png");
        var lote = new Lote("Lote 1", 30.00M,
            new DateTime(2022, 12, 30), null, 31, evento);
        evento.AdicionarLote(lote);
        Assert.False(evento.IsValid);
    }

    [Fact]
    public void AdicionarSegundoLoteSomaSuperaQtdeIngressos()
    {
        var evento = new Evento("Angular", "Salvador", 30,
            Convert.ToDateTime("2022-12-11"), "foto.png");
        var lote = new Lote("Lote 1", 30.00M,
            new DateTime(2022, 12, 30), null, 24, evento);
        evento.AdicionarLote(lote);
        var loteDois = new Lote("Lote 2", 30.00M,
            new DateTime(2022, 12, 30), null, 7, evento);
        evento.AdicionarLote(loteDois);
        Assert.False(evento.IsValid);
    }
}