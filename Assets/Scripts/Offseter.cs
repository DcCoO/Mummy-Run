using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offseter : MonoBehaviour
{
    [SerializeField] bool above, below, ahead, behind;
    [SerializeField] float aboveDist, belowDist, aheadDist, behindDist;
    [SerializeField] Transform player1, player2;
    Transform tf;
    void Start()
    {
        tf = transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = tf.position;
        if (above)
        {
            if (player1.position.y > player2.position.y)
            {
                position = player1.position;
                position.y += aboveDist;
            }
            else
            {
                position = player2.position;
                position.y += aboveDist;
            }
        }
        else if (below)
        {
            if (player1.position.y < player2.position.y)
            {
                position = player1.position;
                position.y -= belowDist;
            }
            else
            {
                position = player2.position;
                position.y -= belowDist;
            }
        }
        else if (ahead)
        {
            if (player1.position.x > player2.position.x)
            {
                position = player1.position;
                position.x += aheadDist;
            }
            else
            {
                position = player2.position;
                position.x += aheadDist;
            }
        }
        else if (behind)
        {
            if (player1.position.x < player2.position.x)
            {
                position = player1.position;
                position.x -= behindDist;
            }
            else
            {
                position = player2.position;
                position.x -= behindDist;
            }
        }

        tf.position = position;
    }
}
