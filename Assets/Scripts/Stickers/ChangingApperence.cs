using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingApperence : MonoBehaviour
{
    public Button[] buttons;
    public GameObject[] cowboyHats;
    public int selectedHatIndex = -1;
    public GameObject muslingStickers;
    public GameObject puslingStickers;
    public GameObject mislingStickers;


    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        Debug.Log("Hello");
        MenuManager menuManager = MenuManager.instance;
        if (menuManager == null)
        {
            Debug.LogError("MenuManager not found.");
            return; // Exit the method early to avoid further errors
        }

        string chosenCatString = MenuManager.instance.chosenCatString;
        Debug.Log(chosenCatString);

        // Check for null before accessing properties or methods of menuManager
        if (chosenCatString == "Musling")
        {
            muslingStickers.SetActive(true);
        }
        else if (chosenCatString == "Pusling")
        {
            puslingStickers.SetActive(true);
        }
        else if (chosenCatString == "Misling")
        {
            mislingStickers.SetActive(true);
        }

        // Initialize all cowboy hats to false
        foreach (GameObject hat in cowboyHats)
        {
            hat.SetActive(false);
        }

        // Attach click event handlers to the buttons
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Store the current index in a local variable to avoid closure issues
            buttons[i].onClick.AddListener(() => OnButtonClicked(index));
        }
    }



    private void OnButtonClicked(int index)
    {
        

        if (selectedHatIndex == index)
        {
            // Clicked the same cowboy hat again, set it to false
            cowboyHats[index].SetActive(false);
            selectedHatIndex = -1; 

        }
        else
        {
            // Set the clicked cowboy hat to true
            cowboyHats[index].SetActive(true);

            // Set all other cowboy hats to false
            for (int i = 0; i < cowboyHats.Length; i++)
            {
                if (i != index)
                {
                    cowboyHats[i].SetActive(false);
                }
            }

            selectedHatIndex = index;
        }
    }


}
