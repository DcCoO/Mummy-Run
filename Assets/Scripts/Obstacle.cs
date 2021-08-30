using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] int id;
    [SerializeField] Transform endPosition;

    public int GetID() => id;
    public Vector2 GetEndPosition() => endPosition.position;

    void Start()
    {
        StartCoroutine(WasPassed());
    }

    IEnumerator WasPassed()
    {
        yield return new WaitUntil(() => PlayerController.instance.GetMaxX() >= endPosition.position.x);
        SpawnController.instance.Spawn();

        yield return new WaitUntil(() => PlayerController.instance.GetMinX() >= endPosition.position.x + 2);
        Instantiate(SpawnController.instance.wall, transform).transform.position = endPosition.position;
    }
}
