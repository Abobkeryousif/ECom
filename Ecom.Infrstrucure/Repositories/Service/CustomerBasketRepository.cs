//using Ecom.Core.Entities;
//using Ecom.Core.Interface;
//using StackExchange.Redis;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;

//namespace Ecom.Infrstrucure.Repositories.Service
//{
//    public class CustomerBasketRepository : ICustomerBasketRepsitory
//    {
//        private readonly IDatabase _database;
//        public CustomerBasketRepository(IConnectionMultiplexer redis)
//        {
//            _database = redis.GetDatabase();
//        }
//        public async Task<bool> DeleteBaskeAsync(string Id)
//        {
//            return await _database.KeyDeleteAsync(Id);
//        }

//        public async Task<CustomerBasket> GetBasketAsync(string Id)
//        {
//            var result = await _database.StringGetAsync(Id);
//            if (!string.IsNullOrEmpty(result)) 
//            {
//                return JsonSerializer.Deserialize<CustomerBasket>(result);
//            }
//            return null;
//        }

//        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket customerBasket)
//        {
//            var _basket = await _database.StringSetAsync(customerBasket.Id ,JsonSerializer.Serialize(customerBasket),TimeSpan.FromDays(3));

//            if (_basket) 
//            {
//                return await GetBasketAsync(customerBasket.Id);
//            }
//            return null;
//        }
//    }
//}
