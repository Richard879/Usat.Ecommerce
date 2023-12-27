using AutoMapper;
using Usat.Ecommerce.Application.DTO;
using Usat.Ecommerce.Application.Interface;
using Usat.Ecommerce.Domain.Entity;
using Usat.Ecommerce.Domain.Interface;
using Usat.Ecommerce.Transversal.Common;

namespace Usat.Ecommerce.Application.Main
{
    public class CustomersApplication :ICustomersApplication
    {
        private readonly ICustomersDomain _customersDomain;
        private readonly IMapper _mapper;

        public CustomersApplication(ICustomersDomain customersDomain, IMapper mapper)
        {
            _customersDomain = customersDomain;
            _mapper = mapper;
        }

        #region Métodos Síncronos
        public Response<bool> Insert(CustomerDto customersDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customersDto);
                response.Data = _customersDomain.Insert(customer);
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
                response.Data = _customersDomain.Update(customer);
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
                response.Data = _customersDomain.Delete(customerId);
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
                var customer = _customersDomain.Get(customerId);
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
                var customers = _customersDomain.GetAll();
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
        #endregion

        #region Métodos Asíncronos
        public async Task<Response<bool>> InsertAsync(CustomerDto customersDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customersDto);
                response.Data = await _customersDomain.InsertAsync(customer);
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
                response.Data = await _customersDomain.UpdateAsync(customer);
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
                response.Data = await _customersDomain.DeleteAsync(customerId);
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
                var customer = await _customersDomain.GetAsync(customerId);
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
                var customers = await _customersDomain.GetAllAsync();
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
        #endregion
    }
}
