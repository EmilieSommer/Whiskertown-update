using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tumble : MonoBehaviour
{
    Rigidbody2D rb; // This helps our object to move in the game world.
    float xMovement; // This is how much we want to move left or right.
    float moveSpeed = 5f; // This is how fast we want to move.
    public bool continueMoving = true; // This tells us if we should keep moving or not.
    [SerializeField] protected Animator myAnimator; // This helps us animate our object.
    private string sound; // This is where we would put a sound effect.

    // These are for timing when things should happen.
    float delay1 = 0.3f; // This is how long before our object disappears after exploding.
    float delay2 = 15f; // This is how long before our object explodes on its own.

    [SerializeField] float tiltThreshold = 5f; // This is how much we need to tilt our device before the object moves.

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // This helps us control our object's physics.
        myAnimator = gameObject.GetComponent<Animator>(); // This helps us with animations.
        StartCoroutine(DestroyAfterTime()); // This makes our object explode after a while.
    }

    void Update()
    {
        // This part makes our object move when we tilt our device.
        if (Mathf.Abs(Input.acceleration.x) > tiltThreshold)
        {
            xMovement = Input.acceleration.x * moveSpeed; // This calculates how much we should move.
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, -20f, 20f), transform.position.y); // This keeps our object within certain boundaries.
        }
        else
        {
            // If we're not tilting, just move the object to the right.
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime); // This makes the object move.
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(xMovement, 0f); // This makes sure our object moves according to physics.
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(delay2); // This makes our object wait for a while.
        Explode(); // This makes our object explode after waiting.
    }

    private void OnMouseDown()
    {
        // If someone clicks on our object, we want it to explode immediately.
        Explode();
    }

    // This is what makes our object explode.
    void Explode()
    {
        // This triggers an animation to show our object exploding.
        myAnimator.SetTrigger("Active");
        // This makes our object disappear after exploding.
        Destroy(gameObject, delay1);
    }
}
