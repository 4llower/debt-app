using DManager.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DManager.DataSource
{
    public static class DBContext
    {
        static SQLiteConnection db = new SQLiteConnection(Settings.dbpath);
        static CreateTableResult tableCreationResult = db.CreateTable<DebtModel>();

        static public List<DebtModel> getAllChanges()
        {
            List<DebtModel> Changes = db.Table<DebtModel>().ToList();
            Changes.Sort(delegate (DebtModel x, DebtModel y)
            {
                if (x.DebtChange == y.DebtChange) return 0;
                return x.DebtChange > y.DebtChange ? 1 : -1;
            });
            return Changes;
        }

        static public double getSummaryDebtByName(string Name)
        {
            var _context = db.Table<DebtModel>().ToList();
            _context = _context.FindAll(Change => Change.Name == Name);

            double result = 0;
            foreach (var item in _context)
            {
                result += item.DebtChange;
            }

            return result;
        }

        static public int getNumberChanges(string UserName)
        {
            return db.Table<DebtModel>().Count(Change => Change.Name == UserName);
        }

        static public void createChange(DebtModel Debt)
        {
            List<DebtModel> ChangesByName = db.Table<DebtModel>().ToList().FindAll(Change => Change.Name == Debt.Name);

            if (ChangesByName.Count(Change => Change.DebtChange > 0) != 0)
            {
                if (Debt.DebtChange > 0)
                {
                    db.Insert(Debt);
                    return;
                }
            }
            else
            {
                if (Debt.DebtChange < 0)
                {
                    db.Insert(Debt);
                    return;
                }
            }

            ChangesByName.Sort(delegate (DebtModel x, DebtModel y)
            {
                if (x.DebtChange == y.DebtChange) return 0;
                return Math.Abs(x.DebtChange) > Math.Abs(y.DebtChange) ? 1 : -1;
            });


            int sign = (Debt.DebtChange > 0 ? 1 : -1);
            bool isMore = false;
            Debt.DebtChange = Math.Abs(Debt.DebtChange);

            foreach (DebtModel Change in ChangesByName)
            {
                if (Debt.DebtChange >= Math.Abs(Change.DebtChange))
                {
                    Debt.DebtChange -= Change.DebtChange;
                    eraseByFields(Change);
                }
                else
                {
                    eraseByFields(Change);
                    Change.DebtChange += sign * Debt.DebtChange;
                    if (Change.DebtChange != 0) db.Insert(Change);
                    isMore = true;
                    break;
                }
            }

            if (isMore == false)
            {
                Debt.DebtChange *= sign;
                db.Insert(Debt);
            }
        }

        static public void eraseByName(string Name)
        {
            db.Table<DebtModel>().Delete(Change => Change.Name == Name);
        }

        static public void eraseByFields(DebtModel Debt)
        {
            db.Table<DebtModel>().Delete(Change => (Change.Name == Debt.Name && Change.DebtChange == Debt.DebtChange && Change.Description == Debt.Description));
        }
    }
}
