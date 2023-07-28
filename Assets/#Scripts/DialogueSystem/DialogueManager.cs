using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    DialogueData _currentDialogue;
    [SerializeField] GameObject _dialoguePanel;
    [SerializeField] TMPro.TextMeshProUGUI _dialogueText;
    [SerializeField] float _typeSpeed = 0.05f;
    bool _dialogueActive = false, _skipDialogue = false, _isTyping = false;
    private void Awake()
    {
        instance = this;
    }


    private void OnEnable()
    {
        ETouch.EnhancedTouchSupport.Enable();
        ETouch.Touch.onFingerDown += HandleFingerDown;
    }

    private void OnDisable()
    {
        ETouch.Touch.onFingerDown -= HandleFingerDown;
        ETouch.EnhancedTouchSupport.Disable();
    }

    public void StartDialogue(DialogueData dialogue)
    {
        if (dialogue == null) return;
        _currentDialogue = dialogue;
        GameObject.Find("Player").GetComponent<PlayerTouchMovement>()._canMove = false;
        _dialogueActive = true;
        ShowUI();
        UpdateDialogueUI();
    }

    public void HandleFingerDown(Finger finger)
    {
        if (!_dialogueActive) return;
        if (_isTyping)
        {
            _skipDialogue = true;
        }
        else
        {
            if (_currentDialogue._nextDialogue != null)
            {
                _isTyping = false;
                _dialogueActive = false;
                StartDialogue(_currentDialogue._nextDialogue);
            }
            else
            {
                if (_currentDialogue._onFinishGameObjectName != string.Empty)
                {
                    GameObject.Find(_currentDialogue._onFinishGameObjectName).transform.GetChild(0).gameObject.SetActive(true);
                }
                _dialogueActive = false;
                HideUI();
                GameObject.Find("Player").GetComponent<PlayerTouchMovement>()._canMove = true;
            }
        }
    }

    private void UpdateDialogueUI()
    {
        StartCoroutine(TypeDialogueText());
    }



    private IEnumerator TypeDialogueText()
    {
        _isTyping = true;
        _dialogueText.text = string.Empty;

        float elapsedTime = 0f;

        bool showAllText = false;

        foreach (char letter in _currentDialogue._dialogueText)
        {
            Debug.Log("Typing letter " + letter);
            _dialogueText.text += letter;

            elapsedTime += Time.deltaTime;

            if (_skipDialogue || elapsedTime >= _typeSpeed * _currentDialogue._dialogueText.Length)
            {
                showAllText = true;
                _skipDialogue = false;
                break;
            }

            yield return new WaitForSeconds(_typeSpeed);
        }

        if (showAllText)
        {
            _dialogueText.text = _currentDialogue._dialogueText;
        }

        _isTyping = false;
    }

    public void ShowUI()
    {
        _dialoguePanel.SetActive(true);
    }

    public void HideUI()
    {
        _dialoguePanel.SetActive(false);
    }
}
