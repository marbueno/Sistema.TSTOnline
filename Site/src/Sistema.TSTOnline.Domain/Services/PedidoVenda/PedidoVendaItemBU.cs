using Sistema.TSTOnline.Domain.Entities.PedidoVenda;
using Sistema.TSTOnline.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Sistema.TSTOnline.Domain.Services.PedidoVenda
{
    public class PedidoVendaItemBU
    {
        private readonly IRepository<PedidoVendaItemEN> _repositoryPedidoVendaItem;
        private readonly IUnitOfWork _unitOfWork;

        public PedidoVendaItemBU(IRepository<PedidoVendaItemEN> repositoryPedidoVendaItem, IUnitOfWork unitOfWork)
        {
            _repositoryPedidoVendaItem = repositoryPedidoVendaItem;
            _unitOfWork = unitOfWork;
        }

        public void Save(int IDPedidoVendaItem, int IDPedidoVenda, int Item, int IDProduto, int Qtde, decimal Valor)
        {
            PedidoVendaItemEN pedidoVendaItemEN = _repositoryPedidoVendaItem.GetByID(IDPedidoVendaItem);

            if (pedidoVendaItemEN != null)
            {
                pedidoVendaItemEN.UpdateProperties
                    (
                        IDPedidoVenda,
                        Item,
                        IDProduto,
                        Qtde,
                        Valor
                    );

                _repositoryPedidoVendaItem.Edit(pedidoVendaItemEN);
            }
            else
            {
                pedidoVendaItemEN = new PedidoVendaItemEN
                    (
                        IDPedidoVenda,
                        Item,
                        IDProduto,
                        Qtde,
                        Valor
                    );

                _repositoryPedidoVendaItem.Save(pedidoVendaItemEN);
            }

            _unitOfWork.Commit();
        }

        public void RemoveAllItems(int IDPedido)
        {
            List<PedidoVendaItemEN> listPedidoVendaItem = _repositoryPedidoVendaItem.Where(item => item.IDPedido == IDPedido).ToList();
            foreach (var item in listPedidoVendaItem)
            {
                _repositoryPedidoVendaItem.Delete(item);
            }

            _unitOfWork.Commit();
        }

        public void RemoveItem(PedidoVendaItemEN itemPedido)
        {
            _repositoryPedidoVendaItem.Delete(itemPedido);

            _unitOfWork.Commit();
        }
    }
}
