using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DManager.ViewModels
{
    public class ComingViewModel
    {
        private ObservableCollection<Models.ComingModel> comings;
        public ObservableCollection<Models.ComingModel> Comings
        {
            get
            {
                return comings;
            }
            set
            {
                comings = value;
            }
        }

        public ComingViewModel()
        {

            Comings = new ObservableCollection<Models.ComingModel>();

            DataSource.DataComing _context = new DataSource.DataComing();

            foreach (var Coming in _context.Comings)
            {
                Comings.Add(Coming);
            }
        }

    }
}
