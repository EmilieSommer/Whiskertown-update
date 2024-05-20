using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatManager : MenuManager
{   
    [SerializeField] GameObject[] chosenCat = null;
    [SerializeField] Color[] chosencolors = null; 
    [SerializeField] GameObject catobject = null;
    Queue<Color> colorQueue = new Queue<Color>();    

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void SaveCatData()
    {
        int index = 0; // Initialize index here

        // Check which cat is active
        if (Musling.activeSelf)
        {
            chosenCat = muslingSprites; // Assuming muslingSprites is an array of GameObjects
            catobject = Musling;
        }
        else if (Misling.activeSelf)
        {
            chosenCat = mislingSprites; // Assuming mislingSprites is an array of GameObjects
            catobject = Misling;
        }
        else if (Pusling.activeSelf)
        {
            chosenCat = puslingSprites; // Assuming puslingSprites is an array of GameObjects
            catobject = Pusling;
        }
        else
        {
            Debug.Log("No cat chosen");
            return; // Exit the method if no cat is chosen
        }

           // Apply colors to the sprites
    Queue<Color> colorQueue = new Queue<Color>();
    SpriteRenderer[] spriteRenderers = catobject.GetComponentsInChildren<SpriteRenderer>();

    // Iterate over the children of catobject and add them to chosenCat array
    foreach (Transform child in catobject.transform)
    {
        chosenCat[index] = child.gameObject;
        index++;
    }
    }
}
         
    
    


   /* void InsertNewCat(GameObject[] chosenCat, Color[] chosencolors, GameObject catobject)
    {
        for (int i = 0; i < chosenCat.Length; i++)
        {
            catobject.GetComponent<SpriteRenderer>().color = chosencolors[i];
        }

        GameObject newCatObject = Instantiate(catobject, Vector3.zero, Quaternion.identity);

        SpriteRenderer[] spriteRenderers = newCatObject.GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            spriteRenderers[i].color = chosencolors[i];
        }
    }*/

    // Check the color of each child object
   


//when the "done" button is pressed in the "NewColorScene",  check If musling, pusling or misling has been chosen and if one have been chosen check its children spriterendere and the color of that and instantiate a new version in the "StickerColor" scene

