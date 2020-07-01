using System;
using System.Threading.Tasks;
using ExchangeChallenge.Data.Tax.Models;
using ExchangeChallenge.Domain.Interfaces;
using MongoDB.Driver;

namespace ExchangeChallenge.Data.Tax
{
    public class TaxRepository : ITaxRepository
    {
        private readonly ICategoryConfigurations _categoryConfigurations;
        private readonly IMongoDatabase _mongoDatabase;

        public TaxRepository(ICategoryConfigurations categoryConfigurations)
        {
            _categoryConfigurations = categoryConfigurations;
            var client = new MongoClient(_categoryConfigurations.ConnectionString);
            _mongoDatabase = client.GetDatabase(_categoryConfigurations.Database);
        }

        public async Task<decimal> GetTax(string category)
        {
            var categoryModel = await _mongoDatabase.GetCollection<CategoryModel>(_categoryConfigurations.Collection)
                .Find(c => c.Category.Equals(category)).FirstOrDefaultAsync();

            if (categoryModel == null)
                throw new Exception("Categoria não encontrada");

            return categoryModel.Tax;
        }
    }
}
