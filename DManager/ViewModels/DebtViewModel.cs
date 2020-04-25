using DManager.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace DManager.ViewModels
{
    public class DebtViewModel
    {
        public ObservableCollection<PreviewDebtModel> PreviewList { get; set; }

        //True - Coming
        //False - Out

        public DebtViewModel(bool isComing)
        {

            PreviewList = new ObservableCollection<PreviewDebtModel>();

            DataSource.DebtController _context = new DataSource.DebtController();

            Dictionary<string, double> Assume = new Dictionary<string, double>();

            foreach (DebtModel Change in _context.GetAllChanges())
            {
                if (!Assume.ContainsKey(Change.Name)) Assume.Add(Change.Name, Change.DebtChange);
                else
                {
                    Assume[Change.Name] += Change.DebtChange;
                }
            }

            foreach (KeyValuePair<string, double> PreviewValue in Assume)
            {
                if ((isComing == true && PreviewValue.Value > 0) || (isComing == false && PreviewValue.Value < 0))
                {
                    PreviewList.Add(new PreviewDebtModel() { Name = PreviewValue.Key, DebtSum = PreviewValue.Value });
                }
            }
        }

    }
}
