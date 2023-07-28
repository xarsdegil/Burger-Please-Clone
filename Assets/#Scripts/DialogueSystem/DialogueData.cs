using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue Data", menuName = "Dialogue", order = 2)]
public class DialogueData : ScriptableObject
{
    public string _dialogueText;
    public string _onFinishGameObjectName;
    public DialogueData _nextDialogue;
}

