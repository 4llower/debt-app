using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
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
            db.CreateTable<Models.DebtModel>();
        }

        public List<Models.DebtModel> GetAllChanges()
        {
            List<Models.DebtModel> Changes = new List<Models.DebtModel>();

            foreach (Models.DebtModel Change in db.Table<Models.DebtModel>())
            {
                Changes.Add(Change);
            }

            return Changes;
        }

        public void MakeChange(Models.DebtModel Debt)
        {
            db.Insert(Debt);
        }

        public void EraseByName(string Name)
        {
            db.Table<Models.DebtModel>().Delete(Change => Change.Name == Name);
        }

        public void EraseByFields(Models.DebtModel Debt)
        {
            db.Table<Models.DebtModel>().Delete(Change => (Change.Name == Debt.Name && Change.DebtChange == Debt.DebtChange && Change.Description == Debt.Description));
        }
    }
}
