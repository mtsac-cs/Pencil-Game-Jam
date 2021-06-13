using System;

public static class ArrayExtensions
{
    public static int IndexOf<T> (this T[] array, T element)
    {
        return Array.IndexOf(array, element);
    }
}