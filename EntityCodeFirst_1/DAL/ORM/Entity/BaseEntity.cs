using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCodeFirst_1.DAL.ORM.Entity
{
   public class BaseEntity
    {
        //Property (sütunlarını tanımlama)

        [Key]
        [Column(Order=1)] //column 1.sırada ID var
        public int ID { get; set; }
         
        [Column(Order =2)] //column 2.sırada Name var
        public string Name { get; set; }

        [Column(TypeName ="datetime2")] //datetime2 = 00'dan itibaren daha geniş tarih alıyor."datetime1" 1980'den sonrasını alıyor galiba.
        public DateTime? Added_Date { get; set; }

        public bool isActive { get; set; }


    }
}
