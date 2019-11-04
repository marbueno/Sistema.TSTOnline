﻿using System.ComponentModel.DataAnnotations;


namespace Sistema.TSTOnline.Domain.Entities.OrdemServico
{
    public class TipoServicoEN
    {
        [Key]
        public int IDTipoServico { get; set; }
        public int IDCompany { get; set; }
        public int IDUser { get; set; }
        public string Descricao { get; set; }

        private TipoServicoEN() { }

        public TipoServicoEN(int IDCompany, int IDUser, string Descricao)
        {
            ValidateAndSetProperties(IDCompany, IDUser, Descricao);
        }

        public void UpdateProperties(int IDCompany, int IDUser, string Descricao)
        {
            ValidateAndSetProperties(IDCompany, IDUser, Descricao);
        }

        private void ValidateAndSetProperties(int IDCompany, int IDUser, string Descricao)
        {
            DomainException.When(IDCompany == 0, "Compania não informada.");
            DomainException.When(IDUser == 0, "Usuário não informado.");
            DomainException.When(string.IsNullOrEmpty(Descricao), "Descrição não informada.");

            this.IDCompany = IDCompany;
            this.IDUser = IDUser;
            this.Descricao = Descricao;
        }
    }
}
