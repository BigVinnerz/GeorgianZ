using UnityEngine;
using TMPro;

public interface IInteractible
{
    void Interact();
}

public class WorkingButtonsScript : MonoBehaviour
{
    public Canvas interactionCanvas;
    public TMP_Text promptText;
    public float interactionDistance = 2.0f;

    public Transform player;
    private bool isinRange = false;
    private IInteractible interactableObject = null;

    void Start()
    {
        // Hides the interaction canvas when the game first starts
        interactionCanvas.enabled = false;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= interactionDistance)
        {
            // If the player is in range, show the prompt
            isinRange = true;
            interactionCanvas.enabled = true;
            promptText.text = "E";

            // Get the IInteractible component from the current GameObject
            interactableObject = GetComponent<IInteractible>();
        }
        else
        {
            // If the player is out of range, hide the prompt and set the interactable object to null
            isinRange = false;
            interactionCanvas.enabled = false;
            interactableObject = null;
        }

        // If the "E" key is pressed and the player is in range, call Interact() on the interactable object
        if (Input.GetKeyDown(KeyCode.E) && isinRange && interactableObject != null)
        {
            interactableObject.Interact();
        }
    }
}
