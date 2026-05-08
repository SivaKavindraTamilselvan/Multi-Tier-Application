using NotificationAppDataAccessLibrary.Interfaces;
namespace NotificationAppDataAccessLibrary.Repositories;

public abstract class AbstractRepository<K,T> : IRepository<K,T> where T : class where K : notnull
{
    protected Dictionary<K,T> items = new();
    public abstract T Create(T item);

    public T? Get(K key)
    {
        return items.Where(x=>x.Key.Equals(key)).Select(x=>x.Value).FirstOrDefault();
    }

    public List<T> GetAll()
    {
        return items.Select(x=>x.Value).ToList();
    }

    public T? Update(K key,T item)
    {
        if(!items.Any(x => x.Key.Equals(key)))
        {
            return null;
        }

        items[key] = item;
        return item;
    }

    public T? Delete(K key)
    {
        if(items.TryGetValue(key, out T? item))
        {
            items.Remove(key);
            return item;
        }
        return null;
    }
} 