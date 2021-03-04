using System.Text.Json;
using System.Text.Json.Serialization;

namespace RazorPages.Models
{
    /// <summary>
    /// 모델 클래스 접미사 : Model, ViewModel, Dto, Object, Entity, ...
    /// </summary>
    public class Portfolio
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("img")]
        public string Image { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize<Portfolio>(this);
        }
    }
}
