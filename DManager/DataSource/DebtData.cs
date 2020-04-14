using DManager.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DManager.DataSource
{
    public class DebtData
    {
        string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DebtDatabase.db");
        SQLiteConnection db;

        public DebtData()
        {
            db = new SQLiteConnection(dbpath);
            db.CreateTable<DebtModel>();
        }

        public List<DebtModel> GetAllChanges()
        { 
            List <DebtModel> Changes = db.Table<DebtModel>().ToList();
            Changes.Sort(delegate (DebtModel x, DebtModel y)
            {
                if (x.DebtChange == y.DebtChange) return 0;
                return x.DebtChange > y.DebtChange ? 1 : -1;
            });
            return Changes;
        }

        public int GetNumberChanges(string UserName)
        {
            return db.Table<DebtModel>().Count(Change => Change.Name == UserName);
        }

        public void MakeChange(DebtModel Debt)
        {
            List<DebtModel> ChangesByName = db.Table<DebtModel>().ToList().FindAll(Change => Change.Name == Debt.Name);

            if (ChangesByName.Count(Change => Change.DebtChange > 0) != 0)
            {
                if (Debt.DebtChange > 0)
                {
                    db.Insert(Debt);
                    return;
                }
            } else
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
                    EraseByFields(Change);
                } else
                {
                    EraseByFields(Change);
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

        public void EraseByName(string Name)
        {
            db.Table<DebtModel>().Delete(Change => Change.Name == Name);
        }

        public void EraseByFields(DebtModel Debt)
        {
            db.Table<DebtModel>().Delete(Change => (Change.Name == Debt.Name && Change.DebtChange == Debt.DebtChange && Change.Description == Debt.Description));
        }
    }
}
