using UnityEngine;

public interface IPoolable<T> where T : Component, IPoolable<T>
{
    void SetPool(ComponentPool<T> pool);
    void ReturnToPool();
}