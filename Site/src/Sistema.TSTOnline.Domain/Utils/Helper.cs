using System.Collections.Generic;

namespace Sistema.Competicao.Domain.Utils
{
    public class Mes
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }

    public class Helper
    {
        public static string GetMes(int mesReferencia)
        {
            switch (mesReferencia)
            {
                case 1: return "Janeiro";
                case 2: return "Fevereiro";
                case 3: return "Março";
                case 4: return "Abril";
                case 5: return "Maio";
                case 6: return "Junho";
                case 7: return "Julho";
                case 8: return "Agosto";
                case 9: return "Setembro";
                case 10: return "Outubro";
                case 11: return "Novembro";
                case 12: return "Dezembro";

                default: return "";
            }
        }

        public static List<Mes> ListarMeses()
        {
            var listMeses = new List<Mes>();

            for (int iCount = 1; iCount <= 12; iCount++)
            {
                listMeses.Add(new Mes()
                {
                    Codigo = iCount,
                    Descricao = GetMes(iCount)
                });
            }

            return listMeses;
        }
    }
}
