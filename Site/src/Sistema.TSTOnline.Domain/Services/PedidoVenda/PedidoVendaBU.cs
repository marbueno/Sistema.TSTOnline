using Sistema.Competicao.Domain.Entities.PedidoVenda;
using Sistema.Competicao.Domain.Interfaces;

namespace Sistema.Competicao.Domain.Services.PedidoVenda
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

        public void Save(int IDPedidoVenda, int Status, int IDUsuario, int IDVendedor)
        {
            PedidoVendaEN pedidoVendaEN = _repositoryPedidoVenda.GetByID(IDPedidoVenda);

            if (pedidoVendaEN != null)
            {
                pedidoVendaEN.UpdateProperties
                    (
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
                        Status,
                        IDUsuario,
                        IDVendedor
                    );

                _repositoryPedidoVenda.Save(pedidoVendaEN);
            }

            _unitOfWork.Commit();
        }
    }
}
