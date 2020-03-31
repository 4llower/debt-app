using System;
using System.Collections.Generic;
using System.Text;

namespace DManager.DataSource
{
    class DataOut
    {
        public List<Models.OutModel> Outs = new List<Models.OutModel>()
        {
            new Models.OutModel()
            {
                Name = "Vitaly",
                Money = 800
            },
            new Models.OutModel()
            {
                Name = "Flexable",
                Money = 400
            }
        };
    }
}
