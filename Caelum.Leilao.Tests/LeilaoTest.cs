using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Caelum.Leilao.Tests
{
    [TestClass]
    public class LeilaoTest
    {
        [TestMethod]
        public void UsuarioNaoPodeDar2LancesEmSequencia()
        {
            Leilao leilao = new Leilao("Carro");

            leilao.Propoe(new Lance(new Usuario("caiasdasdasdoasdasd"), 1000));
            leilao.Propoe(new Lance(new Usuario("aline"), 2000));
            leilao.Propoe(new Lance(new Usuario("caio"), 3000));
            leilao.Propoe(new Lance(new Usuario("caio"), 4000));

            Assert.AreEqual(3, leilao.Lances.Count);
            Assert.AreEqual(1000, leilao.Lances[0].Valor);
            Assert.AreEqual(3000, leilao.Lances[2].Valor);
        }

        [TestMethod]
        public void UsuarioNaoPodeDarMaisQue5LancesEmSequencia()
        {
            Leilao leilao = new Leilao("Carro");

            leilao.Propoe(new Lance(new Usuario("caio"), 1000));
            leilao.Propoe(new Lance(new Usuario("aline"), 2000));

            leilao.Propoe(new Lance(new Usuario("caio"), 3000));
            leilao.Propoe(new Lance(new Usuario("aline"), 4000));

            leilao.Propoe(new Lance(new Usuario("caio"), 5000));
            leilao.Propoe(new Lance(new Usuario("aline"), 6000));

            leilao.Propoe(new Lance(new Usuario("caio"), 7000));
            leilao.Propoe(new Lance(new Usuario("aline"), 8000));

            leilao.Propoe(new Lance(new Usuario("caio"), 9000));
            leilao.Propoe(new Lance(new Usuario("aline"), 10000));

            leilao.Propoe(new Lance(new Usuario("caio"), 11000));

            Assert.AreEqual(10, leilao.Lances.Count);
            Assert.AreEqual(10000, leilao.Lances[leilao.Lances.Count - 1].Valor);
        }

        [TestMethod]
        public void TesteDeLanceDobrado()
        {
            Leilao leilao = new Leilao("Carro");
            Usuario caio = new Usuario("caio");
            Usuario aline = new Usuario("aline");

            leilao.Propoe(new Lance(caio, 1000));
            leilao.Propoe(new Lance(aline, 2000));
            leilao.Propoe(new Lance(caio, 3000));
            leilao.Propoe(new Lance(aline, 4000));

            leilao.DobrarLance(caio);

            Assert.AreEqual(5, leilao.Lances.Count);
            Assert.AreEqual(6000, leilao.Lances[leilao.Lances.Count - 1].Valor);
        }

        [TestMethod]
        public void TesteDeLanceDobradoSemLanceDoUsuario()
        {
            Leilao leilao = new Leilao("Carro");

            Usuario caio = new Usuario("caio");
            Usuario aline = new Usuario("aline");

            leilao.Propoe(new Lance(caio, 1000));

            leilao.DobrarLance(aline);

            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(1000, leilao.Lances[0].Valor);
        }
    }
}
