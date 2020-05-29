using DManager.Data;
using DManager.Models;
using System;
using System.Collections.ObjectModel;
using System.Globalization;

namespace DManager.ViewModels
{
    public class PersonalityDebtView
    {
        public ObservableCollection<ViewDebtModel> ChangeList { get; set; }
        public PersonalityDebtView(string Name, TypeSort typeSort)
        {
            ChangeList = new ObservableCollection<ViewDebtModel>();

            System.Collections.Generic.List<DebtModel> _context = DBContext.getChangesByName(Name);

            switch (typeSort)
            {
                case TypeSort.ByDateOldFirst:

                    _context.Sort(delegate (DebtModel x, DebtModel y)
                    {
                        CultureInfo provider = CultureInfo.InvariantCulture;
                        DateTime a = DateTime.ParseExact(x.Date, "dd MM yyyy", provider);
                        DateTime b = DateTime.ParseExact(y.Date, "dd MM yyyy", provider);
                        if (a == b)
                        {
                            return 0;
                        }

                        return a > b ? 1 : -1;
                    });
                    break;

                case TypeSort.ByDateNewFirst:

                    _context.Sort(delegate (DebtModel x, DebtModel y)
                    {
                        CultureInfo provider = CultureInfo.InvariantCulture;
                        DateTime a = DateTime.ParseExact(x.Date, "dd MM yyyy", provider);
                        DateTime b = DateTime.ParseExact(y.Date, "dd MM yyyy", provider);
                        if (a == b)
                        {
                            return 0;
                        }

                        return a < b ? 1 : -1;
                    });
                    break;

                case TypeSort.ByValueLargeFirst:

                    _context.Sort(delegate (DebtModel x, DebtModel y)
                    {
                        if (x.DebtChange == y.DebtChange)
                        {
                            return 0;
                        }

                        return x.DebtChange < y.DebtChange ? 1 : -1;
                    });
                    break;

                case TypeSort.ByValueSmallFirst:

                    _context.Sort(delegate (DebtModel x, DebtModel y)
                    {
                        if (x.DebtChange == y.DebtChange)
                        {
                            return 0;
                        }

                        return x.DebtChange > y.DebtChange ? 1 : -1;
                    });
                    break;

                default:
                    break;
            }

            foreach (DebtModel item in _context)
            {
                ChangeList.Add(new ViewDebtModel()
                {
                    Name = item.Name,
                    Description = item.Description,
                    DebtChange = item.DebtChange,
                    Date = item.Date,
                    IsMoneyDebt = item.DebtChange != 0 ? true : false
                });
            }
        }
    }
}
