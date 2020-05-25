using DManager.Models;
using SQLite;
using System.Collections.Generic;

namespace DManager.Data
{
    public static class DBContext
    {
        private static readonly SQLiteConnection db = new SQLiteConnection(Settings.dbpath);
        private static readonly CreateTableResult tableCreationResult = db.CreateTable<DebtModel>();

        public static List<DebtModel> getAllChanges()
        {
            List<DebtModel> Changes = db.Table<DebtModel>().ToList();
            Changes.Sort(delegate (DebtModel x, DebtModel y)
            {
                if (x.DebtChange == y.DebtChange)
                {
                    return 0;
                }

                return x.DebtChange > y.DebtChange ? 1 : -1;
            });
            return Changes;
        }

        public static List<DebtModel> getChangesByName(string Name)
        {
            return db.Table<DebtModel>().ToList().FindAll(Change => Change.Name == Name);
        }

        public static double getSummaryDebtByName(string Name)
        {
            List<DebtModel> _context = db.Table<DebtModel>().ToList();
            _context = _context.FindAll(Change => Change.Name == Name);

            double result = 0;
            foreach (DebtModel item in _context)
            {
                result += item.DebtChange;
            }

            return result;
        }

        public static int getNumberChanges(string UserName)
        {
            return db.Table<DebtModel>().Count(Change => Change.Name == UserName);
        }

        public static void createChange(DebtModel Debt)
        {
            db.Insert(Debt);
        }

        public static void eraseByName(string Name)
        {
            db.Table<DebtModel>().Delete(Change => Change.Name == Name);
        }

        public static void eraseByFields(DebtModel Debt)
        {
            int valueSameRows = db.Table<DebtModel>().Count(change =>
                change.Name == Debt.Name &&
                change.Date == Debt.Date &&
                change.Description == Debt.Description &&
                change.DebtChange == Debt.DebtChange
            ) - 1;

            db.Table<DebtModel>().Delete(change =>
                change.Name == Debt.Name &&
                change.Date == Debt.Date &&
                change.Description == Debt.Description &&
                change.DebtChange == Debt.DebtChange
            );

            while (valueSameRows > 0)
            {
                db.Insert(Debt);
                valueSameRows--;
            }
        }
    }
}
