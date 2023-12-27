using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Usat.Ecommerce.Application.DTO;
using Usat.Ecommerce.Application.Interface;

namespace Usat.Ecommerce.Services.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly ICustomersApplication _customersAplication;
        public CustomersController(ICustomersApplication customersAplication)
        {
            _customersAplication = customersAplication;
        }

        #region Metodos Síncronos
        [HttpPost("Insert")]
        public IActionResult Insert([FromBody] CustomerDto customersDTO)
        {
            if (customersDTO == null)
                return BadRequest();
            var response = _customersAplication.Insert(customersDTO);
            if (response.IsSucces)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] CustomerDto customersDTO)
        {
            if (customersDTO == null)
                return BadRequest();
            var response = _customersAplication.Update(customersDTO);
            if (response.IsSucces)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("Delete{customersId}")]
        public IActionResult Delete(string customersId)
        {
            if (string.IsNullOrEmpty(customersId))
                return BadRequest();
            var response = _customersAplication.Delete(customersId);
            if (response.IsSucces)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("Get{customersId}")]
        public IActionResult Get(string customersId)
        {
            if (string.IsNullOrEmpty(customersId))
                return BadRequest();
            var response = _customersAplication.Get(customersId);
            if (response.IsSucces)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var response = _customersAplication.GetAll();
            if (response.IsSucces)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAllWithPagination")]
        public IActionResult GetAllWithPagination([FromQuery] int pageNumber, int pageSize)
        {
            var response = _customersAplication.GetAllWithPagination(pageNumber, pageSize);
            if (response.IsSucces)
                return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion

        #region Metodos Asíncronos
        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody] CustomerDto customersDTO)
        {
            if (customersDTO == null)
                return BadRequest();
            var response = await _customersAplication.InsertAsync(customersDTO);
            if (response.IsSucces)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] CustomerDto customersDTO)
        {
            if (customersDTO == null)
                return BadRequest();
            var response = await _customersAplication.UpdateAsync(customersDTO);
            if (response.IsSucces)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("DeleteAsync/{customersId}")]
        public async Task<IActionResult> DeleteAsync(string customersId)
        {
            if (string.IsNullOrEmpty(customersId))
                return BadRequest();
            var response = await _customersAplication.DeleteAsync(customersId);
            if (response.IsSucces)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAsync/{customersId}")]
        public async Task<IActionResult> GetAsync(string customersId)
        {
            if (string.IsNullOrEmpty(customersId))
                return BadRequest();
            var response = await _customersAplication.GetAsync(customersId);
            if (response.IsSucces)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAlAsync")]
        public async Task<IActionResult> GetAlAsync()
        {
            var response = await _customersAplication.GetAllAsync();
            if (response.IsSucces)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAllWithPaginationAsync")]
        public async Task<IActionResult> GetAllWithPaginationAsync([FromQuery] int pageNumber, int pageSize)
        {
            var response = await _customersAplication.GetAllWithPaginationAsync(pageNumber, pageSize);
            if (response.IsSucces)
                return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion
    }
}
