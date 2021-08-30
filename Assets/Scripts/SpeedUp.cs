using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{

    public bool on;
    public bool touching;
    [SerializeField] float force;
    List<Collider2D> colliders = new List<Collider2D>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (on && touching) 
            foreach(Collider2D collision in colliders)
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        touching = true;
        colliders.Add(collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        touching = false;
        colliders.Remove(collision);
    }
    
}
