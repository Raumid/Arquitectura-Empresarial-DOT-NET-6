using AutoMapper;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Transversal.Common;
using Pacagroup.Ecommerce.Application.Validator;

namespace Pacagroup.Ecommerce.Application.Main
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUsersDomain _usersDomain;
        private readonly IMapper _mapper;
        private readonly UsersDtoValidator _usersValidator;

        public UsersApplication(IUsersDomain usersDomain, IMapper mapper, UsersDtoValidator usersValidator)
        {
            _usersDomain = usersDomain;
            _mapper = mapper;
            _usersValidator = usersValidator;
        }

        public Response<UsersDTO> Authenticate(string userName, string password)
        { 
            var response = new Response<UsersDTO>();
            var validation = _usersValidator.Validate(new UsersDTO() { UserName = userName, Password = password});

            if(!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                return response;
            }

            try
            {
                var user = _usersDomain.Authenticate(userName, password);
                response.Data = _mapper.Map<UsersDTO>(user);
                response.IsSuccess = true;
                response.Message = "Autenticacion Exitosa";
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "Usuario no Existe";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
