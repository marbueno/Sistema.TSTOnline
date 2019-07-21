using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Competicao.Domain.Entities.Cadastros
{
    public class ResponsavelEN
    {
        [Key]
        public int IDResp { get; set; }
        public int IDUser { get; set; }
        public int IDCompany { get; set; }
        public int CodResp { get; set; }
        public string StatusResp { get; set; }
        public string Situacao { get; set; }
        public string NomeResponsavel { get; set; }
        public string IdentProfissional { get; set; }
        public string Numero { get; set; }
        public string UF { get; set; }
        public string PD { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string NIT { get; set; }
        public string Telefone { get; set; }
        public string TelComercial { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Obs { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraDuracao { get; set; }
        public DateTime HoraFim { get; set; }
        public DateTime DataCad { get; set; }
        public string DataSaida { get; set; }
        public int CodEmpresa { get; set; }
        public string RZEmpresa { get; set; }
        public string CnpjEmpresa { get; set; }
        public string TipoMedico { get; set; }
    }
}
