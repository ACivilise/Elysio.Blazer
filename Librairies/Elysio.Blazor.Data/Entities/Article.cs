using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Elysio.Blazor.Data.Entities
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
