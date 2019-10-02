﻿using Sistema.TSTOnline.Domain.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema.TSTOnline.Domain.Entities.OrdemServico
{
    public class OrdemServicoEN
    {
        [Key]
        public int IDOrdemServico { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataServico { get; set; }
        public OrdemServicoStatusEnum Status { get; set; }
        public int IDEmpresa { get; set; }
        public int IDResp { get; set; }
        public int IDLocal { get; set; }
        public string NomeContato { get; set; }
        public string Telefone { get; set; }
        public string WhatsApp { get; set; }

        public OrdemServicoEN(DateTime DataServico, OrdemServicoStatusEnum Status, int IDEmpresa, int IDResp, int IDLocal, string NomeContato, string Telefone, string WhatsApp)
        {
            ValidateAndSetProperties(DataServico, Status, IDEmpresa, IDResp, IDLocal, NomeContato, Telefone, WhatsApp);
        }

        public void UpdateProperties(DateTime DataServico, OrdemServicoStatusEnum Status, int IDEmpresa, int IDResp, int IDLocal, string NomeContato, string Telefone, string WhatsApp)
        {
            ValidateAndSetProperties(DataServico, Status, IDEmpresa, IDResp, IDLocal, NomeContato, Telefone, WhatsApp);
        }

        private void ValidateAndSetProperties(DateTime DataServico, OrdemServicoStatusEnum Status, int IDEmpresa, int IDResp, int IDLocal, string NomeContato, string Telefone, string WhatsApp)
        {
            DomainException.When(DataServico == DateTime.MinValue, "Data do Serviço Inválida.");
            DomainException.When(Status == 0, "Status não informado.");
            DomainException.When(IDResp == 0, "Responsável pelo serviço não informado.");
            DomainException.When(IDLocal == 0, "Local do serviço não informado.");

            this.DataServico = DataServico;
            this.Status = Status;
            this.IDEmpresa = IDEmpresa;
            this.IDResp = IDResp;
            this.IDLocal = IDLocal;
            this.NomeContato = NomeContato;
            this.Telefone = Telefone;
            this.WhatsApp = WhatsApp;
        }
    }
}
