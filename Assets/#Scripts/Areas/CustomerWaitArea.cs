using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerWaitArea : MonoBehaviour
{
    [SerializeField] float _waitTime = 1f;
    float _timer = 0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Customer"))
        {
            var customer = other.GetComponent<CustomerController>();
            customer.ShowCanvas();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Customer"))
        {
            _timer += Time.deltaTime;
            if (_timer >= _waitTime)
            {
                var customer = other.GetComponent<CustomerController>();
                if (customer.CanTakeBurger() && CashierController.instance.CanGive())
                {
                    customer.TakeBurger();
                    CashierController.instance.GiveBurger();
                }
            }
        }
    }
}
