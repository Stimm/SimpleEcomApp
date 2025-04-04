using Amazon.DynamoDBv2.DataModel;

namespace SimpleEcom.DataModels
{
    [DynamoDBTable("Product")]
    public class Product
    {
        [DynamoDBHashKey("ProductId")]
        public string? ProductId { get; set; }
    }
}
