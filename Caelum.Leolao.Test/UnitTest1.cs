using System;
using Caelum.Leilao;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Caelum.Leolao.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DeveEntenderLancesEmOrdemCrescente()
        {
            Usuario joao = new Usuario("João");
            Usuario jose = new Usuario("Jose");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Carro");

            leilao.Propoe(new Lance(joao, 1000));
            leilao.Propoe(new Lance(jose, 4000));
            leilao.Propoe(new Lance(maria, 3000));
            leilao.Propoe(new Lance(maria, 7500));
            leilao.Propoe(new Lance(maria, 933));

            Avaliador avaliador = new Avaliador();
            avaliador.Avalia(leilao);

            double menorEsperado = 933;
            double maiorEsperado = 7500;

            Assert.AreEqual(maiorEsperado, avaliador.maiorDeTodos);
            Assert.AreEqual(avaliador.menorDeTodos, menorEsperado);
        }
}
