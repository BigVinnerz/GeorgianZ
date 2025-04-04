using UnityEngine;

public class DoorManager : MonoBehaviour, IInteractible
{
    public GameObject DoorOpen;
    public GameObject DoorClose;
    private bool isDoorOpen = true; // Tracks the state of the door

    public Transform playerTransform; // Reference to the player's transform
    public float interactionRange = 5f; // The range within which the player can interact with the door

    void Start()
    {
        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Find the player if not set
        }
        UpdateDoorState();
    }

    void Update()
    {
        if (IsPlayerInRange() && Input.GetKeyDown(KeyCode.E)) // Check if player is within range and presses E
        {
            Interact();
        }
    }


    private bool IsPlayerInRange()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        return distance <= interactionRange;
    }

    public void Interact()
    {
        // Switch the door state when interacted with
        isDoorOpen = !isDoorOpen;
        UpdateDoorState();
    }

    private void UpdateDoorState()
    {
        if (isDoorOpen)
        {
            // Show the open door and hide closed door
            DoorOpen.SetActive(true);
            DoorClose.SetActive(false);
        }
        else
        {
            // Show the closed door and hide open door
            DoorOpen.SetActive(false);
            DoorClose.SetActive(true);
        }
    }
}
