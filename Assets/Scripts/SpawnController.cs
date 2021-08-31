using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    public static SpawnController instance;

    public GameObject[] obstacles;

    public GameObject wall;

    [SerializeField] Transform levelParent;
    Vector2 pos;
    private void Awake()
    {
        instance = this;
    }

    public void StartGame()
    {

        pos = Vector2.zero;

        GameObject g0 = Instantiate(obstacles[0], pos, Quaternion.identity, levelParent);
        pos = g0.GetComponent<Obstacle>().GetEndPosition();

        for (int i = 0; i < 3; i++)
        {
            GameObject g = Instantiate(obstacles[Random.Range(1, obstacles.Length)], pos, Quaternion.identity, levelParent);
            pos = g.GetComponent<Obstacle>().GetEndPosition();
        }
    }

    public void Spawn()
    {
        GameObject g = Instantiate(obstacles[Random.Range(1, obstacles.Length)], pos, Quaternion.identity, levelParent);
        pos = g.GetComponent<Obstacle>().GetEndPosition();
    }
}
