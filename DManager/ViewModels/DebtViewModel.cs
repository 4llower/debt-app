using System.Collections.Generic;
using System.Collections.ObjectModel;

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

            foreach (Models.DebtModel Change in _context.DebtChanges)
            {
                if (!Assume.ContainsKey(Change.name)) Assume.Add(Change.name, Change.debt_change);
                else Assume[Change.name] += Change.debt_change;
            }

            foreach (KeyValuePair<string, int> PreviewValue in Assume)
            {
                if ((isComing == true && PreviewValue.Value > 0) || (isComing == false && PreviewValue.Value < 0))
                {
                    PreviewList.Add(new Models.PreviewDebtModel() { name = PreviewValue.Key, debt_sum = PreviewValue.Value });
                }
            }
        }

    }
}
