using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vortex : MonoBehaviour
{
    [SerializeField] Transform teleportPosition;
    public void SetTeleportPosition(Transform newTeleportPosition) => teleportPosition = newTeleportPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.position = teleportPosition.position;
    }
}
