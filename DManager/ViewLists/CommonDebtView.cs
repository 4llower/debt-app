using DManager.Data;
using DManager.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DManager.ViewModels
{
    public class CommonDebtView
    {
        public ObservableCollection<PreviewDebtModel> PreviewList { get; set; }
        public CommonDebtView(TypeDebtView debtType)
        {

            PreviewList = new ObservableCollection<PreviewDebtModel>();
            Dictionary<string, double> Assume = new Dictionary<string, double>();
            foreach (DebtModel Change in DBContext.getAllChanges())
            {
                if (!Assume.ContainsKey(Change.Name))
                {
                    Assume.Add(Change.Name, Change.DebtChange);
                }
                else
                {
                    Assume[Change.Name] += Change.DebtChange;
                }
            }
            foreach (KeyValuePair<string, double> PreviewValue in Assume)
            {
                if ((debtType == TypeDebtView.Coming && PreviewValue.Value >= 0) || 
                    (debtType == TypeDebtView.Out && PreviewValue.Value < 0))
                {
                    PreviewList.Add(new PreviewDebtModel() { Name = PreviewValue.Key, DebtSum = PreviewValue.Value });
                }
            }
        }

    }
}
