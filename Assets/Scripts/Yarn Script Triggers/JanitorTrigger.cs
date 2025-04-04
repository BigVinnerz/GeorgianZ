using UnityEngine;
using Yarn.Unity;

public class JanitorTrigger : MonoBehaviour, IInteractible
{
    public DialogueRunner dialogueRunner;

    public void Interact()
    {
        // Make sure the DialogueRunner is assigned in the Inspector or find it at runtime
        if (dialogueRunner != null)
        {
            dialogueRunner.StartDialogue("FindGeneratorsQuest");
        }
        else
        {
            Debug.LogError("DialogueRunner is not assigned!");
        }
    }
}
