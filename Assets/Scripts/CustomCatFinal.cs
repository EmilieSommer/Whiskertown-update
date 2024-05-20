using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCatFinal : MonoBehaviour
{
    public GameObject npcPus;
    public GameObject npcMus;
    public GameObject npcMis;
    private Material catMaterial;
    private int Hatnumber;

    

    // Start is called before the first frame update
    void Start()
    {
        
        ChangingApperence apperencescript = FindObjectOfType<ChangingApperence>();
        
        Hatnumber = apperencescript.selectedHatIndex;

        string chosencat = ""; // Add a value to the string variable

        switch (chosencat)
        {
            case "Musling":
                GameObject newMusling = Instantiate(npcMus, Vector3.zero, Quaternion.identity);
                SetHatActive(newMusling, Hatnumber);
                GameObject MuslingMat = newMusling.transform.Find("MuslingColor").gameObject;
                Renderer muslingRenderer = MuslingMat.GetComponent<Renderer>();
                catMaterial = muslingRenderer.material;
                break;

            case "Pusling":
                GameObject newPusling = Instantiate(npcPus, Vector3.zero, Quaternion.identity);
                SetHatActive(newPusling, Hatnumber);
                GameObject PuslingMat = newPusling.transform.Find("PuslingColor").gameObject;
                Renderer puslingRenderer = PuslingMat.GetComponent<Renderer>();
                catMaterial = puslingRenderer.material;
                break;

            case "Misling":
                GameObject newMisling = Instantiate(npcMis, Vector3.zero, Quaternion.identity);
                SetHatActive(newMisling, Hatnumber);
                GameObject MislingMat = newMisling.transform.Find("MislingColor").gameObject;
                Renderer mislingRenderer = MislingMat.GetComponent<Renderer>();
                catMaterial = mislingRenderer.material;
                break;

            default:
                Debug.Log("No cat chosen");
                break;
        }
    }

    private void SetCatColor()
    {
        Color[] dataOfColors = new Color[18]; // Assuming there are 18 colors in the array

        // Retrieve the RGBD colors from the shader and convert them to hex colors
        for (int i = 0; i < dataOfColors.Length; i++)
        {
            // Retrieve the RGBD color from the shader
            Color rgbdColor = catMaterial.GetColor($"_TargetColor{i + 1}");

            // Convert the RGBD color to hex color
            string hexColor = ColorUtility.ToHtmlStringRGB(rgbdColor);

            // Convert the hex color back to Color
            Color convertedColor;
            ColorUtility.TryParseHtmlString(hexColor, out convertedColor);

            // Store the converted color in the array
            dataOfColors[i] = convertedColor;
        }

        // Set the converted colors in the shader
        for (int i = 0; i < dataOfColors.Length; i++)
        {
            catMaterial.SetColor($"_TargetColor{i + 1}", dataOfColors[i]);
        }
    }
   
    private void SetHatActive(GameObject catObject, int hatNumber)
    {
        GameObject standHat = catObject.transform.Find("Stand").gameObject;
        SetHatActiveInChild(standHat.transform.Find("Hat").gameObject, hatNumber);
        GameObject pickHat = catObject.transform.Find("Pick").gameObject;
        SetHatActiveInChild(pickHat.transform.Find("Hat").gameObject, hatNumber);
        GameObject rightHat = catObject.transform.Find("Right").gameObject;
        SetHatActiveInChild(rightHat.transform.Find("Hat").gameObject, hatNumber);
        GameObject layHat = catObject.transform.Find("Lay").gameObject;
        SetHatActiveInChild(layHat.transform.Find("Hat").gameObject, hatNumber);
    }

    private void SetHatActiveInChild(GameObject hat, int hatNumber)
    {
        foreach (Transform child in hat.transform)
        {
            child.gameObject.SetActive(child.GetSiblingIndex() == hatNumber);
        }
    }
}

