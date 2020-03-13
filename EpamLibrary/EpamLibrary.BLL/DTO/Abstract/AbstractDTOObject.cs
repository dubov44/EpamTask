using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamLibrary.BLL.DTO.Abstract
{
    public abstract class AbstractDTOObject
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
