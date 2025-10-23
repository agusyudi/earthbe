using Dapper;
using GisApi.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace GisApi.Controllers
{
    [Route("api/wilayah")]
    [ApiController]
    public class WilayahController(IConfiguration config) : ControllerBase
    {
        private readonly string? connectionString = config.GetConnectionString("PostgresConnection");

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            const string sql = @"
                SELECT 
                    c.id_wilayah AS idWilayah,
                    c.provinsi,
                    c.kab_kota As kabkota,
                    c.offtaker,
                    c.debit,
                    c.color,
                    ST_AsGeoJSON(geom) AS geometry
                FROM wilayah c;
            ";

            await using var conn = new NpgsqlConnection(connectionString);
            var data = await conn.QueryAsync<WilayahModel>(sql);
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