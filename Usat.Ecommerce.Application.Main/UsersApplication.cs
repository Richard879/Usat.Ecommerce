using AutoMapper;
using Usat.Ecommerce.Application.DTO;
using Usat.Ecommerce.Application.Interface;
using Usat.Ecommerce.Application.Validator;
using Usat.Ecommerce.Domain.Interface;
using Usat.Ecommerce.Transversal.Common;

namespace Usat.Ecommerce.Application.Main
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUsersDomain _userDomain;
        private readonly IMapper _mapper;
        private readonly UserDtoValidator _validator;

        public UsersApplication(IUsersDomain userDomain, IMapper mapper, UserDtoValidator validator)
        {
            _userDomain = userDomain;
            _mapper = mapper;
            _validator = validator;
        }

        public Response<UserDto> Authenticate(string username, string password)
        {
            var response = new Response<UserDto>();
            var validation = _validator.Validate(new UserDto() { UserName = username, Password = password });
            if (!validation.IsValid)
            {
                response.Message = "Errores de validación";
                response.Errors = validation.Errors;
                return response;
            }

            try
            {
                var user = _userDomain.Authenticate(username, password);
                response.Data = _mapper.Map<UserDto>(user);
                response.IsSucces = true;
                response.Message = "Autenticación Exitosa!!!";
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
