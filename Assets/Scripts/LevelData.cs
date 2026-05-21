using System.Collections.Generic;
using UnityEngine;

// One asset per level. Right-click in Project window → Create → Game → Level Data
[CreateAssetMenu(fileName = "Level_", menuName = "Game/Level Data")]
public class LevelData : ScriptableObject
{
    [Header("Metadata")]
    public int levelNumber;
    public string displayName;

    [Header("Ball")]
    public Vector2 ballStartPosition;
    public Vector2 ballInitialVelocity; // (0,0) for "starts still"

    [Header("Finish")]
    public Vector2 finishPosition;
    public Vector2 finishLocalScale;
    public float finishRadius = 0.5f;

    [Header("Attractors")]
    public List<AttractorPlacement> attractors = new();

    [Header("Hazards")]
    public List<HazardPlacement> hazards = new();

    [Header("Walls (bouncy)")]
    public List<WallPlacement> walls = new();
}

public enum AttractorType { Puller, Repulser }
public enum HazardType { Spike }

[System.Serializable]
public class AttractorPlacement
{
    public AttractorType type;
    public Vector2 position;
    public float force = 10f;
    public float range = 3f;
}

[System.Serializable]
public class HazardPlacement
{
    public HazardType type;
    public Vector2 position;
    public float rotation; // degrees
}

[System.Serializable]
public class WallPlacement
{
    public Vector2 position;
    public Vector2 size = new Vector2(1f, 0.2f);
    public float rotation;
}