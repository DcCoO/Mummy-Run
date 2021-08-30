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
    bool acJump;
    float acDirection;

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
        print(AirConsole.instance.GetControllerDeviceIds().Count);
        if (data["x"] != null) acDirection = (float)data["x"];
        if (data["pular"] != null) acJump = (bool)data["pular"];

        if (from == p1id) player1.FeedACInput(acJump, acDirection);
        else player2.FeedACInput(acJump, acDirection);
    }
}
