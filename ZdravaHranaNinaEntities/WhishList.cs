using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ZdravaHranaNinaEntities
{
    public class WhishList
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
