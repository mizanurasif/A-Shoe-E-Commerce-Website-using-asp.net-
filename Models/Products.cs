using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace Cobbler.Models
{
    public class Products
    {
     
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

       // [Required]
        [Display(Name = "Main Image")]
        public string Image_Main { get; set; }

        //[Required]
        [Display(Name = "Secondary Image")]
        public string Image_secondary { get; set; }

       // [Required]
        [Display(Name = "Extra Image 1")]
        public string Image_extra1 { get; set; }


        //[Required]
        [Display(Name = "Extra Image 2")]
        public string Image_extra2 { get; set; }

        [Required]
        [Display(Name = "Available")]
        public bool IsAvailable { get; set; }

        //[Required]
        public string Description { get; set; }


        [Required]
        [Display(Name = "Product Type")]
        public int ProductTypeId { get; set; }

        [ForeignKey("ProductTypeId")]
        public virtual ProductTypes ProductTypes { get; set; }


    }
}
