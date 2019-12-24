using System.ComponentModel.DataAnnotations;

namespace ORM.data
{
    internal class BaseEntity
    {
        [Key]
        public int id { get; set; }
    }
}