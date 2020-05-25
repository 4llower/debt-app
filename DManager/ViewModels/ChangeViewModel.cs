using DManager.Data;
using DManager.Models;
using System.Collections.ObjectModel;

namespace DManager.ViewModels
{
    public class ChangeViewModel
    {
        public ObservableCollection<DebtModel> ChangeList { get; set; }
        public ChangeViewModel(string Name)
        {
            ChangeList = new ObservableCollection<Models.DebtModel>();
            foreach (DebtModel Change in DBContext.getAllChanges().FindAll(Change => Change.Name == Name)) ChangeList.Add(Change);
        }
    }
}
