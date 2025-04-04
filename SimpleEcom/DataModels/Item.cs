using Amazon.DynamoDBv2.DataModel;

namespace SimpleEcom.DataModels
{
    [DynamoDBTable("Items")]
    public class Item
    {
        [DynamoDBHashKey("ItemId")]
        public required string ItemId { get; set; }
        public required string Name { get; set; }
        public int Ammount { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public string? ImageLarge { get; set; }
        public string? ImageSmall { get; set; }

    }
}
