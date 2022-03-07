using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDepartman1.Models
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }
        public string PersonelAD { get; set; }
        public string PersonelSoyad { get; set; }
        public string Sehir { get; set; }
        public int BirimId { get; set; }
        public Birim Birim { get; set; }
    }
}
