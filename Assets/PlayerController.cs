using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] Player player1, player2;
    [SerializeField] Vector3 p1pos, p2pos;
    void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        if (Random.value < 0.5f)
        {
            player1.transform.localPosition = p1pos;
            player2.transform.localPosition = p2pos;
        }
        else
        {
            player1.transform.localPosition = p2pos;
            player2.transform.localPosition = p1pos;
        }
        player1.allowInput = player2.allowInput = true;
    }

    public float GetMaxX() => Mathf.Max(player1.transform.position.x, player2.transform.position.x);

    public float GetMinX() => Mathf.Min(player1.transform.position.x, player2.transform.position.x);

    public void StopGame()
    {
        player1.allowInput = player2.allowInput = false;
    }
}
