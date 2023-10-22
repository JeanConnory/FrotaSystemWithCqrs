using Dapper;
using FrotaApp.Application.Output.DTOs;
using FrotaApp.Application.Output.Interfaces;
using FrotaApp.Infrastructure.Output.Queries;
using FrotaApp.Infrastructure.Shared.Factory;
using System.Data;

namespace FrotaApp.Infrastructure.Output.Repositories
{
    public class ReadVehicleRepository : IReadVehicleRepository
    {
        private readonly IDbConnection _connection;

        public ReadVehicleRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public IEnumerable<VehicleDTO> FindByCategoryId(int categoryId)
        {
            var query = new VehicleQueries().GetVehiclesByCategoryId(categoryId);

            try
            {
                using (_connection)
                {
                    return _connection.Query<VehicleDTO>(query.Query, query.Parameters) as List<VehicleDTO>;
                }
            }
            catch
            {
                throw new Exception("Falha ao recuperar veículo");
            }
        }

        public VehicleDTO FindById(int id)
        {
            var query = new VehicleQueries().GetVehicleById(id);

            try
            {
                using (_connection)
                {
                    return _connection.QueryFirstOrDefault<VehicleDTO>(query.Query, query.Parameters);
                }
            }
            catch
            {
                throw new Exception("Falha ao recuperar veículo");
            }
        }

        public IEnumerable<VehicleDTO> GetVehicles()
        {
            var query = new VehicleQueries().GetAllVehicles();
            
            try
            {
                using(_connection)
                {
                    return _connection.Query<VehicleDTO>(query.Query) as List<VehicleDTO>;
                }
            }
            catch
            {
                throw new Exception("Falha ao recuperar todos os veículos");
            }
        }
    }
}
