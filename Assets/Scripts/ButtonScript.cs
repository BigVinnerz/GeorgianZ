using UnityEngine;

public class ButtonScript : MonoBehaviour, IInteractible
{
    public void Interact()
    {
        Debug.Log("Nice button press dumbass");
    }
}