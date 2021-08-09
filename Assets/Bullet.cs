using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    bool isRight;
    [SerializeField] float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 10);
    }

    void Update() => rb.velocity = (isRight ? Vector3.right : Vector3.left) * speed;   

    public void SetDirection(bool isRight) => this.isRight = isRight;
    
}
