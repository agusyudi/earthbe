using Dapper;
using GisApi.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace GisApi.Controllers
{
    [Route("api/aksesoris")]
    [ApiController]
    public class AksesorisController(IConfiguration config) : ControllerBase
    {
        private readonly string? connectionString = config.GetConnectionString("PostgresConnection");

        [HttpGet()]
        public async Task<IActionResult> Get(int? idjenisaksesoris = null)
        {
            var where = "";

            if (idjenisaksesoris.HasValue)
            {
                where = where + " AND c.id_jenis_aksesoris = " + idjenisaksesoris.Value;
            }

            string sql = $@"
                SELECT 
                    c.id,
                    c.kode,
                    c.nama,
                    c.id_jenis_aksesoris AS idjenisaksesoris,
                    j.jenis_aksesoris AS jenisaksesoris,
                    c.id_diameter_aksesoris AS iddiameteraksesoris,
                    d.diameter_aksesoris AS diameteraksesoris,
                    c.id_spam AS idspam,
                    s.nama_spam AS namaspam,
                    c.id_offtaker AS idofftaker,
                    o.nama_offtaker AS namaofftaker,
                    c.keterangan,
                    ST_Y(c.geom) AS Latitude,
                    ST_X(c.geom) AS Longitude,
                    c.icon,
                    c.color,
                    c.warning,
                    frequency,
                    voltage,
                    current,
                    speed,
                    power,
                    igbt_temp, 
                    flow_rate,
                    pressure, 
                    totalizer,
                    power_status, 
                    pt_status,
                    pressure_boost,
                    proportional,
                    integral, 
                    set_point,
                    is_over_pressure,
                    is_under_pressure,
                    dead_band, 
                    pt_current,
                    pt_voltage, 
                    water_temp, 
                    ph, 
                    turbidity_value,
                    chlorine, 
                    level,
                    RunningCount, 
                    IsForceStop,
                    IsBoosting, 
                    IsUnderPressure,
                    IsOverPressure,
                    IsPressureTransmitterError, 
                    IsWaterShortage, 
                    IsAnalogInputError,  
                    IsAnalogOutputFault,
                    IsDigitalOutputFault
                    
                FROM aksesoris c 
                LEFT JOIN jenis_aksesoris j ON c.id_jenis_aksesoris = j.id_jenis_aksesoris 
                LEFT JOIN diameter_aksesoris d ON c.id_diameter_aksesoris = d.id_diameter_aksesoris 
                LEFT JOIN spam s ON c.id_spam = s.id_spam 
                LEFT JOIN wilayah w ON c.id_wilayah = w.id_wilayah 
                LEFT JOIN offtaker o ON c.id_offtaker = o.id_offtaker 
                WHERE c.id IS NOT NULL {where}
                ORDER BY c.id;
            ";

            await using var conn = new NpgsqlConnection(connectionString);
            var data = await conn.QueryAsync<AksesorisModel>(sql);
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