using Dapper;
using GisApi.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace GisApi.Controllers
{
    [Route("api/spam")]
    [ApiController]
    public class SpamController(IConfiguration config) : ControllerBase
    {
        private readonly string? connectionString = config.GetConnectionString("PostgresConnection");

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            const string sql = @"
                SELECT 
                    c.id_spam AS idspam,
                    c.nama_spam AS namaspam,
                    c.harga_m3 AS hargam3,
                    ST_Y(c.geom) AS Latitude,
                    ST_X(c.geom) AS Longitude
                FROM spam c 
                ORDER BY c.id_spam;
            ";

            await using var conn = new NpgsqlConnection(connectionString);
            var data = await conn.QueryAsync<SpamModel>(sql);
            var count = data?.Count();

            return Ok(new
            {
                Status = true,
                TotalRecord = count,
                Data = data,
            });
        }

        [HttpGet("summary")]
        public async Task<IActionResult> GetSummary()
        {
            const string sql = @"
                SELECT 
                    c.id_spam AS idspam,
                    c.nama_spam AS namaspam,
                    c.harga_m3 AS hargam3,
                    ST_Y(c.geom) AS Latitude,
                    ST_X(c.geom) AS Longitude
                FROM spam c
            ";

            await using var conn = new NpgsqlConnection(connectionString);
            var data = await conn.QueryAsync<SpamSummaryModel>(sql);
            var count = data?.Count();

            if (data.Any())
            {
                foreach (var i in data)
                {
                    i.TotalizerBulanIni = 10129192.109;
                    i.TotalizerMingguIni = 10092.012;
                    i.Tekanan = 50.0;
                }
            }
            return Ok(new
            {
                Status = true,
                TotalRecord = count,
                Data = data,
            });
        }

    }
}