using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleGameStart : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.instance._isGameStarted = true;
        StoveController.instance._canMake = true;
    }
}
