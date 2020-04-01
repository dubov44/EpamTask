using System;

namespace EpamLibrary.BLL.DTO
{
    public class RentedBookDTO
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int BookId { get; set; }
        public string Name { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int Penalty { get; set; }
        public bool IsExpired { get; set; }
        public bool ReadingRoom { get; set; }
    }
}
