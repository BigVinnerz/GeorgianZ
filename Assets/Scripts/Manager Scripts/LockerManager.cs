using UnityEngine;

public class LockerManager : MonoBehaviour, IInteractible
{
    public GameObject LockerNaturalState;
    public GameObject LockerFallen;
    private bool isLockerFallen = false; // Tracks if the locker has fallen
    private bool isInteractable = true;  // Tracks whether the locker is still interactable

    void Start()
    {
        UpdateLockerState();
    }

    void Update()
    {

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
                isInteractable = false; // Disable interactions once it has fallen
            }
        }
    }

    // Updates the locker’s state based on whether it's fallen or not
    private void UpdateLockerState()
    {
        if (isLockerFallen)
        {
            // Show fallen locker and hide natural state
            LockerFallen.SetActive(true);
            LockerNaturalState.SetActive(false);
        }
        else
        {
            // Show natural state locker and hide fallen state
            LockerFallen.SetActive(false);
            LockerNaturalState.SetActive(true);
        }
    }
}
