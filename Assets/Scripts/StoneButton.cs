using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneButton : MonoBehaviour
{
    [SerializeField] GameObject stonePrefab;
    [SerializeField] Transform[] positions;

    [SerializeField] Vector2 beginPos, endPos;
    bool canPress = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canPress) StartCoroutine(PressRoutine());
    }

    IEnumerator PressRoutine()
    {
        canPress = false;
        for(int i = 0; i < positions.Length; ++i)
        {
            Instantiate(stonePrefab, positions[i].position, Quaternion.identity);
        }

        for(float t = 0; t < 1; t += Time.deltaTime * 4)
        {
            transform.localPosition = Vector2.Lerp(beginPos, endPos, t);
            yield return null;
        }
        for (float t = 0; t < 1; t += Time.deltaTime * 2)
        {
            transform.localPosition = Vector2.Lerp(endPos, beginPos, t);
            yield return null;
        }
        transform.localPosition = beginPos;
        canPress = true;
    }
}
