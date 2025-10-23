using Dapper;
using GisApi.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace GisApi.Controllers
{
    [Route("api/diameter-aksesoris")]
    [ApiController]
    public class DiameterAksesorisController(IConfiguration config) : ControllerBase
    {
        private readonly string? connectionString = config.GetConnectionString("PostgresConnection");

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            const string sql = @"
                SELECT 
                    c.id_diameter_aksesoris AS iddiameteraksesoris,
                    c.diameter_aksesoris AS diameteraksesoris
                FROM diameter_aksesoris c 
                ORDER BY c.id_diameter_aksesoris;
            ";

            await using var conn = new NpgsqlConnection(connectionString);
            var data = await conn.QueryAsync<DiameterAksesorisModel>(sql);
            var count = data?.Count();

            return Ok(new
            {
                Status = true,
                TotalRecord = count,
                Data = data,
            });
        }

 
    }
}