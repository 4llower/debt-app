using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DManager.ViewModels
{
    public class ComingViewModel
    {
        public ObservableCollection<Models.ComingModel> Comings { get; set; }

        public ComingViewModel()
        {

            Comings = new ObservableCollection<Models.ComingModel>();

            DataSource.DataComing _context = new DataSource.DataComing();

            foreach (Models.ComingModel Coming in _context.Comings)
            {
                Comings.Add(Coming);
            }
        }

    }
}
