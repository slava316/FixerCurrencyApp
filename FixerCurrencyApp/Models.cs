using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FixerCurrencyApp
{
    public class FixerResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }

        [JsonPropertyName("base")]
        public string Base { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("rates")]
        public Dictionary<string, double> Rates { get; set; }

        [JsonPropertyName("error")]
        public FixerError Error { get; set; }
    }

    public class FixerError
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("info")]
        public string Info { get; set; }
    }
}