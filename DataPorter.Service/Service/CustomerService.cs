using AutoMapper;
using DataPorter.Data;
using DataPorter.Dto;
using DataPorter.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataPorter.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CustomerBrowseDto>> GetAllAsync()
        {
            var customers = await _unitOfWork.Customers.GetAllAsync(include: q => q.Include(c => c.Company));

            return _mapper.Map<IEnumerable<CustomerBrowseDto>>(customers);

        }

        public async Task<CustomerUpdateDto> GetCustomer(string id)
        {
            var customer = await SearchCustomer(id);
            return _mapper.Map<CustomerUpdateDto>(customer);
        }

        public async Task CreateAsync(CustomerCreateDto dto)
        {
            if (await _unitOfWork.Customers.GetByIdAsync(dto.Id) is not null)
            {
                throw new Exception($"Customer with id '{dto.Id}' already exists.");
            }
            if (await _unitOfWork.Companies.GetByIdAsync(dto.CompanyId) is null)
            {
                throw new Exception($"Company with id '{dto.CompanyId}' not found.");
            }
            var customer = _mapper.Map<Customer>(dto);
            await _unitOfWork.Customers.AddAsync(customer);
            await _unitOfWork.SaveAsync();
        }
        public async Task UpdateAsync(CustomerUpdateDto dto)
        {

            var customer = await SearchCustomer(dto.Id);
            if (dto.CompanyId is not null && await _unitOfWork.Companies.GetByIdAsync(dto.CompanyId) is null)
            {
                throw new Exception($"Company with id '{dto.CompanyId}' not found.");
            }
            _mapper.Map(dto, customer);

            await _unitOfWork.SaveAsync();
        }
        public async Task DeleteAsync(string id)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(id);
            if (customer is null)
            {
                throw new Exception($"Customer with id '{id}' not found.");
            }
            _unitOfWork.Customers.Delete(customer);
            await _unitOfWork.SaveAsync();
        }

        private async Task<Customer> SearchCustomer(string id)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(id);
            if (customer is null)
            {
                throw new Exception($"Customer with id '{id}' not found.");
            }
            return customer;
        }
    }
}
