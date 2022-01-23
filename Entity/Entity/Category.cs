using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entity
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        [StringLength(maximumLength: 50)]
        public string Name { get; set; }

        [Required]
        public string AspNetUserId { get; set; }

        [JsonIgnore]
        public ICollection<Bookmark> Bookmarks { get; set; }
    }
}
