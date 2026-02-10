using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcCv.Models.Siniflar
{
    public class Proje
    {
        [Key]
        public int ID { get; set; }
        public string ProjeAdi { get; set; }
        public string Aciklama { get; set; }
        public string ProjeUrl { get; set; }
    }
}
