using UnityEngine;

public class TriggerInteraction : MonoBehaviour
{
    public LockerManager lockerManager; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is in range of the locker.");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            if (lockerManager != null)
            {
                lockerManager.Interact(); 
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player left the range of the locker.");
        }
    }
}