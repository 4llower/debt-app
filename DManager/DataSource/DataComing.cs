using System;
using System.Collections.Generic;
using System.Text;

namespace DManager.DataSource
{
    class DataComing
    {
        public List<Models.ComingModel> Comings = new List<Models.ComingModel>()
        {
            new Models.ComingModel()
            {
                Name = "Sergey",
                Money = 100
            },
            new Models.ComingModel()
            {
                Name = "Maks",
                Money = 50
            }
        };
    }
}
