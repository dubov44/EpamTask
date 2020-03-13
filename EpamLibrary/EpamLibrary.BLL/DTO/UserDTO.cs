using EpamLibrary.BLL.DTO.Abstract;

namespace EpamLibrary.BLL.DTO
{
    public class UserDTO : AbstractDTOObject
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}