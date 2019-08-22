﻿using Sistema.TSTOnline.Domain.Entities.OrdemServico;
using Sistema.TSTOnline.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Sistema.TSTOnline.Domain.Services.OrdemServico
{
    public class OrdemServicoItemBU
    {
        private readonly IRepository<OrdemServicoItemEN> _repositoryOrdemServicoItem;
        private readonly IUnitOfWork _unitOfWork;

        public OrdemServicoItemBU(IRepository<OrdemServicoItemEN> repositoryOrdemServicoItem, IUnitOfWork unitOfWork)
        {
            _repositoryOrdemServicoItem = repositoryOrdemServicoItem;
            _unitOfWork = unitOfWork;
        }

        public void Save(int IDOrdemServicoItem, int IDOrdemServico, int Item, int IDTipoServico, string Observacao, bool Concluido)
        {
            OrdemServicoItemEN ordemServicoItemEN = _repositoryOrdemServicoItem.GetByID(IDOrdemServicoItem);

            if (ordemServicoItemEN != null)
            {
                ordemServicoItemEN.UpdateProperties
                    (
                        IDOrdemServico,
                        Item,
                        IDTipoServico,
                        Observacao,
                        Concluido
                    );

                _repositoryOrdemServicoItem.Edit(ordemServicoItemEN);
            }
            else
            {
                ordemServicoItemEN = new OrdemServicoItemEN
                    (
                        IDOrdemServico,
                        Item,
                        IDTipoServico,
                        Observacao,
                        Concluido
                    );

                _repositoryOrdemServicoItem.Save(ordemServicoItemEN);
            }

            _unitOfWork.Commit();
        }

        public void RemoveAllItems(int IDOrdemServico)
        {
            List<OrdemServicoItemEN> ListOrdemServicoItem = _repositoryOrdemServicoItem.Where(item => item.IDOrdemServico == IDOrdemServico).ToList();
            foreach (var item in ListOrdemServicoItem)
            {
                _repositoryOrdemServicoItem.Delete(item);
            }

            _unitOfWork.Commit();
        }
    }
}
