using DataPorter.Dto;

namespace DataPorter.Service
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerBrowseDto>> GetAllAsync();
        Task<CustomerUpdateDto> GetCustomer(string id);
        Task CreateAsync(CustomerCreateDto dto);
        Task UpdateAsync(CustomerUpdateDto dto);
        Task DeleteAsync(string id);
    }
}
