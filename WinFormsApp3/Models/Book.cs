using System;
using System.Collections.Generic;

#nullable disable

namespace WinFormsApp3.Models
{
    public partial class Book
    {
        public string BookId { get; set; }
        public string BookName { get; set; }
        public int? Quantity { get; set; }
        public string AuthorName { get; set; }
        public string PublisherId { get; set; }

        public virtual Publisher Publisher { get; set; }
    }
}
