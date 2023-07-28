using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool _isGameStarted = false;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        DialogueManager.instance.StartDialogue(Resources.Load<DialogueData>("Dialogues/GameStart/0"));
    }
}
