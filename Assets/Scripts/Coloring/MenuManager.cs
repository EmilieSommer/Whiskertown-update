using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public LevelManager levelManager;
    public GameObject Musling;
    public GameObject Pusling;
    public GameObject Misling;

    public GameObject[] muslingSprites = new GameObject[16];
    public GameObject[] puslingSprites = new GameObject[9];
    public GameObject[] mislingSprites = new GameObject[18];

    public GameObject chosenCat;
    public string chosenCatString = "Musling";
    public GameObject chosenCatPrefab;
    public List<GameObject> chosenList = new List<GameObject>();
    public List<Color> dataOfColors = new List<Color>();
    public List<GameObject> catPrefabSprites = new List<GameObject>();

    public static MenuManager instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (instance != this)
        {
            Debug.Log("okay?");
            Destroy(this);
        }
    }
    public void Start()
    {

        Musling.SetActive(true);
        Pusling.SetActive(false);
        Misling.SetActive(false);
        

    }
    public void MuslingClick()
    {
        switch (Musling.activeInHierarchy)
        {
            case true:
                Debug.Log("Musling is already chosen");
                break;
            case false:
                if (Pusling.activeInHierarchy)
                {
                    chosenCatString = "Musling";
                    ResetColorsPusling();
                    Pusling.SetActive(false);
                    Musling.SetActive(true);
                }
                else if (Misling.activeInHierarchy)
                {
                    chosenCatString = "Musling";
                    ResetColorsMisling();
                    Misling.SetActive(false);
                    Musling.SetActive(true);
                }
                else if (!Pusling.activeInHierarchy || !Misling.activeInHierarchy)
                {
                    Musling.SetActive(true);
                    chosenCatString = "Musling";
                }
                break;
        }
    }

    public void PuslingClick()
    {
        switch (Pusling.activeInHierarchy)
        {
            case true:
                Debug.Log("Pusling is already chosen");
                break;
            case false:
                if (Musling.activeInHierarchy || Misling.activeInHierarchy)
                {
                    chosenCatString = "Pusling";
                    ResetColorsMusling();
                    Musling.SetActive(false);
                    ResetColorsMisling();
                    Misling.SetActive(false);
                    Pusling.SetActive(true);
                }
                else if (!Musling.activeInHierarchy || !Misling.activeInHierarchy)
                {
                    chosenCatString = "Pusling";
                    Pusling.SetActive(true);
                }
                break;
        }
    }

    public void MislingClick()
    {
        switch (Misling.activeInHierarchy)
        {
            case true:
                Debug.Log("Misling is already chosen");
                break;
            case false:
                if (Musling.activeInHierarchy || Pusling.activeInHierarchy)
                {
                    chosenCatString = "Misling";
                    ResetColorsMusling();
                    Musling.SetActive(false);
                    ResetColorsPusling();
                    Pusling.SetActive(false);
                    Misling.SetActive(true);
                }
                else if (!Musling.activeInHierarchy || !Pusling.activeInHierarchy)
                {
                    chosenCatString = "Misling";
                    Misling.SetActive(true);
                }

                break;
        }
    }

    public void ResetColorsMusling()
    {
        foreach (GameObject obj in muslingSprites)
        {
            if (obj != null)
            {
                // Get the Renderer component of the GameObject
                SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();

                if (spriteRenderer != null)
                {
                    // Change the color to white
                    spriteRenderer.color = Color.white;
                    Debug.Log(obj.name + "Has changed color to" + spriteRenderer.material.color);
                }
                else
                {
                    Debug.LogWarning("Renderer component not found on GameObject: " + obj.name);
                }
            }
            else
            {
                Debug.LogWarning("Null GameObject found in the array!");
            }
        }
    }

    public void ResetColorsMisling()
    {
        Misling.SetActive(false);
        foreach (GameObject obj in mislingSprites)
        {
            if (obj != null)
            {
                // Get the Renderer component of the GameObject
                SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();

                if (spriteRenderer != null)
                {
                    // Change the color to white
                    spriteRenderer.color = Color.white;
                    Debug.Log(obj.name + "Has changed color to" + spriteRenderer.material.color);
                }
                else
                {
                    Debug.LogWarning("Renderer component not found on GameObject: " + obj.name);
                }
            }
            else
            {
                Debug.LogWarning("Null GameObject found in the array!");
            }
        }
    }

    public void ResetColorsPusling()
    {
        Pusling.SetActive(false);
        foreach (GameObject obj in puslingSprites)
        {
            if (obj != null)
            {
                // Get the Renderer component of the GameObject
                SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();

                if (spriteRenderer != null)
                {
                    // Change the color to white
                    spriteRenderer.color = Color.white;
                    Debug.Log(obj.name + "Has changed color to" + spriteRenderer.material.color);
                    Debug.Log("Color has changes");
                }
                else
                {
                    Debug.LogWarning("Renderer component not found on GameObject: " + obj.name);
                }
            }
            else
            {
                Debug.LogWarning("Null GameObject found in the array!");
            }
        }
    }

    public void CheckChosenCat()
    {
        if (Pusling.activeInHierarchy == true)
        {
            chosenCat = Pusling;
            //chosenCatString = "Pusling";
            // Check if the prefab is loaded successfully
            if (chosenCatPrefab == null)
            {
                Debug.LogError("Failed to load the prefab");
            }
            foreach (GameObject obj in puslingSprites)
            {
                if (obj != null)
                {
                    chosenList.Add(obj);
                }
            }

        }
        else if (Musling.activeInHierarchy == true)
        {
            chosenCat = Musling;
            //chosenCatString = "Musling";
            foreach (GameObject obj in muslingSprites)
            {
                if (obj != null)
                {
                    chosenList.Add(obj);
                }
            }
        }
        else if (Misling.activeInHierarchy == true)
        {
            chosenCat = Misling;
            //chosenCatString = "Misling";
            foreach (GameObject obj in puslingSprites)
            {
                if (obj != null)
                {
                    chosenList.Add(obj);
                }
            }
        }
        else
        {
            Debug.Log("No cats are active");
        }
        chosenCatPrefab = chosenCat;
    }

    public void SaveData()
    {
        CheckChosenCat();
        if (chosenCat.activeInHierarchy == true)
        {
            foreach (GameObject obj in chosenList)
            {
                if (obj != null)
                {
                    // Get the Renderer component of the GameObject
                    SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();

                    if (spriteRenderer != null)
                    {
                        dataOfColors.Add(spriteRenderer.color);
                    }
                    else
                    {
                        Debug.LogWarning("Renderer component not found on GameObject: " + obj.name);
                    }
                }
                else
                {
                    Debug.LogWarning("Null GameObject found in the array!");
                }
            }
        }
    }

    public void InstantiateCat()
    {
        SaveData();
        levelManager.LoadStickerScroll();
        Debug.Log(chosenCatString);
        if (chosenCatString == "Musling")
        {
            Vector3 newPosition = new Vector3(0.03f, -2.01f, 0f);
            Vector3 newScale = new Vector3(0.5f, 0.5f, 1f);
            InstantiatePrefab(newPosition, newScale);
        }
        else if (chosenCatString == "Pusling")
        {
            Vector3 newPosition = new Vector3(1.18f, -2.62f, 0f);
            Vector3 newScale = new Vector3(0.5f, 0.5f, 1f);
            InstantiatePrefab(newPosition, newScale);
        }
        else if(chosenCatString == "Misling")
        {
            Vector3 newPosition = new Vector3(0.46f, -1.91f, 0f);
            Vector3 newScale = new Vector3(0.5f, 0.5f, 1f);
            InstantiatePrefab(newPosition, newScale);
        }
        else
        {
            Debug.Log("Sofie");
        }
    }

    public void InstantiatePrefab(Vector3 newPosition, Vector3 newScale)
    {
        GameObject instantiatedCat = Instantiate(chosenCatPrefab, newPosition, Quaternion.identity);
        instantiatedCat.transform.localScale = newScale;
        if (chosenCatString == "Musling")
        {
            instantiatedCat.name = "Musling";
        }
        else if (chosenCatString == "Pusling")
        {
            instantiatedCat.name = "Pusling";
        }
        else if (chosenCatString == "Misling")
        {
            instantiatedCat.name = "Misling";
        }
        DontDestroyOnLoad(instantiatedCat);
        GameObject[] allChildren = instantiatedCat.GetComponentsInChildren<GameObject>(true);
        // Add all game objects to the list
        foreach (GameObject child in allChildren)
        {
            catPrefabSprites.Add(child);
        }
        foreach (GameObject obj in catPrefabSprites)
        {
            if (obj != null)
            {
                // Get the Renderer component of the GameObject
                SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();

                if (spriteRenderer != null)
                {
                    int index = 0;
                    if (index > catPrefabSprites.Count)
                    {
                        spriteRenderer.color = dataOfColors[index];
                        index++;
                    }
                }
                else
                {
                    Debug.LogWarning("Renderer component not found on GameObject: " + obj.name);
                }
            }
            else
            {
                Debug.LogWarning("Null GameObject found in the array!");
            }
        }
    }

}



