using UnityEngine;

public class Axe : MonoBehaviour
{
    [SerializeField] float maxAngle;
    [SerializeField] float speed;
    Transform tf;
    float offset;

    void Start()
    {
        tf = transform;
        offset = Random.value * 10;
    }

    // Update is called once per frame
    void Update()
    {
        float angle = maxAngle * Mathf.Sin((offset + Time.time) * speed);
        tf.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
