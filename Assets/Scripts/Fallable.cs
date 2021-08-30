using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallable : MonoBehaviour
{
    Vector2 originalPos;
    [SerializeField] float timeToFall;
    [SerializeField] bool randomTime;
    void Start()
    {
        originalPos = transform.position;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("oi");
        StartCoroutine(Fall());
    }

    IEnumerator Fall()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if(randomTime) yield return new WaitForSeconds(Random.value * timeToFall);
        else yield return new WaitForSeconds(timeToFall);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        yield return new WaitForSeconds(3);
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        transform.position = originalPos;
    }
}
