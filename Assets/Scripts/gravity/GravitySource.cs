using UnityEngine;

public class GravitySource : MonoBehaviour
{
    public float scale = 9.8f;

    public virtual Vector2 GetGravity(Vector2 position)
    {
        return Vector2.zero * scale;
    }
    void OnEnable()
    {
        CustomGravity.Register(this);
    }
    void OnDisable()
    {
        CustomGravity.Unregister(this);
    }
}
