using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Core
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Editorial { get; set; }
        public int Author { get; set; }
        public int Gender { get; set; }

        public virtual Author AuthorNavigation { get; set; }
        public virtual Gender GenderNavigation { get; set; }
    }
}
