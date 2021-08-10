using System;
using System.Collections.Generic;
using RPGShop.Entities;
using MongoDB.Driver;
using MongoDB.Bson;

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
        public ShopItem GetItem(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            return shopItemsCollection.Find(filter).SingleOrDefault();
        }
        public IEnumerable<ShopItem> GetItemByType(string type)
        {
            var filter = filterBuilder.Eq(item => item.Type, type);
            return shopItemsCollection.Find(filter).ToList();
        }
        public IEnumerable<ShopItem> GetItemRarity(string rarity)
        {
            var filter = filterBuilder.Eq(item => item.Rarity, rarity);
            return shopItemsCollection.Find(filter).ToList();
        }
        public IEnumerable<ShopItem> GetItems()
        {
            return shopItemsCollection.Find(new BsonDocument()).ToList();
        }
        public void CreateShopItem(ShopItem item)
        {
            shopItemsCollection.InsertOne(item);
        }
        public void UpdateShopItem(ShopItem item)
        {
            var filter = filterBuilder.Eq(i => i.Id, item.Id);
            shopItemsCollection.ReplaceOne(filter, item);
        }
        public void DeleteShopItem(Guid id)
        {
            var filter = filterBuilder.Eq(i => i.Id, id);
            shopItemsCollection.DeleteOne(filter);
        }
    }
}