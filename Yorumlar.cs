using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TatilVeSeyahatSitesi.Models.Siniflar
{
    public class Yorumlar
    {
        [Key]
        public int ID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Mail { get; set; }
        public string Yorum { get; set; }

        public int Blogid { get; set; } 
        public virtual Blog Blog { get; set; }           // Blogdan gelecek değeri tutuyor yani iki tabloyu ilişkilendirdik.
                                                 // Bloglar ve yorumlar arasında ilişki oluşturduk. . Bire çok ilişki
    }
}