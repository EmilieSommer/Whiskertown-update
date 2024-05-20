using UnityEngine;

public class Cat : Animal
{
    CatController catController;
    CatAiMovement catAiMovement;
    Animator catAnimator;
    CatBodyType catBodyType;

    private float movementSpeed;
    private float layDownTime;

    public virtual void Start()
    {

    }

    public virtual void GetAnimator()
    {
        // Load the appropriate cat prefab based on body type (assuming you have CatBodyType enum)
        GameObject catPrefab = Resources.Load<GameObject>("CatPrefab_" + catBodyType.ToString());

        // Instantiate the prefab
        GameObject newCat = Instantiate(catPrefab, transform.position, Quaternion.identity);

        // Get the animator component of the instantiated cat
        catAnimator = newCat.GetComponent<Animator>();
    }

    public virtual void Speed()
    {
        movementSpeed = Random.Range(0.2f, 1f);
    }

    public virtual void LayDown()
    {
        layDownTime = Random.Range(5f, 10f);
    }

    public virtual void GiveScripts()
    {
        catController = gameObject.AddComponent<CatController>();
        catAiMovement = gameObject.AddComponent<CatAiMovement>();
    }
}
