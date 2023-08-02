using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerWaitArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Customer"))
        {
            var customer = other.GetComponent<CustomerController>();
            customer.ShowCanvas();
        }
    }
}
