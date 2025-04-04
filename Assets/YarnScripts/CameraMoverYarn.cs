using UnityEngine;
using Yarn.Unity;

public class CameraMoverYarn : MonoBehaviour
{
    public Transform[] positions; 
    private int currentPositionIndex = 0; 
    private AudioSource currentAudioSource; 

    public DialogueRunner dialogueRunner;

    void Start()
    {
        dialogueRunner.onNodeStart.AddListener(OnNodeStart);
    }

    void OnNodeStart(string nodeName)
    {
        // Check the node name to move the camera
        switch (nodeName)
        {
            case "Start":
                MoveCamera(0);
                break;
            case "Begin":
                MoveCamera(1);
                break;
            case "ReadyText":
                MoveCamera(2);
                break;
            case "ScaredText":
                MoveCamera(3);
                break;
            case "BranchOff":
                MoveCamera(4);
                break;
            case "BranchA":
                MoveCamera(5);
                break;
            case "BranchB":
                MoveCamera(6);
                break;
            case "Ending":
                MoveCamera(7);
                break;
            case "EndingOne":
                MoveCamera(8);
                break;
            case "EndingTwo":
                MoveCamera(9);
                break;
        }
    }

    void MoveCamera(int positionIndex)
    {
        if (positions.Length == 0 || positionIndex >= positions.Length) return;

        if (currentAudioSource != null && currentAudioSource.isPlaying)
        {
            currentAudioSource.Stop();
        }

        currentPositionIndex = positionIndex;
        transform.position = positions[currentPositionIndex].position;
        transform.rotation = positions[currentPositionIndex].rotation;

        PlayAudioAtPosition(positions[currentPositionIndex]);
    }

    void PlayAudioAtPosition(Transform position)
    {
        AudioSource audioSource = position.GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
            currentAudioSource = audioSource; 
        }
    }

    void OnDestroy()
    {
        dialogueRunner.onNodeStart.RemoveListener(OnNodeStart);
    }
}
