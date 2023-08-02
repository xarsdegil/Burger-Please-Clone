using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookBurgersArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!GameManager.instance._isGameStarted) return;
        if (other.CompareTag("Player"))
        {
            StoveController.instance._canMake = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!GameManager.instance._isGameStarted) return;
        if (other.CompareTag("Player"))
        {
            StoveController.instance._canMake = false;
        }
    }
}
