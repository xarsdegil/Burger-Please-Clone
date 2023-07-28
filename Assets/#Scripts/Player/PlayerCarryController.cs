using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarryController : MonoBehaviour
{
    public static PlayerCarryController instance;

    public List<GameObject> _allBurgers = new List<GameObject>();
    public List<GameObject> _allTrashes = new List<GameObject>();

    [SerializeField] GameObject _tray;

    public bool _isCarryingTrash, _isCarryingBurger;

    int _maxBurgerCount, _currentBurgerCount, _maxTrashCount, _currentTrashCount;
    Animator _animator;

    private void Awake()
    {
        instance = this;
        _animator = GetComponentInChildren<Animator>();
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

    public bool CanGive()
    {
        return _currentBurgerCount > 0;
    }

    public void AddBurger()
    {
        if (_isCarryingTrash) return;
        if (_currentBurgerCount == _maxBurgerCount)
            return;
        if (_currentBurgerCount == 0)
        {
            _isCarryingBurger = true;
            SetCarryPosition();
        }
        _allBurgers[_currentBurgerCount].SetActive(true);
        _currentBurgerCount++;
    }

    public void RemoveBurger()
    {
        if (_isCarryingTrash) return;
        _currentBurgerCount--;
        _allBurgers[_currentBurgerCount].SetActive(false);
        if (_currentBurgerCount == 0)
        {
            _isCarryingBurger = false;
            SetNormalPosition();
        }
    }

    public void AddTrash()
    {
        if (_isCarryingBurger) return;
        if (_currentTrashCount == _maxTrashCount)
            return;
        if (_currentTrashCount == 0)
        {
            _isCarryingTrash = true;
            SetCarryPosition();
        }
        _allTrashes[_currentTrashCount].SetActive(true);
        _currentTrashCount++;
    }

    public void RemoveTrash()
    {
        if (_isCarryingBurger) return;
        _currentTrashCount--;
        _allTrashes[_currentTrashCount].SetActive(false);
        if (_currentTrashCount == 0)
        {
            _isCarryingTrash = false;
            SetNormalPosition();
        }
    }

    private void SetCarryPosition()
    {
        _tray.SetActive(true);
        _animator.SetBool("isCarrying", true);
    }

    private void SetNormalPosition()
    {
        _tray.SetActive(false);
        _animator.SetBool("isCarrying", false);
    }

    public int GetCurrentBurgerCount()
    {
        return _currentBurgerCount;
    }

    public int GetCurrentTrashCount()
    {
        return _currentTrashCount;
    }

    public void ThrowAllCarryingObjects()
    {
        foreach (var item in _allBurgers)
        {
            if(item.activeSelf) item.SetActive(false);
        }

        foreach (var item in _allTrashes)
        {
            if (item.activeSelf) item.SetActive(false);
        }

        _currentBurgerCount = 0;
        _currentTrashCount = 0;
        _isCarryingBurger = false;
        _isCarryingTrash = false;

        SetNormalPosition();
    }
    
}
