using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveController : MonoBehaviour
{
    public static StoveController instance;

    int _maxBurgerCount, _currentBurgerCount;
    float _ctr;

    public bool _canMake;
    [SerializeField] float _waitTime;
    public List<GameObject> _allBurgers = new List<GameObject>();
    [SerializeField] GameObject _maxCanvas;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _maxBurgerCount = _allBurgers.Count;
    }

    private void Update()
    {
        if (!_canMake) return;

        if (_currentBurgerCount == _maxBurgerCount)
        {
            if (!_maxCanvas.activeSelf)
                _maxCanvas.SetActive(true);
            return;
        }
        else
        {
            if (_maxCanvas.activeSelf)
                _maxCanvas.SetActive(false);
        }

        MakeBurger();
    }

    private void MakeBurger()
    {
        if (_ctr < _waitTime)
        {
            _ctr += Time.deltaTime;
            return;
        }

        _allBurgers[_currentBurgerCount].SetActive(true);
        _currentBurgerCount++;

        _ctr = 0;
    }

    public void GetBurger()
    {

    }
    
}
