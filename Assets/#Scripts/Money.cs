using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] int _value = 10;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIMoneyManager.instance.AddMoney(Camera.main.WorldToScreenPoint(transform.position), _value);
            Destroy(gameObject);
        }
    }
}
