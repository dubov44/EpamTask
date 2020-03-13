using System.ComponentModel.DataAnnotations;

namespace EpamLibrary.Tables.Models.Abstract
{
    public abstract class AbstractDbObject
    {
        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
