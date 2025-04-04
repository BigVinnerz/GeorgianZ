using UnityEngine;

public class LockerManager : MonoBehaviour, IInteractible
{
    public GameObject LockerNaturalState;
    public GameObject LockerFallen;
    private bool isLockerFallen = false; // Tracks if the locker has fallen
    private bool isInteractable = true;  // Tracks whether the locker is still interactable

    void Start()
    {
        UpdateLockerState(); // Initial state when the game starts
    }

    public void Interact()
    {
        if (isInteractable)
        {
            // If locker is not already fallen, make it fall
            if (!isLockerFallen)
            {
                isLockerFallen = true;
                UpdateLockerState();
                isInteractable = false; // Disable further interactions once it has fallen
                Debug.Log("Locker has fallen. Updating state.");
            }
        }
    }

    // Updates the locker’s state based on whether it's fallen or not
    private void UpdateLockerState()
    {
        if (isLockerFallen)
        {
            Debug.Log("Fallen state activated.");
            LockerFallen.SetActive(true);  // Make the fallen state visible
            LockerNaturalState.SetActive(false);  // Hide the natural state
        }
        else
        {
            Debug.Log("Natural state activated.");
            LockerFallen.SetActive(false);  // Hide the fallen state
            LockerNaturalState.SetActive(true);  // Show the natural state
        }
    }
}
