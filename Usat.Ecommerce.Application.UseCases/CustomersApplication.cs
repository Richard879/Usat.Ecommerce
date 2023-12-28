using AutoMapper;
using Usat.Ecommerce.Application.DTO;
using Usat.Ecommerce.Application.Interface.Persistence;
using Usat.Ecommerce.Application.Interface.UseCases;
using Usat.Ecommerce.Domain.Entity;
using Usat.Ecommerce.Transversal.Common;

namespace Usat.Ecommerce.Application.UseCases
{
    public class CustomersApplication :ICustomersApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CustomersApplication> _logger;

        public CustomersApplication(IUnitOfWork unitOfWork,  IMapper mapper, IAppLogger<CustomersApplication> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        #region Métodos Síncronos
        public Response<bool> Insert(CustomerDto customersDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customersDto);
                response.Data = _unitOfWork.Customers.Insert(customer);
                if (response.Data)
                {
                    response.IsSucces = true;
                    response.Message = "Registro exitoso..!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public Response<bool> Update(CustomerDto customersDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customersDto);
                response.Data = _unitOfWork.Customers.Update(customer);
                if (response.Data)
                {
                    response.IsSucces = true;
                    response.Message = "Actualización exitosa..!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public Response<bool> Delete(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = _unitOfWork.Customers.Delete(customerId);
                if (response.Data)
                {
                    response.IsSucces = true;
                    response.Message = "Eliminación exitosa..!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public Response<CustomerDto> Get(string customerId)
        {
            var response = new Response<CustomerDto>();
            try
            {
                var customer = _unitOfWork.Customers.Get(customerId);
                response.Data = _mapper.Map<CustomerDto>(customer);
                if (response.Data != null)
                {
                    response.IsSucces = true;
                    response.Message = "Consulta exitosa..!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public Response<IEnumerable<CustomerDto>> GetAll()
        {
            var response = new Response<IEnumerable<CustomerDto>>();
            try
            {
                var customers = _unitOfWork.Customers.GetAll();
                response.Data = _mapper.Map<IEnumerable<CustomerDto>>(customers);
                if (response.Data != null)
                {
                    response.IsSucces = true;
                    response.Message = "Consulta exitosa..!!";
                    _logger.LogInformation("Consulta exitosa..!!");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }
        public ResponsePagination<IEnumerable<CustomerDto>> GetAllWithPagination(int pageNumber, int pageSize)
        {
            var response = new ResponsePagination<IEnumerable<CustomerDto>>();
            try
            {
                var count = _unitOfWork.Customers.Count();
                var customers = _unitOfWork.Customers.GetAllWithPagination(pageNumber, pageSize);
                response.Data = _mapper.Map<IEnumerable<CustomerDto>>(customers);
                if (response.Data != null)
                {
                    response.PageNumer = pageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                    response.TotalCount = count;
                    response.IsSucces = true;
                    response.Message = "Consulta paginada exitosa..!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }
        #endregion

        #region Métodos Asíncronos
        public async Task<Response<bool>> InsertAsync(CustomerDto customersDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customersDto);
                response.Data = await _unitOfWork.Customers.InsertAsync(customer);
                if (response.Data)
                {
                    response.IsSucces = true;
                    response.Message = "Registro exitoso..!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public async Task<Response<bool>> UpdateAsync(CustomerDto customersDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customersDto);
                response.Data = await _unitOfWork.Customers.UpdateAsync(customer);
                if (response.Data)
                {
                    response.IsSucces = true;
                    response.Message = "Actualización exitosa..!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public async Task<Response<bool>> DeleteAsync(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _unitOfWork.Customers.DeleteAsync(customerId);
                if (response.Data)
                {
                    response.IsSucces = true;
                    response.Message = "Eliminación exitosa..!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public async Task<Response<CustomerDto>> GetAsync(string customerId)
        {
            var response = new Response<CustomerDto>();
            try
            {
                var customer = await _unitOfWork.Customers.GetAsync(customerId);
                response.Data = _mapper.Map<CustomerDto>(customer);
                if (response.Data != null)
                {
                    response.IsSucces = true;
                    response.Message = "Consulta exitosa..!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public async Task<Response<IEnumerable<CustomerDto>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CustomerDto>>();
            try
            {
                var customers = await _unitOfWork.Customers.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<CustomerDto>>(customers);
                if (response.Data != null)
                {
                    response.IsSucces = true;
                    response.Message = "Consulta exitosa..!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public async Task<ResponsePagination<IEnumerable<CustomerDto>>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            var response = new ResponsePagination<IEnumerable<CustomerDto>>();
            try
            {
                var count = await _unitOfWork.Customers.CountAsync();
                var customers = await _unitOfWork.Customers.GetAllWithPaginationAsync(pageNumber, pageSize);
                response.Data = _mapper.Map<IEnumerable<CustomerDto>>(customers);
                if (response.Data != null)
                {
                    response.PageNumer = pageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                    response.TotalCount = count;
                    response.IsSucces = true;
                    response.Message = "Consulta paginada exitosa..!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }
        #endregion
    }
}
