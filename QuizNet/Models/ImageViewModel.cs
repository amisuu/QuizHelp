using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizNet.Models
{
    public class ImageViewModel
    {
        [Key]
        public int ImageID { get; set; }

        [DisplayName("Title")]
        [Required(ErrorMessage = "Please give it a title")]
        public string Title { get; set; }

        [DisplayName("Description")]
        public string ImageDescription { get; set; }

        [Display(Name = "Uploaded image")]
        public IFormFile ImageProfile { get; set; }
    }
}
