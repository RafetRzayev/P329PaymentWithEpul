using Newtonsoft.Json;

namespace P329PaymentWithEpul.Models
{
    public class EpulTransactionModel
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        [JsonProperty("forwardUrl")]
        public string ForwardUrl { get; set; }

        [JsonProperty("maskedPan")]
        public object MaskedPan { get; set; }

        [JsonProperty("extendedCode")]
        public object ExtendedCode { get; set; }

        [JsonProperty("extendedCodeDescription")]
        public object ExtendedCodeDescription { get; set; }

        [JsonProperty("resultCode")]
        public object ResultCode { get; set; }

        [JsonProperty("resultDescription")]
        public object ResultDescription { get; set; }

        [JsonProperty("final")]
        public bool Final { get; set; }
    }
}
