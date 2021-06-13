using UnityEngine;

public static class GameObjectExtensions
{
    public static bool HasComponent<T> (this GameObject gameObject)
    {
        return gameObject.TryGetComponent<T>(out T component);
    }

    public static bool HasComponent<T>(this GameObject gameObject, out T component)
    {
        return gameObject.TryGetComponent<T>(out component);
    }
}