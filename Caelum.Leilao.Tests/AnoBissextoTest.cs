using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Caelum.Leilao.Tests
{
    [TestClass]
    public class AnoBissextoTest
    {
        [TestMethod]
        public void TestaSeEhAnoBisexto()
        {
            AnoBissexto anoBissexto = new AnoBissexto();

            bool resultado = anoBissexto.EhBissexto(2018);
            bool resultado2 = anoBissexto.EhBissexto(2020);
            bool resultado3 = anoBissexto.EhBissexto(2020 + 4);
            bool resultado4 = anoBissexto.EhBissexto(2020 + 400);
            bool resultado5 = anoBissexto.EhBissexto(2020 + 101);

            Assert.AreEqual(false, resultado);
            Assert.AreEqual(true, resultado2);
            Assert.AreEqual(true, resultado3);
            Assert.AreEqual(true, resultado4);
            Assert.AreEqual(false, resultado5);
        }
    }
}