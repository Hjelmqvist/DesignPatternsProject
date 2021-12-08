using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool<T> where T : MonoBehaviour
{
    T _prefab;
    Queue<T> _queue;

    public GameObjectPool(T prefab, int initialCapacity)
    {
        _prefab = prefab;
        WarmUp( initialCapacity );
    }

    private void WarmUp(int capacity)
    {
        _queue = new Queue<T>( capacity );

        for (int i = 0; i < capacity; i++)
        {
            T spawned = CreateNewObject();
            spawned.gameObject.SetActive( false );
            _queue.Enqueue( spawned );
        }   
    }

    private T CreateNewObject()
    {
        return Object.Instantiate( _prefab );
    }

    public virtual T GetFromPool()
    {
        if (_queue.Count >= 1)
        {
            T thing = _queue.Dequeue();
            thing.gameObject.SetActive( true );
            return thing;
        }
        return CreateNewObject();
    }

    public void ReturnToPool(T obj)
    {
        _queue.Enqueue( obj );
    }
}