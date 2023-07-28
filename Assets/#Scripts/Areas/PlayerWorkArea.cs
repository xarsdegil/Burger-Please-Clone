using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWorkArea : MonoBehaviour
{
    float _ctr = 0f;
    [SerializeField] float _waitTime = 1f;

    private void OnTriggerStay(Collider other)
    {
        if (!GameManager.instance._isGameStarted) return;
        if (other.CompareTag("Player"))
        {
            if (!PlayerCarryController.instance.CanGive() || !CashierController.instance.CanCarry())
            {
                _ctr = 0f;
                return;
            }
            _ctr += Time.deltaTime;
            if (_ctr >= _waitTime)
            {
                PlayerCarryController.instance.RemoveBurger();
                CashierController.instance.AddBurger();
                _ctr = 0f;
            }
        }
    }
}
