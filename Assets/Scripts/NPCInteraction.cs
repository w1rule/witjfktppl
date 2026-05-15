using UnityEngine;
using Yarn.Unity;

public class NPCInteraction : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public string startNode = "Start";

    private bool playerNearby = false;

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            dialogueRunner.StartDialogue(startNode);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}