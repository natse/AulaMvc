using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class EntityBase <T> where T: struct
    {
        [Column("Id")]
        public T Id { get; set; }
    }
}
