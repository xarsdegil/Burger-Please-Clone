using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBurgerArea : MonoBehaviour
{
    float _ctr = 0f;
    [SerializeField] float _waitTime = 1f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StoveController.instance._canMake = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(!PlayerCarryController.instance.CanCarry() || !StoveController.instance.CanGive())
            {
                StoveController.instance._canMake = true;
                _ctr = 0f;
                return;
            }
            _ctr += Time.deltaTime;
            if (_ctr >= _waitTime)
            {
                PlayerCarryController.instance.AddBurger();
                StoveController.instance.GetBurger();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StoveController.instance._canMake = true;
        }
    }
}
