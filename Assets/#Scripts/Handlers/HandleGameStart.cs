using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleGameStart : MonoBehaviour
{
    private void OnEnable()
    {
        StoveController.instance._canMake = true;
    }
}
