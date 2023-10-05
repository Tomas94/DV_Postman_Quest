using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.lastCheckpoint = transform.position;
        }
    }
}