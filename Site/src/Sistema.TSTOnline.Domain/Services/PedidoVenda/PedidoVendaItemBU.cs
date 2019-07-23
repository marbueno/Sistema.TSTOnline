using Sistema.Competicao.Domain.Entities.PedidoVenda;
using Sistema.Competicao.Domain.Interfaces;

namespace Sistema.Competicao.Domain.Services.PedidoVenda
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
    }
}
