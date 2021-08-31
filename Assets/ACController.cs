using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using System.Linq;

public class ACController : MonoBehaviour
{
    static List<int> ids = new List<int>();
    [SerializeField] Player player1, player2;

    bool startedGame = false;

    int p1id = -123, p2id = -93;
    bool jump1, jump2;
    float dir1, dir2;

    void Start()
    {
        AirConsole.instance.onMessage += OnMessage;
    }

    void OnMessage(int from, JToken data)
    {
        if(p1id < 0)
        {
            p1id = AirConsole.instance.GetControllerDeviceIds().Min();
            p2id = AirConsole.instance.GetControllerDeviceIds().Max();
        }
        if (!startedGame)
        {
            if (Time.timeSinceLevelLoad < 1.5f) return; 
            if (data["pular"] != null) Hud.instance.StartGame();
            startedGame = true;
            return;
        }
        if (EndGame.instance.waitingInput)
        {
            if (data["pular"] != null) EndGame.instance.Restart();
            return;
        }


        if (from == p1id)
        {
            if (data["x"] != null) dir1 = (float)data["x"];
            if (data["pular"] != null) jump1 = (bool)data["pular"];
            player1.FeedACInput(jump1, dir1);
        }
        else
        {
            if (data["x"] != null) dir2 = (float)data["x"];
            if (data["pular"] != null) jump2 = (bool)data["pular"];
            player2.FeedACInput(jump2, dir2);
        }
    }
}
