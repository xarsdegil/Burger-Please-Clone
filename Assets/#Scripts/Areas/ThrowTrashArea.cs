using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowTrashArea : MonoBehaviour
{
    float _ctr;
    [SerializeField] float _timeToThrow = 1f;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if ((PlayerCarryController.instance.GetCurrentTrashCount() + PlayerCarryController.instance.GetCurrentBurgerCount()) == 0)
            {
                _ctr = 0f;
                return;
            }
            if (_ctr >= _timeToThrow)
            {
                PlayerCarryController.instance.ThrowAllCarryingObjects();
                _ctr = 0f;
            }
            else
            {
                _ctr += Time.deltaTime;
            }
        }
    }
}
