namespace SimpleEcom.Utilities;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using System.Threading.Tasks;

public class DynamoDBService
{
    private readonly AmazonDynamoDBClient _client;
    private readonly Table _table;

    public DynamoDBService(string tableName)
    {
        _client = new AmazonDynamoDBClient();
        _table = Table.LoadTable(_client, tableName);
    }

    public async Task<Document> GetItemAsync(string id)
    {
        return await _table.GetItemAsync(id);
    }

    public async Task PutItemAsync(Document document)
    {
        await _table.PutItemAsync(document);
    }

    // Add other methods (e.g., UpdateItemAsync, DeleteItemAsync)
}