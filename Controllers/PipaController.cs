using Dapper;
using GisApi.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace GisApi.Controllers
{
    [Route("api/pipa")]
    [ApiController]
    public class PipaController(IConfiguration config) : ControllerBase
    {
        private readonly string? connectionString = config.GetConnectionString("PostgresConnection");

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            const string sql = @"
                SELECT 
                    c.id,
                    c.kode,
                    c.id_ukuran_pipa AS idukuranpipa,
                    u.ukuran_pipa as ukuranpipa,
                    c.id_jenis_pipa AS idjenispipa,
                    j.jenis_pipa as jenisPipa,
                    c.thn_buat as thnbuat,
                    c.tanggal_pemasangan as tanggalpemasangan,
                    c.tanggal_perawatan as tanggalperawatan,
                    c.elevasi,
                    c.id_status_pipa AS idstatuspipa,
                    s.status_pipa as statuspipa,
                    c.id_kondisi_pipa AS idkondisipipa,
                    k.kondisi_pipa as kondisipipa,
                    c.panjang,
                    c.keterangan,
                    c.color,
                    c.ketebalan,
                    ST_AsGeoJSON(geom) AS geometry
                FROM pipa c 
                LEFT JOIN ukuran_pipa u ON c.id_ukuran_pipa = u.id_ukuran_pipa 
                LEFT JOIN jenis_pipa j ON c.id_jenis_pipa = j.id_jenis_pipa
                LEFT JOIN status_pipa s ON c.id_status_pipa = s.id_status_pipa
                LEFT JOIN kondisi_pipa k ON c.id_kondisi_pipa = k.id_kondisi_pipa
                ORDER BY c.id;
            ";

            await using var conn = new NpgsqlConnection(connectionString);
            var data = await conn.QueryAsync<PipaModel>(sql);
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