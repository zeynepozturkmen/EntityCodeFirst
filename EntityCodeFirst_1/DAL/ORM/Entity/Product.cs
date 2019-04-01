using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCodeFirst_1.DAL.ORM.Entity
{
    public class Product : BaseEntity //"BaseEntity" Classından kalıtım alıyor.
    {
        public decimal? UnitPrice { get; set; } //"Decimal" türü falan default olarak not null(bos gecilemez) oluyor.Soru işareti koyarak boş gecilebilecegini belirtiyoruz.

        public short? UnitInStock { get; set; }

        [MaxLength(30)]
        public string QuantityPerUnit { get; set; }

        public int CategoryID { get; set; }

        public virtual Category category { get; set; } //Bir ürünün bir kategorisi olur.
    }
}
