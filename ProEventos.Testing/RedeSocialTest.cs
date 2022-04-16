using ProEventos.Domain.Models;
using Xunit;

namespace ProEventos.Testing;

public class RedeSocialTest
{
    [Fact]
    public void CriarRedeSocialValida()
    {
        var redesocial = new RedeSocial("RedeSocial", "url.com");
        Assert.True(redesocial.IsValid);
    }

    [Fact]
    public void CriarRedeSocialInvalida()
    {
        var redesocial = new RedeSocial("", "url.com");
        Assert.False(redesocial.IsValid);
    }
}