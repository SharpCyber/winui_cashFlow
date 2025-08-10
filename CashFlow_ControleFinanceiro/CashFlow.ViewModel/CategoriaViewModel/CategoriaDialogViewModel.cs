using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Text;
using Microsoft.UI.Xaml;
using CashFlow.Domain.Entity;
using CashFlow.Domain.Enumeration;
using CashFlow.Domain.Interfaces;

namespace CashFlow.ViewModel.CategoriaViewModel
{
    public class CategoriaDialogViewModel : CrudViewModelBase<Categoria>, ICategoriaDialogViewModel
    {

    }
}
