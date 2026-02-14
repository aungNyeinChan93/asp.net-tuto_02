using System;
using System.Collections.Generic;
using System.Text;

namespace One.ConsoleApp1
{
    public class BlogModel
    {
        public int BlogId { get; set; }
        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? AuthorName  { get; set; }

        public bool DeleteFlag { get; set; }
    }
}
