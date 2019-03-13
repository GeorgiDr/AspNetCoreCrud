using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreCrud.Web.Models.ViewModel
{
    public class ViewModelCategoryAlbum
    {
        public int ID { get; set; }

        public string Artist { get; set; }
     
        public string Name { get; set; }

        public string Genre { get; set; }

        public DateTime ReleaseDate { get; set; }

        public decimal Price { get; set; }

        public int Rank { get; set; }

        public byte[] Image { get; set; }

        public IList<Category> Categories { get; set; }

        public int SelectedCategory { get; set; }
    }
}
