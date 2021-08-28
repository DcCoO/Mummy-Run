using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] int id;
    [SerializeField] Transform endPosition;

    public int GetID() => id;
    public Vector2 GetEndPosition() => endPosition.position;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
