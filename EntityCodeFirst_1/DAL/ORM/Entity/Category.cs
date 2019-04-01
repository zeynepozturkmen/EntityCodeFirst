using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCodeFirst_1.DAL.ORM.Entity
{
   public class Category :BaseEntity
    {
        public  Category() {
            this.products = new HashSet<Product>();
        }

        [MaxLength(255)]
        public string Description { get; set; }

        public virtual ICollection<Product> products { get; set; } //Bir categorinin birden çok ürünü olur.Bire çok ilişki(one to many)
    }
}
