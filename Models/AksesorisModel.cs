namespace GisApi.Models;

public class AksesorisModel
{
    public int Id { get; set; }
    public string? Kode { get; set; }
    public string? Nama { get; set; }
    public int? IdJenisAksesoris { get; set; }
    public string? JenisAksesoris { get; set; }
    public int? IdDiameterAksesoris { get; set; }
    public string? DiameterAksesoris { get; set; }
    public int? IdSpam { get; set; }
    public string? NamaSpam { get; set; }
    public int? IdOfftaker { get; set; }
    public string? NamaOfftaker { get; set; }
    public string? Keterangan { get; set; }
    public string? Color { get; set; }
    public string? Icon { get; set; }
    public int Warning { get; set; } = 0;
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public double? Frequency { get; set; }
    public int? Voltage { get; set; }
    public double? Current { get; set; }
    public int? Speed { get; set; }
    public double? Power { get; set; }
    public double? Igbt_temp { get; set; }
    public double? Flow_rate { get; set; }
    public double? Pressure { get; set; }
    public double? Totalizer { get; set; }
    public bool? Power_status { get; set; }
    public string? Pt_status { get; set; }
    public bool? Pressure_boost { get; set; }
    public double? Proportional { get; set; }
    public double? Integral { get; set; }
    public double? Set_point { get; set; }
    public bool? Is_over_pressure { get; set; }
    public bool? Is_under_pressure { get; set; }
    public double? Dead_band { get; set; }
    public double? Pt_current { get; set; }
    public double? Pt_voltage { get; set; }
    public double? Water_temp { get; set; }
    public double? Ph { get; set; }
    public double? Turbidity_value { get; set; }
    public double? Chlorine { get; set; }
    public double? Level { get; set; }
    public double? RunningCount { get; set; }
    public bool? IsForceStop { get; set; }
    public bool? IsBoosting { get; set; }
    public bool? IsUnderPressure { get; set; }
    public bool? IsOverPressure { get; set; }
    public bool? IsPressureTransmitterError { get; set; }
    public bool? IsWaterShortage { get; set; }
    public bool? IsAnalogInputError { get; set; }
    public bool? IsAnalogOutputFault { get; set; }
    public bool? IsDigitalOutputFault { get; set; }
}