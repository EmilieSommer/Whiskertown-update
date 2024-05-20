using Unity.VisualScripting;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public Animator animator;
    public CatAiMovement catAiMovement;
    AudioManager audioManager;
    bool isBeingPetted = false;
    bool isBeingDragged = false;
    bool initialIsLayingDown;
    bool initialIsStanding;
    bool initialIsPet;
    bool canBePickedUp = false; // Flag to indicate if the cat can be picked up
    float clickTime = 0f; // Time of the last click

    void Start()
    {
        animator = GetComponent<Animator>();
        catAiMovement = GetComponent<CatAiMovement>();
        // Store the initial state of the cat
        initialIsLayingDown = animator.GetBool("isLayingDown");
        initialIsStanding = animator.GetBool("isStanding");
        initialIsPet = animator.GetBool("isPet");
    }

    void Update()
    {
        /*// If the cat can be picked up and the time since the last click is 3 seconds or more
        if (canBePickedUp && Time.time - clickTime >= 3f)
        {
            StartDragging();
        }*/
    }

    void OnMouseDown()
    {
        StartDragging();
    }

    void OnMouseUp()
    {
        StopDragging();
        StartPetting();
    }

    void OnMouseDrag()
    {
        // If the cat is being dragged, move it with the mouse
        if (isBeingDragged)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z; // Keep the same z position
            transform.position = mousePosition;
        }
    }

    void StartDragging()
    {
        AudioManager.instance.PlayAudio("event:/cat_sounds/Meow");
        animator.SetBool("isPickedUp", true);
        animator.SetBool("isLayingDown", initialIsLayingDown);
        catAiMovement.enabled = false;
        // Stop any current movement animations
        animator.SetFloat("MoveX", 0);
        animator.SetFloat("MoveY", 0);
        // Set the cat as being dragged
        isBeingDragged = true;
        // Reset the flag to disallow picking up the cat
        canBePickedUp = false;
    }

    void StopDragging()
    {
        animator.SetBool("isPickedUp", false);
        // Re-enable AI movement
        catAiMovement.enabled = true;
        // Reset the flag to disallow picking up the cat
        canBePickedUp = false;
        // Reset the dragging flag
        isBeingDragged = false;
    }

    void StartPetting()
    {
        AudioManager.instance.PlayAudio("event:/cat_sounds/Pet");
        animator.SetBool("isPet", true);
        catAiMovement.enabled = false;
        animator.SetFloat("MoveX", 0);
        animator.SetFloat("MoveY", 0);
        isBeingPetted = true;
        Invoke("EndPetting", 3.0f);
    }

    void EndPetting()
    {
        animator.enabled = true;
        isBeingPetted = false;
        catAiMovement.enabled = true;
        // Reset the cat to its original state
        animator.SetBool("isLayingDown", initialIsLayingDown);
        animator.SetBool("isStanding", initialIsStanding);
        animator.SetBool("isPet", initialIsPet);
    }
}
