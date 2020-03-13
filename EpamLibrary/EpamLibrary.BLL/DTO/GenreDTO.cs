using EpamLibrary.BLL.DTO.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamLibrary.BLL.DTO
{
    public class GenreDTO : AbstractDTOObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
