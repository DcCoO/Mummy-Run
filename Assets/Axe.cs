using UnityEngine;

public class Axe : MonoBehaviour
{
    [SerializeField] float maxAngle;
    [SerializeField] float speed;
    Transform tf;

    void Start()
    {
        tf = transform;
    }

    // Update is called once per frame
    void Update()
    {
        float angle = maxAngle * Mathf.Sin(Time.time * speed);
        tf.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
