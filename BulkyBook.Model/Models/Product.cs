using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Model.Models
{
   public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string ISBN { get; set; }

        public string Description { get; set; }

              
        public string ImageUrl{ get; set; }

        [Required]
        [Range(1,100000)]
        public double Price { get; set; }

        [Required]
        [Range(1, 100000)]
        public double Price50 { get; set; }

        [Required]
        [Range(1, 100000)]
        public double Price100 { get; set; }

        [Required]
        public int CatagoryId { get; set; }


        [ForeignKey("CatagoryId")]
        public Catagory Catagory { get; set; }


        [ForeignKey("CoverTypeId")]
        public CoverType CoverType { get; set; }


        [Required]
        public int CoverTypeId { get; set; }



    }
}
