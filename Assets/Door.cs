using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Vector3 closedPosition, openedPosition;
    [SerializeField] bool autoclose;
    [SerializeField] float closeSpeed;

    Transform tf;
    float lastOpenTime = 0;
    void Start()
    {
        tf = transform;
        tf.position = closedPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (autoclose && lastOpenTime > 0.2f)
        {
            tf.position += (closedPosition - tf.position).normalized * closeSpeed * Time.deltaTime;
        }
        lastOpenTime += Time.deltaTime;
    }

    public void Open()
    {
        lastOpenTime = 0;
        tf.position += (openedPosition - tf.position).normalized * closeSpeed * Time.deltaTime;
    }

    
}
