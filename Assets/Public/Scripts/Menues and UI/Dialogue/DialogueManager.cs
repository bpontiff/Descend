using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> dialogueQueue;

    // Start is called before the first frame update
    private void Start()
    {
        dialogueQueue = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        dialogueQueue.Clear();

        nameText.text = dialogue.name;

        foreach (string sentence in dialogue.sentences)
        {
            dialogueQueue.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public bool DisplayNextSentence()
    {
        Debug.Log(dialogueQueue.Count);
        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
            return false;
        }
        string line = dialogueQueue.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeDialogue(line));
        return true;
    }

    private IEnumerator TypeDialogue(string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
