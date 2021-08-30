using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    bool opened;

    public void Open()
    {
        opened = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(opened)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
