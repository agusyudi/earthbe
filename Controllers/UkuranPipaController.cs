using Dapper;
using GisApi.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace GisApi.Controllers
{
    [Route("api/ukuran-pipa")]
    [ApiController]
    public class UkuranPipaController(IConfiguration config) : ControllerBase
    {
        private readonly string? connectionString = config.GetConnectionString("PostgresConnection");

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            const string sql = @"
                SELECT 
                    c.id_ukuran_pipa AS idukuranpipa,
                    c.ukuran_pipa AS ukuranpipa
                FROM ukuran_pipa c 
                ORDER BY c.id_ukuran_pipa;
            ";

            await using var conn = new NpgsqlConnection(connectionString);
            var data = await conn.QueryAsync<UkuranPipaModel>(sql);
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