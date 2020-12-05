using System;
using System.Collections.Generic;

namespace Library.Core
{
    public partial class Gender
    {
        public Gender()
        {
            Book = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string NameGender { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
