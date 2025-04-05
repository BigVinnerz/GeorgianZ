using UnityEngine;

public class LockerManager : MonoBehaviour, IInteractible
{
    public float fallenRotation = -90f; 
    public Vector2 fallenPosition = new Vector2(0, 0); 
    private bool isLockerFallen = false; 
    private bool isInteractable = true;  

    public void Interact()
    {
        if (isInteractable)
        {
            if (!isLockerFallen)
            {
                isLockerFallen = true;
                UpdateLockerState(); 
                isInteractable = false; 
                Debug.Log("Locker has fallen. Updated rotation and position.");
            }
        }
        else
        {
            Debug.Log("Locker is not interactable.");
        }
    }

    private void UpdateLockerState()
    {
        // Rotate the locker to the specified fallen angle
        transform.rotation = Quaternion.Euler(0, 0, fallenRotation);

        // Move the locker to the specified fallen position
        transform.position = new Vector3(fallenPosition.x, fallenPosition.y, transform.position.z);

        Debug.Log($"Locker position updated to: {fallenPosition}");
    }
}