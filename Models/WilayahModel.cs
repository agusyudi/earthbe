namespace GisApi.Models;

public class WilayahModel
{
    public int? IdWilayah { get; set; }
    public string? Provinsi { get; set; }
    public string? KabKota { get; set; }
    public string? OffTaker { get; set; }
    public double? Debit { get; set; }
    public string? Color { get; set; }
    public object? Geometry { get; set; }
}