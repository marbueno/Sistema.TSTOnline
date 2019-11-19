using Sistema.TSTOnline.Domain.Utils;
using System;

namespace Sistema.TSTOnline.Domain.Entities.Relatorios
{
    public class OrdemServicoPorClienteEN
    {
        public int Id { get; set; }
        public int IDOrdemServico { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataServico { get; set; }
        public string HorarioServico { get; set; }
        public OrdemServicoStatusEnum Status { get; set; }
        public int IDEmpresa { get; set; }
        public string RazaoSocial { get; set; }
        public string ResponsavelEmpresaNome { get; set; }
        public string NomeResponsavel { get; set; }
    }
}
