using System.Collections;
using UnityEngine;

public class CatAiMovement : MonoBehaviour
{
    internal Transform thisTransform;
    public Animator animator;
    private Vector2 minBounds;
    private Vector2 maxBounds;
    public float movementSpeed = 1.0f;
    public float layDownTime = 5.0f;

    // A minimum and maximum time delay for taking a decision, choosing a direction to move in
    public Vector2 decisionTime = new Vector2(1, 4);
    internal float decisionTimeCount = 0;

    // The possible directions that the object can move in: right, left, up, down, and zero for staying in place.
    internal Vector3[] moveDirections = new Vector3[] { 
        Vector3.right, 
        Vector3.left, 
        Vector3.up, 
        Vector3.down, 
        Vector3.zero, 
        Vector3.zero,
        Vector3.zero};
    internal int currentMoveDirection;

    // Boolean to track if the cat is laying down or idle
    private bool isBusy = false;

    // Use this for initialization
    void Start()
    {
        // Cache the transform for quicker access
        thisTransform = transform;
        animator = GetComponent<Animator>();
        // Set a random time delay for taking a decision (changing direction, or standing in place for a while)
        decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);
        animator.SetBool("isStanding", true);

        minBounds = Camera.main.ScreenToWorldPoint(Vector2.zero); // Bottom-left corner of the screen
        maxBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));      
    }

    // Update is called once per frame
    void Update()
    {
        if (!isBusy)
        {
            // Move the object in the chosen direction at the set speed
            Vector3 direction = moveDirections[currentMoveDirection];
            float xDir = direction.x;
            float yDir = direction.y;

            Vector3 newPosition = thisTransform.position + direction * Time.deltaTime * movementSpeed;

            // Clamp the new position within the specified bounds
            newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
            newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);

            thisTransform.position = newPosition;

            if (animator)
            {
                animator.SetFloat("MoveX", xDir);
                animator.SetFloat("MoveY", yDir);
            }

            if (moveDirections[currentMoveDirection] == Vector3.zero)
            {
                // Choose between being idle or laying down
                int randomChoice = Random.Range(0, 1);
                if (randomChoice == 0)
                {
                    // Lay down for 10 seconds
                    StartCoroutine(LayDownForSeconds());
                    animator.SetBool("isLayingDown", true);
                    animator.SetBool("isStanding", false);
                    isBusy = true; // Cat is busy, disable movement
                }
                else
                {
                    StartCoroutine(IdleForSeconds(6f));
                    isBusy = true; // Cat is busy, disable movement
                }
            }

            if (decisionTimeCount > 0)
                decisionTimeCount -= Time.deltaTime;
            else
            {
                // Choose a random time delay for taking a decision (changing direction, or standing in place for a while)
                decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);

                // Choose a movement direction, or stay in place
                ChooseMoveDirection();
            }
        }
    }

    public void OnCollision2D(Collider2D other)
    {
        if (other.gameObject.tag == "ElGatto")
        {   
            // If the cat collides with the player, lay down for 10 seconds
            StartCoroutine(LayDownForSeconds());
            animator.SetBool("isLayingDown", true);
            animator.SetBool("isStanding", false);
            isBusy = true; // Cat is busy, disable movement
        }
    }

    protected IEnumerator LayDownForSeconds()
    {
        // Perform the lay down action
        yield return new WaitForSeconds(layDownTime);
        // Resume normal behavior after laying down
        animator.SetBool("isLayingDown", false);
        animator.SetBool("isStanding", true);
        isBusy = false; // Cat is no longer busy, enable movement
        ChooseMoveDirection();
    }

    IEnumerator IdleForSeconds(float seconds)
    {
        // Perform the idle action
        yield return new WaitForSeconds(seconds);
        // Resume normal behavior after idling
        isBusy = false; // Cat is no longer busy, enable movement
        ChooseMoveDirection();
    }

    void ChooseMoveDirection()
    {
        // Choose whether to move sideways or up/down
        currentMoveDirection = Mathf.FloorToInt(Random.Range(0, moveDirections.Length));
    }
}
