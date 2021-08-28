using System.Collections;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] srs;
    [SerializeField] float timeOn, timeOff;
    void Start()
    {
        StartCoroutine(DisappearRoutine());
    }

    IEnumerator DisappearRoutine()
    {
        bool on = false;
        for (int i = 0; i < srs.Length; ++i) srs[i].enabled = true;
        while (true)
        {
            for (int i = 0; i < srs.Length; ++i) srs[i].enabled = on;
            yield return new WaitForSeconds(on ? timeOn : timeOff);
            on = !on;
        }
    }
}
