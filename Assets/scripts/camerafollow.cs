using JetBrains.Annotations;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;

    private void Awake()
    {
        if(player == null)
        {
            Debug.LogError("NO Player FOund");
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        offset = transform.position - player.transform.position;
    }

    private void FixedUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
