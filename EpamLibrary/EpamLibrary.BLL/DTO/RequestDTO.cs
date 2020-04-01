
namespace EpamLibrary.BLL.DTO
{
    public class RequestDTO
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string ClientName { get; set; }
        public string BookName { get; set; }
        public string ClientProfileId { get; set; }
        public int BookId { get; set; }
    }
}
