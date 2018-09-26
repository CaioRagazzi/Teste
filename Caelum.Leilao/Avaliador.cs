using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    public class Avaliador
    {
        private double maiorDeTodos = Double.MinValue;
        private double menorDeTodos = Double.MaxValue;
        private List<Lance> maiores;

        public void Avalia(Leilao leilao)
        {
            foreach (var lance in leilao.Lances)
            {
                if (lance.Valor > maiorDeTodos)
                {
                    maiorDeTodos = lance.Valor;
                }
                if (lance.Valor < menorDeTodos)
                {
                    menorDeTodos = lance.Valor;
                }
            }

            PegaOsMaioresNo(leilao);
        }

        private void PegaOsMaioresNo(Leilao leilao)
        {
            maiores = new List<Lance>(leilao.Lances.OrderByDescending(x => x.Valor));
            maiores.GetRange(0, leilao.Lances.Count);
        }

        public List<Lance> Maiores
        {
            get
            { return maiores; }
        }

        public double MaiorLance
        {
            get { return maiorDeTodos; }
        }

        public double MenorLance
        {
            get { return menorDeTodos; }
        }

        public double MediaLances(Leilao leilao)
        {
            double somaDosLances = 0;
            int totalDeLances = leilao.Lances.Count();
            double mediaDosLances;

            foreach (var lance in leilao.Lances)
            {
                somaDosLances += lance.Valor;
            }

            mediaDosLances = somaDosLances / totalDeLances;

            return mediaDosLances;

        }
    }
}
