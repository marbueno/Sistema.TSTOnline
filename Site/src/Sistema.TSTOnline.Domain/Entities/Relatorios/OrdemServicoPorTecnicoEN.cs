using Sistema.TSTOnline.Domain.Utils;
using System;

namespace Sistema.TSTOnline.Domain.Entities.Relatorios
{
    public class OrdemServicoPorTecnicoEN
    {
        public int Id { get; set; }
        public int IDOrdemServico { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataServico { get; set; }
        public string HorarioServico { get; set; }
        public OrdemServicoStatusEnum Status { get; set; }
        public int IDResp { get; set; }
        public string NomeResponsavel { get; set; }
        public string EmailResponsavel { get; set; }
    }
}
