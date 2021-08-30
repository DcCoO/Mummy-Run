using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingStone : MonoBehaviour
{
    [SerializeField] float leftX, rightX;
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;

    Transform tf;
    bool goingLeft = true;
    void Start()
    {
        tf = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (tf.localPosition.x <= leftX) goingLeft = false;
        else if (tf.localPosition.x >= rightX) goingLeft = true;

        tf.localPosition += Time.deltaTime * speed * (goingLeft ? Vector3.left : Vector3.right);

        tf.Rotate(0, 0, (goingLeft ? rotationSpeed : -rotationSpeed) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Player>().TakeDamage();
    }
}
