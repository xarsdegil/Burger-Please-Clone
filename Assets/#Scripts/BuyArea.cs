using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyArea : MonoBehaviour
{
    [SerializeField] Image _fillImage;
    [SerializeField] float _cost;
    [SerializeField] float _spendSpeed;
    [SerializeField] float _waitTime;
    [SerializeField] GameObject _setActiveObject;
    [SerializeField] bool _isStartingDialogue = false, _isActivatingOtherObject = false;
    [SerializeField] DialogueData _dialogueData;
    [SerializeField] string _onFinishGameObjectName;
    float _spentAmount, ctr;

    private void Awake()
    {
        _fillImage.fillAmount = 0;
        _spentAmount = 0;
        ctr = _waitTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var moneyText = GameObject.Find("MoneyText").GetComponent<TMP_Text>();
            if (_spentAmount >= _cost)
            {
                _setActiveObject.SetActive(true);
                NavMeshBaker.instance.BakeNavMesh();
                //AstarManager.instance.Scan();

                if (_isActivatingOtherObject)
                {
                    GameObject.Find(_onFinishGameObjectName).transform.GetChild(0).gameObject.SetActive(true);
                }

                if (_isStartingDialogue)
                {
                    DialogueManager.instance.StartDialogue(_dialogueData);
                }
                Destroy(gameObject);
            }

            if (ctr <= 0)
            {
                _spentAmount += _spendSpeed;
                _fillImage.fillAmount = (_spentAmount / _cost);
                moneyText.text = (int.Parse(moneyText.text) - _spendSpeed).ToString();
                ctr = _waitTime;
            }
            else
            {
                ctr -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ctr = _waitTime;
        }
    }
}
