using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Djupvikv01.Models
{
    public class ArticleModel
    {
        public int id { get; set; }
        [Required]
        public string forfattare { get; set; }
        [Required]
        public string artikeltyp { get; set; }
        [Required]
        public string rubrik { get; set; }
        [Required]
        public string sammanfattning { get; set; }
        [Required]
        public string innehall { get; set; }
        [Required]
        public string bild { get; set; }
        [Required]
        public string datum { get; set; }
     


        public ArticleModel()
        {
      
        }
   
        public ArticleModel(int id, string forfattare, string artikeltyp, string rubrik, string sammanfattning, string innehall, string bild, string datum)
        {
            this.id = id;
            this.forfattare = forfattare;
            this.artikeltyp = artikeltyp;
            this.rubrik = rubrik;
            this.sammanfattning = sammanfattning;
            this.innehall = innehall;
            this.bild = bild;
            this.datum = datum;
        }
 
    }
}



 