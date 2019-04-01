using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCodeFirst_1.DAL.ORM.Entity
{
    [Table("Users")] //TABLOMUZUN ADININ "AppUser" olmasını istemeyip değiştiriyoruz.
    public class AppUser : BaseEntity
    {
        
        //default olarak maxlength nvarchar(MAX) olarak alır.
        [MaxLength(30)]
        public string Lastname { get; set; }


        [NotMapped] //TABLOYA SÜTUN OLARAK EKLEMEMEK İÇİN "NotMapped" KULLANDIK.FULLNAME SADECE GERİYE DEGERİNİ GÖRMEK İSTİYORUZ TABLODA SÜTUN OLARAK GÖZÜKMESİNİ İSTEMİYORUZ.
        public string FullName {
            get
            {
                if (string.IsNullOrWhiteSpace(Lastname))
                {
                    return Name;
                }
                else
                {
                    return Name + " " + Lastname;
                }
            }
                               }

        [Required] //Required=NULL GECİLEMEZ.STRİNG'TE "Required" ı eklemezsek default olarak boş geçilebilir kabul ediyor.
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime? Birth_Date { get; set; } //Null GECİLEBİLSİN DİYE SORU İŞARETİ EKLEDİK GALİBA.

        public string Gender { get; set; } //cinsiyet





    }
}
