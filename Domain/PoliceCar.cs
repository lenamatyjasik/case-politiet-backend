using System.Text.Json.Serialization;

namespace Domain
{
    public class PoliceCar
    {
        public int Id { get; set; }
        [JsonPropertyName("merke")]
        public string Brand { get; set; } = "";
        [JsonPropertyName("modell")]
        public string Model { get; set; } = "";
        [JsonPropertyName("årsmodell")]
        public int ModelYear { get; set; }
        [JsonPropertyName("regNr")]
        public string RegistrationNumber { get; set; } = "";
        [JsonPropertyName("status")]
        public string Status { get; set; } = "";
        [JsonPropertyName("oppdrag")]
        public string Mission { get; set; } = "";
    }
}