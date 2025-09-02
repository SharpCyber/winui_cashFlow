using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashFlow.Domain.Interfaces.ViewModels;

namespace CashFlow.ViewModel.TransacaoPage
{
    public class TransacaoPageViewModel : ViewModelBase, ITransacaoPageViewModel
    {
        public ObservableCollection<TransacaoViewModel> TransacaoCollection { get; }

        public TransacaoPageViewModel()
        {
            TransacaoCollection = new ObservableCollection<TransacaoViewModel>();

            Pesquisar(new DateTime());
        }

        public void Pesquisar(DateTime data)
        {
            // Pesquisa por data em desenvolvimento

            for (int i = 0; i < 100; i++)
            {
                var transacao = new Domain.Entity.Transacao()
                {
                    PK_Transacao = i,
                    EntidadeFinanceira = new Domain.Entity.EntidadeFinanceira
                    {
                        Categoria = new Domain.Entity.Categoria
                        {
                            Nome = "Categoria Teste " + i
                        }
                    },
                };

                TransacaoCollection.Add(new TransacaoViewModel(transacao));
            }
        }
    }
}
