using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class UIMoneyManager : MonoBehaviour
{
    public static UIMoneyManager instance;

    [SerializeField] float _duration;
    [SerializeField] TMP_Text _moneyText;
    [SerializeField] GameObject _moneyPrefab;
    [SerializeField] RectTransform _targetPos;

    private void Awake()
    {
        instance = this;
    }

    public void AddMoney(Vector3 startPos, int value)
    {
        var money = Instantiate(_moneyPrefab, transform);

        money.transform.SetParent(transform, false);

        money.transform.position = startPos;

        money.GetComponent<RectTransform>().DOMove(_targetPos.position, _duration, false).SetEase(Ease.InOutBack)
            .OnComplete(
            () => OnAddMoneyComplete(value, money)
            );
    }

    public void OnAddMoneyComplete(int value, GameObject moneyObject)
    {
        var moneyAmount = int.Parse(_moneyText.text);

        _moneyText.text = (moneyAmount + value).ToString();

        Destroy(moneyObject);
    }
}
