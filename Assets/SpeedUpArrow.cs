using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpArrow : MonoBehaviour
{
    public bool on;
    [HideInInspector] public float offset;
    SpriteRenderer sr;
    Color c1 = Color.white;
    Color c2 = Color.green;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            sr.color = Color.Lerp(c1, c2, (Time.time + offset) % 1f);
        }
    }
}
