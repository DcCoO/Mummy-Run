using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFire : MonoBehaviour
{

    [SerializeField] Vector2 initialPosition, finalPosition;

    FireState state = FireState.BAIXO;
    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        time = Random.value * 2;
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;

        if(time > 2)
        {
            if (state == FireState.BAIXO) state = FireState.SUBINDO;            
            else if (state == FireState.ALTO) state = FireState.DESCENDO;            
        }

        if (state == FireState.SUBINDO)
        {
            transform.position += Vector3.up * Time.deltaTime;
            if (Vector2.Distance(transform.position, finalPosition) < 0.05f)
            {
                transform.position = finalPosition;
                state = FireState.ALTO;
                time = 0;
            }
        }
        if (state == FireState.DESCENDO)
        {
            transform.position += Vector3.down * Time.deltaTime;
            if (Vector2.Distance(transform.position, initialPosition) < 0.05f)
            {
                transform.position = initialPosition;
                state = FireState.BAIXO;
                time = 0;
            }
        }
    }
}

public enum FireState
{
    SUBINDO, ALTO, DESCENDO, BAIXO
}
