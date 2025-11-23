

//using UnityEngine;

//public class BallMovement : MonoBehaviour
//{
//    public float speed = 5f;
//    private Rigidbody rb;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//    }

//    void FixedUpdate()
//    {
//        float moveX = Input.GetAxis("Horizontal");
//        float moveZ = Input.GetAxis("Vertical");

//        Vector3 movement = new Vector3(moveX, 0, moveZ);
//        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
//    }
//void OnTriggerEnter(Collider other)
//{
//    if (other.gameObject.CompareTag("PickUp"))
//    {
//        other.gameObject.SetActive(false);
//    }
//}
//}

using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f;
    public AudioClip pickUpSound;   // assign in Inspector
    private Rigidbody rb;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0, moveZ);
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("PickUp"))
        {
            if (pickUpSound != null)
                audioSource.PlayOneShot(pickUpSound);

            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("Door"))
        {
            Debug.Log("Door trigger detected.");
            AnimationManager.Instance.ToggleDoor();
        }

    }
      
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            AnimationManager.Instance.ToggleDoor();
        }
    }
}
