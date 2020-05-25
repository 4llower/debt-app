using DManager.Data;
using DManager.Models;
using SQLitePCL;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;

namespace DManager.ViewModels
{
    public class ChangeViewModel
    {
        public ObservableCollection<DebtModel> ChangeList { get; set; }
        public ChangeViewModel(string Name, TypeSort typeSort)
        {
            ChangeList = new ObservableCollection<Models.DebtModel>();

            var _context = DBContext.getChangesByName(Name);
            
            switch (typeSort)
            {
                case TypeSort.ByDateOldFirst:

                    _context.Sort(delegate (DebtModel x, DebtModel y) 
                    {
                        CultureInfo provider = CultureInfo.InvariantCulture;
                        var a = DateTime.ParseExact(x.Date, "dd-MM-yyyy", provider);
                        var b = DateTime.ParseExact(y.Date, "dd-MM-yyyy", provider);
                        if (a == b) return 0;
                        return a > b ? 1 : -1;
                    });
                    break;

                case TypeSort.ByDateNewFirst:

                    _context.Sort(delegate (DebtModel x, DebtModel y)
                    {
                        CultureInfo provider = CultureInfo.InvariantCulture;
                        var a = DateTime.ParseExact(x.Date, "dd-MM-yyyy", provider);
                        var b = DateTime.ParseExact(y.Date, "dd-MM-yyyy", provider);
                        if (a == b) return 0;
                        return a < b ? 1 : -1;
                    });
                    break;

                case TypeSort.ByValueLargeFirst:

                    _context.Sort(delegate (DebtModel x, DebtModel y)
                    {
                        if (x.DebtChange == y.DebtChange) return 0;
                        return x.DebtChange < y.DebtChange ? 1 : -1;
                    });
                    break;

                case TypeSort.ByValueSmallFirst:

                    _context.Sort(delegate (DebtModel x, DebtModel y)
                    {
                        if (x.DebtChange == y.DebtChange) return 0;
                        return x.DebtChange > y.DebtChange ? 1 : -1;
                    });
                    break;

                default:
                    break;
            }

            foreach (var item in _context)
            {
                CultureInfo provider = CultureInfo.InvariantCulture;
                item.Date = DateTime.ParseExact(item.Date, "dd-MM-yyyy", provider).ToString("dddd, dd MMMM yyyy");
            }

            foreach (var item in _context)
            {
                ChangeList.Add(item);
            }
        }
    }
}
