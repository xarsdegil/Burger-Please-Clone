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
    [SerializeField] GameObject _customerCanvas;
    [SerializeField] TMP_Text _wantedBurgerCountText;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _wantedBurgerCount = Random.Range(_minBurgerCount, _maxBurgerCount + 1);
        SetWantedBurgerCount();
    }

    private void Update()
    {
        if (_target == null) return;
        if(Vector3.Distance(transform.position, _target.position) <= 0.1f)
        {
            _agent.isStopped = true;
            transform.position = _target.position;
            var lookPos = _target.position;
            lookPos.z = transform.position.z + 1f;
            lookPos.y = transform.position.y;
            transform.LookAt(lookPos);
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
}
