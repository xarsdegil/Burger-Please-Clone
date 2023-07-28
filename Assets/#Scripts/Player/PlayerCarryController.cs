using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarryController : MonoBehaviour
{
    public static PlayerCarryController instance;

    [SerializeField] List<GameObject> _allBurgers = new List<GameObject>();
    [SerializeField] GameObject _tray;
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

    public bool CanCarry()
    {
        return _currentBurgerCount < _maxBurgerCount;
    }

    public void AddBurger()
    {
        if (_currentBurgerCount == _maxBurgerCount)
            return;
        if (_currentBurgerCount == 0) SetCarryPosition();
        _allBurgers[_currentBurgerCount].SetActive(true);
        _currentBurgerCount++;
    }

    private void SetCarryPosition()
    {
        _tray.SetActive(true);
        //animasyon ayarla
    }

    private void SetNormalPosition()
    {
        _tray.SetActive(false);
        //animasyon ayarla
    }

    public void RemoveBurger()
    {
        _currentBurgerCount--;
        _allBurgers[_currentBurgerCount].SetActive(false);
        if (_currentBurgerCount == 0) SetNormalPosition();
    }

    
}
