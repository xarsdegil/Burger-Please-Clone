using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanTableArea : MonoBehaviour
{
    [SerializeField] float _cleaningTime = 2f;
    float _cleaningTimer = 0f;

    [SerializeField] List<ChairController> _chairs = new List<ChairController>();

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var playerCarryController = other.GetComponent<PlayerCarryController>();
            if (playerCarryController.IsCarryingBurger()) return;

            _cleaningTimer += Time.deltaTime;
            if (_cleaningTimer >= _cleaningTime)
            {
                foreach (var chair in _chairs)
                {
                    if(chair.GetCurrentCustomer() != null) continue;
                    if (!chair.GetPlate().activeSelf) continue;

                    playerCarryController.AddTrash();
                    chair.RemovePlate();
                    _cleaningTimer = 0f;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _cleaningTimer = 0f;
        }
    }
}
