using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DManager.ViewModels
{
    public class OutViewModel
    {
        private ObservableCollection<Models.OutModel> outs;
        public ObservableCollection<Models.OutModel> Outs
        {
            get
            {
                return outs;
            }
            set
            {
                outs = value;
            }
        }

        public OutViewModel()
        {

            Outs = new ObservableCollection<Models.OutModel>();

            DataSource.DataOut _context = new DataSource.DataOut();

            foreach (var Out in _context.Outs)
            {
                Outs.Add(Out);
            }
        }

    }
}
