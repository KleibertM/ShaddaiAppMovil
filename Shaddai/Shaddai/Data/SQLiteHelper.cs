using System.Collections.Generic;
using SQLite;
using System.Threading.Tasks;
using Shaddai.Model;

namespace Joss.Data
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;

        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Producto>().Wait();
        }

        public Task<int> SaveProductoASync(Producto item)
        {
            if (item.IdItem != 0)
            {
                return db.UpdateAsync(item);
            }
            else
            {
                return db.InsertAsync(item);
            }
        }

        public Task<int> DeleteProductoAsync(Producto item)
        {
            return db.DeleteAsync(item);
        }

        public Task<List<Producto>> GetProductosAsync()
        {
            return db.Table<Producto>().ToListAsync();
        }

        public Task<Producto> GetProductoById(int idItem)
        {
            return db.Table<Producto>().Where(a => a.IdItem == idItem).FirstOrDefaultAsync();
        }
    }
}