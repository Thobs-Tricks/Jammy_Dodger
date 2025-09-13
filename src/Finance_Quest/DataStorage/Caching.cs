using MonkeyCache.FileStore;

namespace Finance_Quest.DataStorage
{
	public static class Caching
	{
		public static T GetCache<T>(string key)
		{
			return Barrel.Current.Get<T>(key);
		}

		public static void SetCache<T>(string key, T data)
		{
			Barrel.Current.Add<T>(key, data, TimeSpan.FromDays(366));
		}

		public static void RemoveCache(string key)
		{
			Barrel.Current.Empty(key);
		}

		public static void ClearCache()
		{
			Barrel.Current.EmptyAll();
		}
	}
}
