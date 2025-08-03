using CashFlow.Domain.Entity;
using CashFlow.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.InfraData.Repository
{
    public class TipoTransacaoRepository : Repository<TipoTransacao>, ITipoTransacaoRepository
    {
        public TipoTransacaoRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
