using UnityEngine;

public class LockerManager : MonoBehaviour, IInteractible
{
    public float fallenRotation = -90f; // Rotation angle when the locker falls
    private bool isLockerFallen = false; // Tracks if the locker has fallen
    private bool isInteractable = true;  // Tracks whether the locker is still interactable

    public void Interact()
    {
        if (isInteractable)
        {
            // If locker is not already fallen, make it fall
            if (!isLockerFallen)
            {
                isLockerFallen = true;
                RotateLocker(); // Rotate the locker
                isInteractable = false; // Disable further interactions
                Debug.Log("Locker has fallen. Rotated to fallen state.");
            }
        }
        else
        {
            Debug.Log("Locker is not interactable.");
        }
    }

    private void RotateLocker()
    {
        // Rotate the locker to the specified fallen angle
        transform.rotation = Quaternion.Euler(0, 0, fallenRotation);
    }
}