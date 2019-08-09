﻿using System;
using Newtonsoft.Json;
using Sistema.TSTOnline.Domain.Utils;

namespace Sistema.TSTOnline.Web.Models.OrdemServico
{
    public class OrdemServicoVM
    {
        public OrdemServicoVM()
        {
            DataCadastro = DateTime.Now;
        }

        [JsonProperty(PropertyName = "codigo")]
        public int IDOrdemServico { get; set; }

        [JsonProperty(PropertyName = "dataCadastro")]
        public DateTime DataCadastro { get; set; }

        [JsonProperty(PropertyName = "dataServico")]
        public DateTime DataServico { get; set; }

        [JsonProperty(PropertyName = "status")]
        public OrdemServicoStatusEnum Status { get; set; }

        [JsonProperty(PropertyName = "statusDescricao")]
        public string StatusDescricao { get { return Status.ToDescriptionEmum(); } }

        [JsonProperty(PropertyName = "codigoResponsavel")]
        public int IDResp { get; set; }

        [JsonProperty(PropertyName = "responsavelNome")]
        public string ResponsavelNome { get; set; }

        [JsonProperty(PropertyName = "codigoLocal")]
        public int IDLocal { get; set; }

        [JsonProperty(PropertyName = "localDescricao")]
        public string LocalDescricao { get; set; }
    }
}
