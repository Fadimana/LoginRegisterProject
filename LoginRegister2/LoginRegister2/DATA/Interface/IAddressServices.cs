using LoginRegister2.DATA.DTOS;
using LoginRegister2.DATA.Model;
using Response;


namespace LoginRegister2.DATA.Interface
{
    public interface IAddressServices 
    {
        Task <Address> CreateAddrees(Address address);
        Task <List<Address>> GetAddress(string userıd);

        Task <List<User>> GetAllUsers();

        Task<User> GetAllUserId(string ıd,string tokenıd);

       
    }
}
