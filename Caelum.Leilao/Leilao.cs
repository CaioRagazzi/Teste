using NUnit.Framework;
using System.Collections.Generic;

namespace Caelum.Leilao
{
    public class Leilao
    {

        public string Descricao { get; set; }
        public IList<Lance> Lances { get; set; }

        public Leilao(string descricao)
        {
            this.Descricao = descricao;
            this.Lances = new List<Lance>();
        }

        int totalUsuariosRepetidos = 0;
        public void Propoe(Lance lance)
        {
            var usuarioAtual = lance.Usuario.Nome;

            foreach (var item in Lances)
            {
                if (item.Usuario.Nome == usuarioAtual)
                {
                    totalUsuariosRepetidos++;
                }
            }

            if (Lances.Count >= 1)
            {
                if (lance.Usuario.Nome == Lances[Lances.Count - 1].Usuario.Nome || totalUsuariosRepetidos >= 5)
                {
                    totalUsuariosRepetidos = 0;
                    return;
                }
            }
            Lances.Add(lance);
            totalUsuariosRepetidos = 0;
        }

        public void DobrarLance(Usuario usuario)
        {
            double maiorValor = 0;
            foreach (var item in Lances)
            {
                if (item.Usuario.Nome == usuario.Nome && item.Valor > maiorValor)
                {
                    maiorValor = item.Valor;
                }
            }
            if (maiorValor == 0)
            {
                return;
            }
            Propoe(new Lance(usuario, maiorValor * 2));
        }
    }
}