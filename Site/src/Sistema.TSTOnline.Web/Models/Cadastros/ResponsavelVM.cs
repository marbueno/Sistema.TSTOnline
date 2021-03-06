﻿using Newtonsoft.Json;
using System;

namespace Sistema.TSTOnline.Web.Models.Cadastros
{
    public class ResponsavelVM
    {
        [JsonProperty(PropertyName = "codigo")]
        public int IDResp { get; set; }

        [JsonProperty(PropertyName = "codigoUsuario")]
        public int IDUser { get; set; }

        [JsonProperty(PropertyName = "codigoCompany")]
        public int IDCompany { get; set; }

        [JsonProperty(PropertyName = "codigoResponsavel")]
        public int CodResp { get; set; }

        [JsonProperty(PropertyName = "statusResponsavel")]
        public string StatusResp { get; set; }

        [JsonProperty(PropertyName = "situacao")]
        public string Situacao { get; set; }

        [JsonProperty(PropertyName = "nomeResponsavel")]
        public string NomeResponsavel { get; set; }

        [JsonProperty(PropertyName = "IdentidadeProfissional")]
        public string IdentProfissional { get; set; }

        [JsonProperty(PropertyName = "numero")]
        public string Numero { get; set; }

        [JsonProperty(PropertyName = "uf")]
        public string UF { get; set; }

        [JsonProperty(PropertyName = "pd")]
        public string PD { get; set; }

        [JsonProperty(PropertyName = "cpf")]
        public string CPF { get; set; }

        [JsonProperty(PropertyName = "rg")]
        public string RG { get; set; }

        [JsonProperty(PropertyName = "nit")]
        public string NIT { get; set; }

        [JsonProperty(PropertyName = "telefone")]
        public string Telefone { get; set; }

        [JsonProperty(PropertyName = "telefoneComercial")]
        public string TelComercial { get; set; }

        [JsonProperty(PropertyName = "celular")]
        public string Celular { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "obs")]
        public string Obs { get; set; }
    }
}
