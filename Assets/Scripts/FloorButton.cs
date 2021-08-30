using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : MonoBehaviour
{
    [SerializeField] SpeedUp su;
    [SerializeField] SpeedUpArrow[] sus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Press());
    }

    IEnumerator Press()
    {
        Transform t = transform;
        Vector3 origin = t.position;

        for(float f = 0; f < 1; f += Time.deltaTime * 1.4f)
        {
            t.position = Vector3.Lerp(origin, origin + Vector3.down, f);
            yield return null;
        }

        su.on = true;
        for (int i = 0; i < sus.Length; ++i)
        {
            sus[i].on = true;
            sus[i].offset = 0.2f * (sus.Length - i);
        }
    }
}
