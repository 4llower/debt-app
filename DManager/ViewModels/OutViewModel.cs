using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DManager.ViewModels
{
    public class OutViewModel
    {
        public ObservableCollection<Models.OutModel> Outs { get; set; }

        public OutViewModel()
        {

            Outs = new ObservableCollection<Models.OutModel>();

            DataSource.DataOut _context = new DataSource.DataOut();

            foreach (Models.OutModel Out in _context.Outs)
            {
                Outs.Add(Out);
            }
        }

    }
}
