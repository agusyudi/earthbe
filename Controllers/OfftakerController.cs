using Dapper;
using GisApi.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace GisApi.Controllers
{
    [Route("api/offtaker")]
    [ApiController]
    public class OfftakerController(IConfiguration config) : ControllerBase
    {
        private readonly string? connectionString = config.GetConnectionString("PostgresConnection");

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            const string sql = @"
                SELECT 
                    c.id_offtaker AS idofftaker,
                    c.nama_offtaker AS namaofftaker,
                    ST_Y(c.geom) AS Latitude,
                    ST_X(c.geom) AS Longitude
                FROM offtaker c
            ";

            await using var conn = new NpgsqlConnection(connectionString);
            var data = await conn.QueryAsync<OfftakerModel>(sql);
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
                    c.id_offtaker AS idofftaker,
                    c.nama_offtaker AS namaofftaker,
                    ST_Y(c.geom) AS Latitude,
                    ST_X(c.geom) AS Longitude
                FROM offtaker c
            ";

            await using var conn = new NpgsqlConnection(connectionString);
            var data = await conn.QueryAsync<OfftakerSummaryModel>(sql);
            var count = data?.Count();

            if (data.Any())
            {
                foreach (var i in data)
                {
                    var countOfftaker = await conn.QueryFirstOrDefaultAsync<int>("SELECT COUNT(id) FROM aksesoris WHERE id_offtaker=@id_offtaker", new
                    {
                        id_offtaker = i.IdOfftaker
                    });
                    
                    i.TotalizerBulanIni = 10129192.109;
                    i.CountOfftaker = countOfftaker;
                    i.PerkiraanTagihan = 2000102998120;
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