using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject[] obstacles;
    [SerializeField] Transform levelParent;
    void Start()
    {

        Vector2 pos = Vector2.zero;

        GameObject g0 = Instantiate(obstacles[0], pos, Quaternion.identity, levelParent);
        pos = g0.GetComponent<Obstacle>().GetEndPosition();

        for (int i = 0; i < 10; i++)
        {
            GameObject g = Instantiate(obstacles[Random.Range(1, obstacles.Length)], pos, Quaternion.identity, levelParent);
            pos = g.GetComponent<Obstacle>().GetEndPosition();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
