using Dapper;
using RealEstate_Dapper_Api.Dtos.PropertyAmenityDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PropertyAmenityRepository;

public class PropertyAmenityRepository : IPropertyAmenityRepository
{
    private readonly Context _context;

    public PropertyAmenityRepository(Context context)
    {
        _context = context;
    }

    public async Task<List<ResultPropertyAmenityByStatusTrueDto>> GetPropertyAmenityByStatusTrue(int id)
    {
        string query = @"Select pa.PropertyId, pa.PropertyAmenityId, a.Title
                        From PropertyAmenity pa 
                        Inner Join Amenity a On a.AmenityId = pa.AmenityId
                        Where pa.PropertyId = @propertyId And pa.Status = 1";
        var parameters = new DynamicParameters();
        parameters.Add("propertyId", id);
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultPropertyAmenityByStatusTrueDto>(query, parameters);
            return values.ToList();
        }
    }
}
