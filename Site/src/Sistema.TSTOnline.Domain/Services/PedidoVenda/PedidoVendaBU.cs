using Sistema.TSTOnline.Domain.Entities.PedidoVenda;
using Sistema.TSTOnline.Domain.Interfaces;
using Sistema.TSTOnline.Domain.Utils;
using System;

namespace Sistema.TSTOnline.Domain.Services.PedidoVenda
{
    public class PedidoVendaBU
    {
        private readonly IRepository<PedidoVendaEN> _repositoryPedidoVenda;
        private readonly IUnitOfWork _unitOfWork;

        public PedidoVendaBU(IRepository<PedidoVendaEN> repositoryPedidoVenda, IUnitOfWork unitOfWork)
        {
            _repositoryPedidoVenda = repositoryPedidoVenda;
            _unitOfWork = unitOfWork;
        }

        public int Save(int IDPedidoVenda, DateTime DataVenda, PedidoVendaStatusEnum Status, int IDUsuario, int IDVendedor)
        {
            PedidoVendaEN pedidoVendaEN = _repositoryPedidoVenda.GetByID(IDPedidoVenda);

            if (pedidoVendaEN != null)
            {
                pedidoVendaEN.UpdateProperties
                    (
                        DataVenda,
                        Status,
                        IDUsuario,
                        IDVendedor
                    );

                _repositoryPedidoVenda.Edit(pedidoVendaEN);
            }
            else
            {
                pedidoVendaEN = new PedidoVendaEN
                    (
                        DataVenda,
                        Status,
                        IDUsuario,
                        IDVendedor
                    );
                pedidoVendaEN.DataCadastro = DateTime.Now;

                _repositoryPedidoVenda.Save(pedidoVendaEN);
            }

            _unitOfWork.Commit();

            return pedidoVendaEN.IDPedido;
        }

        public void UpdateStatus(int IDPedidoVenda, PedidoVendaStatusEnum Status)
        {
            PedidoVendaEN pedidoVendaEN = _repositoryPedidoVenda.GetByID(IDPedidoVenda);

            pedidoVendaEN.Status = Status;

            _repositoryPedidoVenda.Edit(pedidoVendaEN);

            _unitOfWork.Commit();
        }
    }
}
