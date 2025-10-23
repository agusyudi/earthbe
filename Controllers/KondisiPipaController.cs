using Dapper;
using GisApi.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace GisApi.Controllers
{
    [Route("api/kondisi-pipa")]
    [ApiController]
    public class KondisiPipaController(IConfiguration config) : ControllerBase
    {
        private readonly string? connectionString = config.GetConnectionString("PostgresConnection");

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            const string sql = @"
                SELECT 
                    c.id_kondisi_pipa AS idkondisipipa,
                    c.kondisi_pipa AS kondisipipa
                FROM kondisi_pipa c 
                ORDER BY c.id_kondisi_pipa;
            ";

            await using var conn = new NpgsqlConnection(connectionString);
            var data = await conn.QueryAsync<KondisiPipaModel>(sql);
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