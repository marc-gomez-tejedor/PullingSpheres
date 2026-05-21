
using System;
using UnityEngine;

public class Puller : GravitySource
{
    [SerializeField, Range(0f, 20f)]
    float fallOffRadius = 10f;
    public override Vector2 GetGravity(Vector2 position)
    {
        Vector2 selfPos2D = transform.position;
        Vector2 direction = selfPos2D - position;
        float distance = direction.magnitude;
        if (distance < fallOffRadius)
        {
            return direction.normalized * base.scale;
        }
        return Vector2.zero;
    }

    // gizmos
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, fallOffRadius);
    }
}
