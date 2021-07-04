using Newtonsoft.Json;
using Pati.Infrastructure;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pati.RedisUtils
{
    public class RedisJsonCacheService : ICacheService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public RedisJsonCacheService(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        public void SetString(string key, string value, TimeSpan? expiration = null)
        {
            var db = _connectionMultiplexer.GetDatabase();
            db.StringSet(key, value, expiration);
        }

        public string GetString(string key)
        {
            var db = _connectionMultiplexer.GetDatabase();
            return db.StringGet(key);
        }

        public void SetValue<T>(string key, T value, TimeSpan? expiration = null)
        {
            var db = _connectionMultiplexer.GetDatabase();
            var jsonValue = JsonConvert.SerializeObject(value);
            db.StringSet(key, jsonValue, expiration);
        }

        public T GetValue<T>(string key)
        {
            var db = _connectionMultiplexer.GetDatabase();
            string jsonStr = db.StringGet(key);
            return JsonConvert.DeserializeObject<T>(jsonStr);
        }

        public List<T> GetValues<T>(string[] keys)
        {
            var db = _connectionMultiplexer.GetDatabase();

            var redisKeys = new List<RedisKey>();

            foreach (var key in keys)
            {
                var redisKey = new RedisKey(key);
                redisKeys.Add(redisKey);
            }

            var redisValues = db.StringGet(redisKeys.ToArray());
            var resultList = new List<T>();

            foreach (var redisValue in redisValues)
            {
                if (!redisValue.HasValue)
                {
                    continue;
                }

                var value = JsonConvert.DeserializeObject<T>(redisValue);
                resultList.Add(value);
            }

            return resultList;
        }

        public async Task SetStringAsync(string key, string value, TimeSpan? expiration = null)
        {
            var db = _connectionMultiplexer.GetDatabase();
            await db.StringSetAsync(key, value, expiration);
        }

        public async Task<string> GetStringAsync(string key)
        {
            var db = _connectionMultiplexer.GetDatabase();
            return await db.StringGetAsync(key);
        }

        public async Task SetValueAsync<T>(string key, T value, TimeSpan? expiration = null)
        {
            var db = _connectionMultiplexer.GetDatabase();
            var jsonValue = JsonConvert.SerializeObject(value);
            await db.StringSetAsync(key, jsonValue, expiration);
        }

        public async Task<T> GetValueAsync<T>(string key)
        {
            var db = _connectionMultiplexer.GetDatabase();
            string jsonStr = await db.StringGetAsync(key);
            return JsonConvert.DeserializeObject<T>(jsonStr);
        }

        public async Task<List<T>> GetValuesAsync<T>(string[] keys)
        {
            var db = _connectionMultiplexer.GetDatabase();

            var redisKeys = new List<RedisKey>();

            foreach (var key in keys)
            {
                var redisKey = new RedisKey(key);
                redisKeys.Add(redisKey);
            }

            var redisValues = await db.StringGetAsync(redisKeys.ToArray());
            var resultList = new List<T>();

            foreach (var redisValue in redisValues)
            {
                if (!redisValue.HasValue)
                {
                    continue;
                }

                var value = JsonConvert.DeserializeObject<T>(redisValue);
                resultList.Add(value);
            }

            return resultList;
        }
    }
}
