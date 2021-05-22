using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Library.Models
{
    public partial class Book
    {
        [Display(Name = "Код книги")]
        public long BookId { get; set; }
        [Display(Name = "Название книги")]
        public string BookTitle { get; set; }
        [Display(Name = "Автор")]
        public string Author { get; set; }
        [Display(Name = "Год публикации")]
        public DateTime PubYear { get; set; }
        [Display(Name = "Жанр")]
        public long GenId { get; set; }
        [Display(Name = "Издательство")]
        public long PubId { get; set; }
        [Display(Name = "Жанр")]  
        public virtual Genre Gen { get; set; }
        [Display(Name = "Издательство")]
        public virtual Publisher Pub { get; set; }
    }
}
