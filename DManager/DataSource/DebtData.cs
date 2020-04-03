using System;
using System.Collections.Generic;
using System.Text;

namespace DManager.DataSource
{
    class DebtData
    {
        public List<Models.DebtModel> DebtChanges = new List<Models.DebtModel>()
        {
            new Models.DebtModel
            {
                name = "sergey",
                debt_change = 100,
                description = "on pivo"
            },

            new Models.DebtModel
            {
                name = "sergey",
                debt_change = 100,
                description = "on flex"
            },

            new Models.DebtModel
            {
                name = "vitaly",
                debt_change = -100,
                description = "car sharing"
            },

            new Models.DebtModel
            {
                name = "vitaly",
                debt_change = -100,
                description = "car sharing again"
            }

        };
    }
}
