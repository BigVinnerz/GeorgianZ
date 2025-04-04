using UnityEngine;
using UnityEngine.UI;
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
        // Hides the interaction canvas when the game first starts.
        interactionCanvas.enabled = false;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= interactionDistance)
        {
            isinRange = true;
            interactionCanvas.enabled = true;
            promptText.text = "E";

            // Gets the IInteractible component from the current GameObject.
            interactableObject = GetComponent<IInteractible>();
        }
        else
        {
            isinRange = false;
            interactionCanvas.enabled = false;

            // If no interactable object in range, set it to null.
            interactableObject = null;
        }

        // If the "E" key is pressed and an interactable object is in range, call Interact() method.
        if (Input.GetKeyDown(KeyCode.E) && isinRange && interactableObject != null)
        {
            interactableObject.Interact();
        }
    }
}
