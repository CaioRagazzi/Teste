using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Caelum.Leilao.Tests
{
    [TestClass]
    public class AvaliadorTest
    {
        [TestInitialize]
        public void teste()
        {
            Console.WriteLine("testeeeeeeeeeeeeeeeeeee");
        }
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
            leilao.Propoe(new Lance(joao, 7500));
            leilao.Propoe(new Lance(jose, 933));

            Avaliador avaliador = new Avaliador();
            avaliador.Avalia(leilao);

            double menorEsperado = 933;
            double maiorEsperado = 7500;

            Assert.AreEqual(maiorEsperado, avaliador.MaiorLance);
            Assert.AreEqual(avaliador.MenorLance, menorEsperado);
        }

        [TestMethod]
        public void CalculaMedia()
        {
            Leilao leilao = new Leilao("Teste");
            Usuario usuario = new Usuario("Caio");
            Usuario usuario2 = new Usuario("Aline");
            Lance lance = new Lance(usuario, 2000);
            Lance lance2 = new Lance(usuario2, 3000);
            Avaliador avaliador = new Avaliador();

            leilao.Propoe(lance);
            leilao.Propoe(lance2);

            int totalDeLances = leilao.Lances.Count;
            double somaDosLances = 0;

            foreach (var item in leilao.Lances)
            {
                somaDosLances += item.Valor;
            }

            double mediaEsperada = 2500;

            Assert.AreEqual(mediaEsperada, avaliador.MediaLances(leilao));

        }

        [TestMethod]
        public void DeveEntenderLeilaoComApenasUmLance()
        {
            Leilao leilao = new Leilao("Casa");
            Usuario caio = new Usuario("Caio");
            Lance lance = new Lance(caio, 1000);
            leilao.Propoe(lance);

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(1000, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(1000, leiloeiro.MenorLance, 0.0001);
        }

        [TestMethod]
        public void VerificaSePalindromoEstaCerto()
        {
            Palindromo palindromo = new Palindromo();

            bool check = palindromo.EhPalindromo("Socorram-me subi no onibus em Marrocos");

            Assert.IsTrue(check);
        }

        [TestMethod]
        public void DeveEncontrarOsTresMaioresLances()
        {
            Usuario caio = new Usuario("Caio");
            Usuario aline = new Usuario("Aline");

            Leilao leilao = new Leilao("Carro");

            leilao.Propoe(new Lance(caio, 500));
            leilao.Propoe(new Lance(aline, 1000));
            leilao.Propoe(new Lance(caio, 1500));
            leilao.Propoe(new Lance(aline, 2000));

            Avaliador leiloeiro = new Avaliador();

            leiloeiro.Avalia(leilao);
            var maiores = leiloeiro.Maiores;

            Assert.AreEqual(2000, leiloeiro.MaiorLance);
            Assert.AreEqual(4, maiores.Count);
            Assert.AreEqual(2000, maiores[0].Valor, 0.0001);
            Assert.AreEqual(1500, maiores[1].Valor, 0.0001);
            Assert.AreEqual(1000, maiores[2].Valor, 0.0001);
        }

        [TestMethod]
        public void DeveEncontrarOsDoisMaioresLances()
        {
            Usuario caio = new Usuario("Caio");
            Usuario aline = new Usuario("Aline");

            Leilao leilao = new Leilao("Carro");

            leilao.Propoe(new Lance(caio, 500));
            leilao.Propoe(new Lance(aline, 1000));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.Maiores;

            Assert.AreEqual(2, maiores.Count);
            Assert.AreEqual(1000, maiores[0].Valor);
            Assert.AreEqual(500, maiores[1].Valor);

        }

        [TestMethod]
        public void DeveRetornarListaVazia()
        {
            Usuario caio = new Usuario("Caio");
            Usuario aline = new Usuario("Aline");

            Leilao leilao = new Leilao("Carro");

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.Maiores;

            Assert.AreEqual(0, maiores.Count);
        }

        [TestMethod]
        public void ValidaContaMaluca()
        {
            MatematicaMaluca conta = new MatematicaMaluca();

            var result = conta.ContaMaluca(31);
            var result2 = conta.ContaMaluca(15);
            var result3 = conta.ContaMaluca(1);

            Assert.AreEqual(result, 31 * 4);
            Assert.AreEqual(result2, 15 * 3);
            Assert.AreEqual(result3, 1 * 2);
        }
    }
}
