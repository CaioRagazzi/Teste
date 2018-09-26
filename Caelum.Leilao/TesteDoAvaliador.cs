using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{

    class TesteDoAvaliador
    {

        public static void Main(String[] args) 
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

            Console.WriteLine(maiorEsperado == avaliador.MaiorLance);
            Console.WriteLine(menorEsperado == avaliador.MenorLance);
            Console.WriteLine(avaliador.MediaLances(leilao));

            Palindromo palindromo = new Palindromo();

            Console.WriteLine(palindromo.EhPalindromo("Socorram-me subi no onibus em Marrocos"));
            Console.ReadKey();
        }
    }
}
