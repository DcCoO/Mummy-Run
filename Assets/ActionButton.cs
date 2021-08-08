using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionButton : MonoBehaviour
{
    [SerializeField] UnityEvent events;

    private void OnTriggerStay2D(Collider2D collision)
    {
        events?.Invoke();
    }
}
