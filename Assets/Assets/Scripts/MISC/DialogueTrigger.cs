using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueCharacter // Indicates who is speaking
{
    public string name;
    public Sprite sprite;
}

[System.Serializable]
public class DialogueLine // Initialize character dialogue
{
    public DialogueCharacter character;
    [TextArea(3, 10)] // x = minimum, y = maximum lines for dialogue
    public string line;
}

[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>(); // List of dialogues
}

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            TriggerDialogue();
        }
    }
}
