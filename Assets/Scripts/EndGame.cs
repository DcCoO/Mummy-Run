using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public static EndGame instance;
    public Image player;
    public Image win;
    public Sprite P1, P2;
    public Image finishedImage;

    private void Awake()
    {
        instance = this;
    }
    

    public void Finish(bool p1win)
    {
        player.sprite = p1win ? P1 : P2;
        player.enabled = true;
        win.enabled = true;
        PlayerController.instance.StopGame();
        finishedImage.enabled = true;
    }

    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
