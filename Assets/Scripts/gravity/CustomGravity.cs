using System;
using System.Collections.Generic;
using UnityEngine;

public static class CustomGravity
{
    private static readonly List<GravitySource> sources = new List<GravitySource>();

    public static Vector2 GetGravity(Vector2 position)
    {
        Vector2 g = Vector2.zero;

        for (int i = 0; i < sources.Count; i++)
        {
            var source = sources[i];
            g += source.GetGravity(position);
        }

        return g;
    }


    //      --- Source registry --- 
    public static void Register(GravitySource source)
    {
        Debug.Assert(!sources.Contains(source), $"Duplicate registration of gravity source: {source.name}", source);
        sources.Add(source);
    }

    public static void Unregister(GravitySource source)
    {
        Debug.Assert(sources.Contains(source), $"Unregistration of unknown gravity source: {source.name}", source);
        sources.Remove(source);
    }
}
