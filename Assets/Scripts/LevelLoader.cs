using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Ball ball;

    [SerializeField] private Transform dynamicLevelRoot;

    [SerializeField] private GameObject finishPrefab;
    [SerializeField] private GameObject pullerPrefab;
    [SerializeField] private GameObject repulserPrefab;
    [SerializeField] private GameObject spikePrefab;
    [SerializeField] private GameObject wallPrefab;

    public void Load(LevelData data)
    {
        // Reuse: ball + finish just move
        ball.ResetTo(data.ballStartPosition, data.ballInitialVelocity);

        // Clear previous level
        for (int i = dynamicLevelRoot.childCount - 1; i >= 0; i--)
            Destroy(dynamicLevelRoot.GetChild(i).gameObject);

        // Finish
        GameObject finish = Instantiate(finishPrefab, data.finishPosition, Quaternion.identity, dynamicLevelRoot);
        finish.transform.localScale = data.finishLocalScale;

        // Attractors
        foreach (var a in data.attractors)
        {
            var prefab = a.type == AttractorType.Puller ? (Attractor)pullerPrefab : repulserPrefab;
            var inst = Instantiate(prefab, a.position, Quaternion.identity, levelRoot);
            inst.Configure(a.force, a.range);
        }

        // Hazards + walls similar...
    }
}