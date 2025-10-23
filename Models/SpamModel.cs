namespace GisApi.Models;

public class SpamModel
{
    public int? IdSpam { get; set; }
    public string? NamaSpam { get; set; }
    public decimal? HargaM3 { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
}

public class SpamSummaryModel
{
    public int? IdSpam { get; set; }
    public string? NamaSpam { get; set; }
    public decimal? HargaM3 { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public double? TotalizerBulanIni { get; set; }
    public double? TotalizerMingguIni { get; set; }
    public double? Tekanan { get; set; }
}