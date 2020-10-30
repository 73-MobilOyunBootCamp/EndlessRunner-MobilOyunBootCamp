using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    public static void DestroyExtended(Object obj)
    {
        if (Application.isPlaying)
            Object.Destroy(obj);
        else Object.DestroyImmediate(obj);
    }

    public static T KeyByValue<T, W>(this Dictionary<T, W> dict, W val)
    {
        T key = default;
        foreach (KeyValuePair<T, W> pair in dict)
        {
            if (EqualityComparer<W>.Default.Equals(pair.Value, val))
            {
                key = pair.Key;
                break;
            }
        }
        return key;
    }

    public static bool IsNullOrDestroyed(object obj)
    {
        if (obj is IComponent)
            return (obj as IComponent).isDestroyed;
        else if (obj is Component)
            return (obj as Component) == null;
        else
            return obj == null;
    }
}


public static class IListExtensions
{
    /// <summary>
    /// Shuffles the element order of the specified list.
    /// </summary>
    public static void Shuffle<T>(this IList<T> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
}
