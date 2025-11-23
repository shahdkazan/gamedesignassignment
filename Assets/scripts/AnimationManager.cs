using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Singleton (simple pattern)
    public static AnimationManager Instance;
    public Animator doorAnimator;
    private void Awake()
    {
        if (doorAnimator == null)
        {
            Debug.LogError("DoorAnimator: no Animator found.");
        }
        // Enforce singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        // If you want this manager to persist across scenes uncomment:
        // DontDestroyOnLoad(gameObject);
    }
    [ContextMenu("OpenDoor")]
    public void OpenDoor()
    {
        doorAnimator.SetBool("is open", true);
    }
    [ContextMenu("CloseDoor")]
    public void CloseDoor()
    {
        doorAnimator.SetBool("is open", false);
    }
    // Alternative Approach
    public void ToggleDoor()
    {
        bool current = doorAnimator.GetBool("is open");
        doorAnimator.SetBool("is open", !current);
    }

    }
