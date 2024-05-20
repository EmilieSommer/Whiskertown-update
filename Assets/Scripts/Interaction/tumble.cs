using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tumble : MonoBehaviour
{
    Rigidbody2D rb;
    float xMovement;
    float moveSpeed = 5f;
    public bool continueMoving = true;
    [SerializeField]protected Animator myAnimator;
    private string sound;
    //Sets a delay for 0.2f
    float delay1 = 0.3f;
    float delay2 = 15f;
    [SerializeField] float tiltThreshold = 5f;
    


   void Awake()
    {
        rb = GetComponent<Rigidbody2D> ();
        myAnimator = gameObject.GetComponent<Animator>();
        StartCoroutine(DestroyAfterTime());
    }

    void Update()
    {
        //moves gameobject by tilting device
        if (Mathf.Abs(Input.acceleration.x) > tiltThreshold)
        {
            xMovement = Input.acceleration.x * moveSpeed;
            transform.position = new Vector2 (Mathf.Clamp (transform.position.x, -20f, 20f), transform.position.y);
        }

        else 
        {
           transform.Translate(Vector3.right * moveSpeed * Time.deltaTime); 
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2 (xMovement, 0f);
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(delay2);
        Explode();
    }

    private void OnMouseDown()
    {
        //Initiate the Explode(); Method
        Explode();
    }

    //Explode method
    void Explode()
    {
        //Set the animator to PopTrigger animation
        myAnimator.SetTrigger("Active");
        //Destroys the gameObject after delay
        Destroy(gameObject,delay1);
    }
    
    
}
