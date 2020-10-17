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
