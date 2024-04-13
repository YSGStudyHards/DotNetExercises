using ZiggyCreatures.Caching.Fusion;

namespace FusionCacheExercise
{
    public class FusionCacheService
    {
        private readonly IFusionCache _cache;

        public FusionCacheService(IFusionCache cache)
        {
            _cache = cache;
        }

        public async Task<PersonInfo> GetValueAsync(string key)
        {
            var cachedValue = await _cache.GetOrDefaultAsync<PersonInfo>(key).ConfigureAwait(false);
            if (cachedValue != null)
            {
                cachedValue.CacheMsg = "缓存中的值";
                return cachedValue;
            }
            else
            {
                //从数据库或其他数据源获取值
                var value = GetValueFromDataSource(key);
                //将值存入缓存，设置过期时间等
                await _cache.SetAsync(key, value, TimeSpan.FromMinutes(10)).ConfigureAwait(false);
                return value;
            }
        }

        private PersonInfo GetValueFromDataSource(string key)
        {
            var personInfo = new PersonInfo
            {
                UserName = "追逐时光者",
                Age = 18,
                Nationality = "中国",
                CacheMsg = "默认值"
            };
            return personInfo;
        }
    }
}
