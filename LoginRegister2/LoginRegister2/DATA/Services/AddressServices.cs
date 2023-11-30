using LoginRegister2.DATA.Context;
using LoginRegister2.DATA.DTOS;
using LoginRegister2.DATA.Interface;
using LoginRegister2.DATA.Model;
using MessageClass.Message;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Response;

namespace LoginRegister2.DATA.Services
{
    public class AddressServices : IAddressServices
    {
        private readonly DBContext _context;

        public AddressServices(DBContext context)
        {
            _context = context;
        }
        public async Task<Address> CreateAddrees(Address address)
        {

            var addresses = await _context.Addresses.Where(x => x.UserId == address.UserId).OrderBy(x => x.Id).LastOrDefaultAsync();
            if (addresses != null)
            {
                addresses.Control = false;

            }
          
            Address address1 = new Address()
            {
                City = address.City,
                ApartmanName = address.ApartmanName,
                Street = address.Street,
                Control = true,
                PostalCode = address.PostalCode,
                Country = address.Country,
                UserId= address.UserId,
            };
             await _context.AddAsync(address1);
             await _context.SaveChangesAsync();
             return address1;

        }
        public async Task<List<Address>> GetAddress(string userıd)
        {   
        
            return await _context.Addresses.Where(x => (x.Control == true) && (x.UserId==userıd)).ToListAsync();
        
        }




        public async Task<List<User>> GetAllUsers()
        {

            return await _context.Users.Include(x => x.addresses).ToListAsync();
        
        }


        public async Task<User> GetAllUserId(string ıd, string tokenıd)
        {
            if (ıd == tokenıd)
            {

                return await _context.Users.Include(x => x.addresses).FirstOrDefaultAsync(x => x.Id == ıd);
            
            }

            throw new NotImplementedException();    
        }
    }
}







