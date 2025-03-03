using Dapper;
using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Infraestructura.Interface;
using Pacagroup.Ecommerce.Transversal.Common;
using System.Data;

namespace Pacagroup.Ecommerce.Infraestructura.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public UsersRepository(IConnectionFactory connectionFactory) 
        {
            _connectionFactory = connectionFactory;
        }

        public Users Authenticate(string username, string password)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                string query = "UsersGetByUserAndPassword";
                var parameters = new DynamicParameters();
                parameters.Add("username", username);
                parameters.Add("password", password);

                var user = connection.QuerySingle<Users>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return user;
            }
        }
    }
}
