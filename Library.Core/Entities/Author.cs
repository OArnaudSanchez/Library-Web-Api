using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Core
{
    public partial class Author
    {
        public Author()
        {
            Book = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool AuthorGender { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
