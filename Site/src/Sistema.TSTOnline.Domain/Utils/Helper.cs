using System.Collections.Generic;

namespace Sistema.TSTOnline.Domain.Utils
{
    public class Mes
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
    public class Estado
    {
        public string Codigo { get; set; }
        public string Sigla { get; set; }
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
        
        public static List<Estado> ListarEstados()
        {
            var listEstados = new List<Estado>();
            listEstados.Add(new Estado() { Codigo = "AC", Sigla = "AC" });
            listEstados.Add(new Estado() { Codigo = "AL", Sigla = "AL" });
            listEstados.Add(new Estado() { Codigo = "AP", Sigla = "AP" });
            listEstados.Add(new Estado() { Codigo = "AM", Sigla = "AM" });
            listEstados.Add(new Estado() { Codigo = "BA", Sigla = "BA" });
            listEstados.Add(new Estado() { Codigo = "CE", Sigla = "CE" });
            listEstados.Add(new Estado() { Codigo = "DF", Sigla = "DF" });
            listEstados.Add(new Estado() { Codigo = "ES", Sigla = "ES" });
            listEstados.Add(new Estado() { Codigo = "GO", Sigla = "GO" });
            listEstados.Add(new Estado() { Codigo = "MA", Sigla = "MA" });
            listEstados.Add(new Estado() { Codigo = "MT", Sigla = "MT" });
            listEstados.Add(new Estado() { Codigo = "MS", Sigla = "MS" });
            listEstados.Add(new Estado() { Codigo = "MG", Sigla = "MG" });
            listEstados.Add(new Estado() { Codigo = "PA", Sigla = "PA" });
            listEstados.Add(new Estado() { Codigo = "PB", Sigla = "PB" });
            listEstados.Add(new Estado() { Codigo = "PR", Sigla = "PR" });
            listEstados.Add(new Estado() { Codigo = "PE", Sigla = "PE" });
            listEstados.Add(new Estado() { Codigo = "PI", Sigla = "PI" });
            listEstados.Add(new Estado() { Codigo = "RJ", Sigla = "RJ" });
            listEstados.Add(new Estado() { Codigo = "RN", Sigla = "RN" });
            listEstados.Add(new Estado() { Codigo = "RS", Sigla = "RS" });
            listEstados.Add(new Estado() { Codigo = "RO", Sigla = "RO" });
            listEstados.Add(new Estado() { Codigo = "RR", Sigla = "RR" });
            listEstados.Add(new Estado() { Codigo = "SC", Sigla = "SC" });
            listEstados.Add(new Estado() { Codigo = "SP", Sigla = "SP" });
            listEstados.Add(new Estado() { Codigo = "SE", Sigla = "SE" });
            listEstados.Add(new Estado() { Codigo = "TO", Sigla = "TO" });

            return listEstados;
        }
    }
}
