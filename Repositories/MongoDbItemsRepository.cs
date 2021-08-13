using System;
using System.Collections.Generic;
using RPGShop.Entities;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace RPGShop.Repositories
{
    public class MongoDbItemsRepository : IItemsRepository
    {
        private const string databaseName = "shopitems";
        private const string collectionName = "items";
        private readonly IMongoCollection<ShopItem> shopItemsCollection;
        private readonly FilterDefinitionBuilder<ShopItem> filterBuilder = Builders<ShopItem>.Filter;
        public MongoDbItemsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase db = mongoClient.GetDatabase(databaseName);
            shopItemsCollection = db.GetCollection<ShopItem>(collectionName);
        }
        public Task<ShopItem> GetItemAsync(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            return shopItemsCollection.Find(filter).SingleOrDefaultAsync();
        }
        public async Task<IEnumerable<ShopItem>> GetItemByTypeAsync(string type)
        {
            var filter = filterBuilder.Eq(item => item.Type, type);
            return await shopItemsCollection.Find(filter).ToListAsync();
        }
        public async Task<IEnumerable<ShopItem>> GetItemRarityAsync(string rarity)
        {
            var filter = filterBuilder.Eq(item => item.Rarity, rarity);
            return await shopItemsCollection.Find(filter).ToListAsync();
        }
        public async Task<IEnumerable<ShopItem>> GetItemsAsync()
        {
            return await shopItemsCollection.Find(new BsonDocument()).ToListAsync();
        }
        public async Task CreateShopItemAsync(ShopItem item)
        {
            await shopItemsCollection.InsertOneAsync(item);
        }
        public async Task UpdateShopItemAsync(ShopItem item)
        {
            var filter = filterBuilder.Eq(i => i.Id, item.Id);
            await shopItemsCollection.ReplaceOneAsync(filter, item);
        }
        public async Task DeleteShopItemAsync(Guid id)
        {
            var filter = filterBuilder.Eq(i => i.Id, id);
            await shopItemsCollection.DeleteOneAsync(filter);
        }
    }
}