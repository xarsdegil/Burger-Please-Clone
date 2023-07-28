using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        DialogueManager.instance.StartDialogue(Resources.Load<DialogueData>("Dialogues/GameStart/0"));
    }
}
