using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usat.Ecommerce.Application.DTO;
using Usat.Ecommerce.Application.Interface;
using Usat.Ecommerce.Domain.Interface;
using Usat.Ecommerce.Transversal.Common;

namespace Usat.Ecommerce.Application.Main
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUsersDomain _userDomain;
        private readonly IMapper _mapper;
        public UsersApplication(IUsersDomain userDomain, IMapper mapper)
        {
            _userDomain = userDomain;
            _mapper = mapper;
        }

        public Response<UserDto> Authenticate(string username, string password)
        {
            var response = new Response<UserDto>();
            //var validation = _usersDtoValidator.Validate(new UserDto() { UserName = username, Password = password });
            /*if (!validation.IsValid)
            {
                response.Message = "Errores de validación";
                //response.Errors = validation.Errors;
                return response;
            }*/

            try
            {
                var user = _userDomain.Authenticate(username, password);
                response.Data = _mapper.Map<UserDto>(user);
                response.IsSucces = true;
                response.Message = "Autenticación Existosa!!!";
            }
            catch (InvalidOperationException)
            {
                response.IsSucces = true;
                response.Message = "Usuario no existe!!!";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
