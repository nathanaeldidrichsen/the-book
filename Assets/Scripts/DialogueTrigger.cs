using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [TextArea(3, 10)] // Allows for longer dialogue editing in the Inspector
    public string dialogue;
    public bool repeated;
    public bool hasBeenTriggered;
        public float dialogueDelay = 1.0f; // Time to wait before starting the dialogue


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasBeenTriggered)
        {
            DialogueManager.Instance.StartDialogue(dialogue, dialogueDelay);
            if (!repeated)
            {
                hasBeenTriggered = true;
            }
        }
    }
}
