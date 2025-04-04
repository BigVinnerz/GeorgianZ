using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public KeyCode interactionKey = KeyCode.E;
    private IInteractible currentInteractible;

    void Update()
    {
        if (Input.GetKeyDown(interactionKey) && currentInteractible != null)
        {
            currentInteractible.Interact(); 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IInteractible>(out IInteractible interactible))
        {
            currentInteractible = interactible;
            Debug.Log("Interactable object nearby. Press E to interact.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<IInteractible>(out IInteractible interactible) && interactible == currentInteractible)
        {
            currentInteractible = null;
            Debug.Log("Left interactable object's range.");
        }
    }
}