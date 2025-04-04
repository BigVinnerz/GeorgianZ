using UnityEngine;

public class DoorManager : MonoBehaviour, IInteractible
{
    public GameObject DoorOpen;
    public GameObject DoorClose;
    private bool isDoorOpen = false; // Tracks the state of the door


    void Start()
    {
        UpdateDoorState();
    }


    void Update()
    {

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
