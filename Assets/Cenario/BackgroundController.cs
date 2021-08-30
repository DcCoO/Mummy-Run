using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public MeshRenderer mr;
    public float divider = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = this.transform.parent.position.x;
        float y = this.transform.parent.position.y;
        

        mr.material.mainTextureOffset = new Vector2((x % divider)/4,(y % divider)/4);
        Debug.Log("x: "+ (x%divider));
        Debug.Log("y: " + (y % divider));


    }
}
