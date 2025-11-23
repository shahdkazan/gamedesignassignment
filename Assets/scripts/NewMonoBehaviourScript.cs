

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    // Update is called once per frame
    void Update()
    {
        // Get player input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        // Create a movement vector
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        // Move the player
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
