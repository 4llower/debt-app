using DManager.DataSource;
using DManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DManager.ViewModels
{
    public class ChangeViewModel
    {
        public ObservableCollection<DebtModel> ChangeList { get; set; }
        public ChangeViewModel(string Name)
        {
            ChangeList = new ObservableCollection<Models.DebtModel>();
            foreach (DebtModel Change in (new DebtData()).GetAllChanges().FindAll(Change => Change.Name == Name)) ChangeList.Add(Change);  
        }
    }
}
