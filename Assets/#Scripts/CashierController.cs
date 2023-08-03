using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashierController : MonoBehaviour
{
    public static CashierController instance;

    [SerializeField] List<GameObject> _allBurgers = new List<GameObject>();
    [SerializeField] GameObject _maxCanvas;
    int _maxBurgerCount, _currentBurgerCount;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _maxBurgerCount = _allBurgers.Count;
        _currentBurgerCount = 0;
    }

    public void AddBurger()
    {
        if(_maxCanvas.activeSelf) return;
        if (_currentBurgerCount == _maxBurgerCount - 1)
        {
            _maxCanvas.SetActive(true);
        }

        if (_currentBurgerCount < _maxBurgerCount)
        {
            _allBurgers[_currentBurgerCount].SetActive(true);
            _currentBurgerCount++;
        }
    }

    public void GiveBurger()
    {
        if (_currentBurgerCount == 0)
        {
            return;
        }

        if (_currentBurgerCount > 0)
        {
            if (_maxCanvas.activeSelf)
            {
                _maxCanvas.SetActive(false);
            }

            _currentBurgerCount--;
            _allBurgers[_currentBurgerCount].SetActive(false);
        }
    }

    public bool CanCarry()
    {
        return _currentBurgerCount < _maxBurgerCount;
    }

    public bool CanGive()
    {
        return _currentBurgerCount > 0;
    }

}
