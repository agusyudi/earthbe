namespace GisApi.Models;

public class OfftakerModel
{
    public int? IdOfftaker { get; set; }
    public string? NamaOfftaker { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
}


public class OfftakerSummaryModel
{
    public int? IdOfftaker { get; set; }
    public string? NamaOfftaker { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public double? TotalizerBulanIni { get; set; }
    public int? CountOfftaker { get; set; }
    public double? PerkiraanTagihan { get; set; }
}