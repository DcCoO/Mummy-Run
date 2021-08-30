using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallSpark : MonoBehaviour
{
    [SerializeField] float maxTimeToFall;
    Vector3 originalPos;
    Transform tf;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        tf = transform;
        originalPos = tf.position;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Fall());
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        transform.position = originalPos;
        StartCoroutine(Fall());
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(Random.value * maxTimeToFall);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
    }

}
