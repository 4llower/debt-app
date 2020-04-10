using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace DManager.ViewModels
{
    public class DebtViewModel
    {
        public ObservableCollection<Models.PreviewDebtModel> PreviewList { get; set; }

        //True - Coming
        //False - Out

        public DebtViewModel(bool isComing)
        {

            PreviewList = new ObservableCollection<Models.PreviewDebtModel>();

            DataSource.DebtData _context = new DataSource.DebtData();

            Dictionary<string, int> Assume = new Dictionary<string, int>();

            foreach (Models.DebtModel Change in _context.GetAllChanges())
            {
                if (!Assume.ContainsKey(Change.Name)) Assume.Add(Change.Name, Change.DebtChange);
                else
                {
                    Assume[Change.Name] += Change.DebtChange;
                }
            }

            foreach (KeyValuePair<string, int> PreviewValue in Assume)
            {
                if ((isComing == true && PreviewValue.Value > 0) || (isComing == false && PreviewValue.Value < 0))
                {
                    PreviewList.Add(new Models.PreviewDebtModel() { Name = PreviewValue.Key, DebtSum = PreviewValue.Value });
                }
            }
        }

    }
}
