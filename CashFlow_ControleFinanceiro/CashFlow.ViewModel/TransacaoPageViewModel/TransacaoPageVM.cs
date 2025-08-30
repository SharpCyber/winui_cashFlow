using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CashFlow.Domain.DTO;
using CashFlow.Domain.Entity;
using CashFlow.Domain.Interfaces;

namespace CashFlow.ViewModel.TransacaoPageViewModel
{
    public class TransacaoPageVM : CrudViewModelBase<Transacao>, ITransacaoPageVM
    {
        private DateTimeOffset _dataSelecionada;

        public TransacaoPageVM()
        {
            _ordenacao = new ObservableCollection<Item>()
            {
                new Item { ID = "1", Nome = "Data Vencimento" },
                new Item { ID = "2", Nome = "Data Transação" },
                new Item { ID = "3", Nome = "Categoria" },
                new Item { ID = "4", Nome = "Entrada/Saída" },
                new Item { ID = "5", Nome = "Valor" },
                new Item { ID = "6", Nome = "Entidade Financeira" }
            };

            SetValoresPadrao();
        }

        private void SetValoresPadrao()
        {
            OrdenacaoSelecionada = OrdenacaoCollection.FirstOrDefault();
            DataSelecionada = new DateTimeOffset(DateTime.Now);
        }

        #region Ordenacao
        private ObservableCollection<Item> _ordenacao = null;
        private Item _ordenacaoSelecionada;

        public ObservableCollection<Item> OrdenacaoCollection
        {
            get => _ordenacao;
            set
            {
                _ordenacao = value;
                OnPropertyChanged();
            }
        }

        public Item OrdenacaoSelecionada
        {
            get => _ordenacaoSelecionada;
            set
            {
                _ordenacaoSelecionada = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Data
        public DateTimeOffset DataSelecionada
        {
            get => _dataSelecionada;
            set
            {
                _dataSelecionada = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}