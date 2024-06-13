using System.Collections;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    public TMPro.TextMeshProUGUI dialogueText;

    public float typingSpeed = 0.05f;
        public float sentencePause = 0.5f; // Time to wait between sentences


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartDialogue(string dialogue, float delay = 0f)
    {
        StartCoroutine(TypeDialogue(dialogue, delay));
    }

    private IEnumerator TypeDialogue(string dialogue, float delay)
    {
        // Wait for the specified delay before starting the dialogue
        yield return new WaitForSeconds(delay);

        dialogueText.text = "";
        foreach (char letter in dialogue.ToCharArray())
        {
            dialogueText.text += letter;
            SoundManager.Instance.PlayTypewriterSound();
            
            if (letter == '.' || letter == '!' || letter == '?')
            {
                // Pause after a sentence
                yield return new WaitForSeconds(sentencePause);
            }
            else
            {
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        // Wait for some time after the dialogue is complete before clearing the text
        yield return new WaitForSeconds(2);
        dialogueText.text = "";
    }
}