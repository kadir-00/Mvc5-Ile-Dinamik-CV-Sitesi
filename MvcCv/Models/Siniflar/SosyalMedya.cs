using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcCv.Models.Siniflar
{
    public class SosyalMedya
    {
        [Key]
        public int ID { get; set; }
        public string Ad { get; set; }
        public string Link { get; set; }
        public string Ikon { get; set; }
    }
}
