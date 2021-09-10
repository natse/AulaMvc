using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    [Table("Todo")]
    public class ToDo:EntityBase<int>
    {
        [Required]
        [Column ("Tarefa")]
        public string Tarefa { get; set; }
        
    }
}
