namespace GisApi.Models;

public class PipaModel
{
    public int Id { get; set; }
    public string? Kode { get; set; }
    public int? IdUkuranPipa { get; set; }
    public string? UkuranPipa { get; set; }
    public int? IdJenisPipa { get; set; }
    public string? JenisPipa { get; set; }
    public int? ThnBuat { get; set; }
    public DateTime? TanggalPemasangan { get; set; }
    public DateTime? TanggalPerawatan { get; set; }
    public double? Elevasi { get; set; }
    public int? IdStatusPipa { get; set; }
    public string? StatusPipa { get; set; }
    public int? IdKondisiPipa { get; set; }
    public string? KondisiPipa { get; set; }
    public decimal? Panjang { get; set; }
    public decimal? Keterangan { get; set; }
    public string? Color { get; set; }
    public decimal? Ketebalan { get; set; }
    public object? Geometry { get; set; }
}