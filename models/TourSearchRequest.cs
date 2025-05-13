using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class TourSearchRequest
{
    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("fromDate")]
    public string? FromDate { get; set; }

    [JsonPropertyName("toDate")]
    public string? ToDate { get; set; }

    [JsonPropertyName("adults")]
    public int Adults { get; set; } = 1;

    [JsonPropertyName("rooms")]
    public int Rooms { get; set; } = 1;
}
