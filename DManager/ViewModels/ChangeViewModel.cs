using DManager.DataSource;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DManager.ViewModels
{
    public class ChangeViewModel
    {
        public ObservableCollection<Models.DebtModel> ChangeList { get; set; }
        public ChangeViewModel(string Name)
        {

            ChangeList = new ObservableCollection<Models.DebtModel>();
            DebtData _context = new DebtData();
            foreach (Models.DebtModel Change in _context.GetAllChanges())
            {
                if (Change.Name == Name) ChangeList.Add(Change);
            }
        }
    }
}
