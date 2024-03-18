using System.Text.Json.Serialization;

namespace ChartjsExercise.Model
{
    public class DataItem
    {
        /// <summary>
        /// Gets or sets the group.
        /// </summary>
        /// <value>
        /// The group.
        /// </value>
        [JsonPropertyName("group")]
        public string? Group { get; set; }

        /// <summary>
        /// Gets or sets the name of the attribute
        /// </summary>
        /// <value>
        /// The name of the attribute
        /// </value>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value
        /// </value>
        [JsonPropertyName("value")]
        public decimal? Value { get; set; }
    }
}
