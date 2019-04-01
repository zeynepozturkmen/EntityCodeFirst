using EntityCodeFirst_1.DAL.ORM.Entity; //AppUser (Entity) dosyasında (Context) dosyasında degil.Aynı dosyada olmadıkları için birbirlerini görmüyorlar.O yuzden namespaceini ekliyoruz.
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCodeFirst_1.DAL.ORM.Context
{
    public class ProjeContext  : DbContext //DbContext sınıfını inherit (kalıtım) yoluyla aldık.
    {
       public ProjeContext()
        {
            Database.Connection.ConnectionString = @"server=. ;Initial Catalog=CodeFirstDB; Integrated Security=True";
        }

        public DbSet<AppUser> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }


    }
}
