using DataPorter.Dto;

namespace DataPorter.Service
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerBrowseDto>> GetAllAsync();
        Task CreateAsync(CustomerCreateDto dto);
        Task UpdateAsync(CustomerUpdateDto dto);
        Task DeleteAsync(string id);
    }
}
