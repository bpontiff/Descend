using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue(DialogueManager manager)
    {
        manager.StartDialogue(dialogue);
    }
}
