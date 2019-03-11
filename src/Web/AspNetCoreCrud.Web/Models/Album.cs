using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreCrud.Web.Models
{
    public class Album
    {
        public int ID { get; set; }

        public string Artist { get; set; }
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        public string Genre { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Range(1,100.00)]
        public decimal Price { get; set; }

        public int Rank { get; set; }
    
        public byte[] Image { get; set; }
    }
}
