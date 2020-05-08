using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuizNet.DataAccess.Models
{
    public class Image
    {
        [Key]
        public int ImageID { get; set; }

        [DisplayName("Title")]
        [Required(ErrorMessage = "Please give it a title")]
        public string Title { get; set; }

        [DisplayName("Description")]
        public string ImageDescription { get; set; }

        [Required(ErrorMessage = "Please choose your image")]
        public string ImageProfile { get; set; }
    }
}
