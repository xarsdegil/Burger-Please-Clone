using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class CustomerController : MonoBehaviour
{
    NavMeshAgent _agent;
    Animator _animator;
    Transform _target;

    int _wantedBurgerCount;

    [SerializeField] int _minBurgerCount = 1, _maxBurgerCount = 3;
    int _currentBurgerCount = 0;
    [SerializeField] GameObject _customerCanvas;
    [SerializeField] TMP_Text _wantedBurgerCountText;
    [SerializeField] GameObject _tray;
    [SerializeField] List<GameObject> _allBurgers = new List<GameObject>();
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _maxBurgerCount = _allBurgers.Count;
        _wantedBurgerCount = Random.Range(_minBurgerCount, _maxBurgerCount + 1);
        SetWantedBurgerCount();
    }

    private void Update()
    {
        if (_target == null) return;
        Move();
    }

    private void Move()
    {

        //_agent.isStopped = true;
        //transform.position = _target.position;
        //var lookPos = _target.position;
        //lookPos.z = transform.position.z + 1f;
        //lookPos.y = transform.position.y;
        //transform.LookAt(lookPos);
        if (Vector3.Distance(transform.position, _target.position) <= 1f)
        {
            if(_target.CompareTag("Chair"))
            {
                _agent.isStopped = true;
                transform.position = _target.position;
                var lookPos = _target.position + _target.forward;
                transform.LookAt(lookPos);
                _animator.SetBool("isSitting", true);
                _animator.SetBool("isRunning", false);
                _tray.SetActive(false);
            }
            else if (_target.CompareTag("WaitPoint"))
            {
                _agent.isStopped = true;
                transform.position = _target.position;
                var lookPos = _target.position;
                lookPos.z = transform.position.z + 1f;
                lookPos.y = transform.position.y;
                transform.LookAt(lookPos);
                _animator.SetBool("isRunning", false);
            }
        }
        else
        {
            _agent.isStopped = false;
            _agent.SetDestination(_target.position);
        }
        _animator.SetBool("isRunning", _agent.isStopped ? false : true);
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void SetWantedBurgerCount()
    {
        _wantedBurgerCountText.text = _wantedBurgerCount.ToString();
    }

    public void ShowCanvas()
    {
        _customerCanvas.SetActive(true);
    }

    public void HideCanvas()
    {
        _customerCanvas.SetActive(false);
    }

    public bool CanTakeBurger()
    {
        return _currentBurgerCount < _wantedBurgerCount;
    }

    public void TakeBurger()
    {
        if(_currentBurgerCount == 0)
        {
            _tray.SetActive(true);
            _animator.SetBool("isCarrying", true);
        }
        _allBurgers[_currentBurgerCount].SetActive(true);
        _currentBurgerCount++;

        if (_currentBurgerCount == _wantedBurgerCount)
        {
            HideCanvas();
            CustomersManager.instance.RemoveCustomer();
        }
        
        SetTarget(SelectRandomChair());
    }

    private Transform SelectRandomChair()
    {
        var allChairs = GameObject.FindGameObjectsWithTag("Chair");
        var randomChair = allChairs[Random.Range(0, allChairs.Length)];
        return randomChair.transform;
    }

    public void RemoveBurger()
    {
        _currentBurgerCount--;
        _allBurgers[_currentBurgerCount].SetActive(false);
        if (_currentBurgerCount == 0)
        {
            _tray.SetActive(false);
            _animator.SetBool("isCarrying", false);
        }
    }

    public void RemoveAllBurgers()
    {
        foreach (var burger in _allBurgers)
        {
            if (burger.activeSelf) burger.SetActive(false);
        }
        _currentBurgerCount = 0;
        _tray.SetActive(false);
        _animator.SetBool("isCarrying", false);
    }
}
