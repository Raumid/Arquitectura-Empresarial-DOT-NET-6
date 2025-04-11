using Dapper;
using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Infraestructura.Data;
using Pacagroup.Ecommerce.Infraestructura.Interface;

namespace Pacagroup.Ecommerce.Infraestructura.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly DapperContext _context;
        public CategoriesRepository(DapperContext context) 
        { 
            _context = context;
        }

        public async Task<IEnumerable<Categories>> GetAll()
        { 
            using var connection = _context.CreateConnection();
            var query = "SELECT * FROM Categories";

            var categories = await connection.QueryAsync<Categories>(query, commandType: System.Data.CommandType.Text);
            return categories;
        }
    }
}
