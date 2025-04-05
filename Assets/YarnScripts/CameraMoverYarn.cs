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
            case "NarrativeCutscene":
                MoveCamera(0);
                break;
            case "cut1":
                MoveCamera(1);
                break;
            case "cut2":
                MoveCamera(2);
                break;
            case "cut3":
                MoveCamera(3);
                break;
            case "cut4":
                MoveCamera(4);
                break;
            case "cut5":
                MoveCamera(5);
                break;
            case "cut6":
                MoveCamera(6);
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
