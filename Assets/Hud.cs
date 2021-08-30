using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    [SerializeField] float maxDistance;
    [SerializeField] Text distanceText;
    [SerializeField] GameObject bar;
    [SerializeField] Image innerBar;
    [SerializeField] Image left, right;
    [SerializeField] Image counter;
    [SerializeField] Sprite[] i321go;
    [SerializeField] Sprite P1, P2;
    [SerializeField] Transform player1, player2;
    [SerializeField] Gradient colorGradient;
    [SerializeField] GameObject players;

    bool isPlaying = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlaying) return;

        if(player1.position.x > player2.position.x)
        {
            right.sprite = P1;
            left.sprite = P2;
            float distance = player1.position.x - player2.position.x;
            distanceText.text = $"{(int)distance}m";
            innerBar.fillAmount = Mathf.Min(1, distance / maxDistance);
            innerBar.color = colorGradient.Evaluate(innerBar.fillAmount);

            if(distance > maxDistance)
            {
                EndGame.instance.Finish(true);
            }
        }
        else
        {
            right.sprite = P2;
            left.sprite = P1;
            float distance = player2.position.x - player1.position.x;
            distanceText.text = $"{(int)distance}m";
            innerBar.fillAmount = Mathf.Min(1, distance / maxDistance);
            innerBar.color = colorGradient.Evaluate(innerBar.fillAmount);

            if (distance > maxDistance)
            {
                EndGame.instance.Finish(false);
            }
        }
    }

    public void StartGame()
    {
        StartCoroutine(StartGameRoutine());
    }

    IEnumerator StartGameRoutine()
    {
        counter.sprite = i321go[0];
        counter.enabled = true;
        yield return new WaitForSeconds(1);
        counter.sprite = i321go[1];
        yield return new WaitForSeconds(1);
        counter.sprite = i321go[2];
        yield return new WaitForSeconds(1);
        counter.sprite = i321go[3];

        players.SetActive(true);
        
        PlayerController.instance.StartGame();
        bar.SetActive(true);
        left.enabled = right.enabled = true;
        SpawnController.instance.StartGame();

        yield return new WaitForSeconds(1);
        counter.enabled = false;
    }
}
