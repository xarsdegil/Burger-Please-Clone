using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairController : MonoBehaviour
{
    [SerializeField] GameObject _plate;
    [SerializeField] List<GameObject> _allBurgers = new List<GameObject>();

    int _currentBurgerCount = 0, _maxBurgerCount;

    CustomerController _currentCustomer;

    private void Awake()
    {
        _maxBurgerCount = _allBurgers.Count;
    }

    public void AddBurger()
    {
        if (_currentBurgerCount == _maxBurgerCount) return;
        _allBurgers[_currentBurgerCount].SetActive(true);
        _currentBurgerCount++;
    }

    public void AddBurger(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            AddBurger();
        }
    }

    public void RemoveBurger()
    {
        if (_currentBurgerCount == 0) return;
        _currentBurgerCount--;
        _allBurgers[_currentBurgerCount].SetActive(false);
    }

    public void RemoveBurger(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            RemoveBurger();
        }
    }

    public void SetCustomer(CustomerController customerController)
    {
        _currentCustomer = customerController;
    }

    public void RemoveCustomer()
    {
        if (_currentCustomer == null) return;
        _currentCustomer = null;
    }

    public bool IsAvailable()
    {
        return _currentCustomer == null;
    }

}
