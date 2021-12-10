using System.Collections.Generic;
using UnityEngine;

public class ComponentPool<T> where T : Component, IPoolable<T>
{
    readonly T _prefab;
    readonly Transform _parent;
    Queue<T> _queue;

    public ComponentPool(T prefab, int initialCapacity, Transform parent)
    {
        _prefab = prefab;
        _parent = parent;

        _queue = new Queue<T>( initialCapacity );
        for (int i = 0; i < initialCapacity; i++)
        {
            T spawned = CreateNewInstance();
            spawned.gameObject.SetActive( false );
            _queue.Enqueue( spawned );
        }
    }

    private T CreateNewInstance()
    {
        T obj = Object.Instantiate( _prefab, _parent );
        obj.SetPool( this );
        return obj;
    }

    public virtual T GetFromPool()
    {
        if (_queue.Count >= 1)
        {
            T thing = _queue.Dequeue();
            thing.gameObject.SetActive( true );
            return thing;
        }
        return CreateNewInstance();
    }

    public void ReturnToPool(T obj)
    {
        obj.gameObject.SetActive( false );
        _queue.Enqueue( obj );
    }
}