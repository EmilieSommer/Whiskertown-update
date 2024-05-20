using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintingManager : MonoBehaviour
{
    public MenuManager menuManager;
    public string currentColorName;
    public string currentHexCode;
    public Color currentColor;

    public const string Black = "Black";
    public const string Brown = "Brown";
    public const string Grey = "Grey";
    public const string White = "White";
    public const string Beige = "Beige";
    public const string Orange = "Orange";
    public const string Yellow = "Yellow";
    public const string Green = "Green";
    public const string Blue = "Blue";
    public const string Purple = "Purple";
    public const string Red = "Red";

    Dictionary<string, string> ColoringPens = new Dictionary<string, string>
    {
        {Black, "#300F07" },
        {Brown, "#743B09" },
        {Grey, "#66605C" },
        {White, "#FFF1E9" },
        {Beige, "#F5CDAF" },
        {Orange, "#F4A259"},
        {Yellow, "#F4CA70" },
        {Green, "#96B369" },
        {Blue, "#5585A5" },
        {Purple, "#944FA1" },
        {Red, "#BC4B51" }
    };

    public void SetHexCode()
    {
        currentHexCode = ColoringPens[currentColorName];
        Debug.Log("Current color: " + currentColorName + ". Current hexCode: " + currentHexCode);
    }

    public void SelectPens(RaycastHit2D hit)
    {
        switch (hit.collider.gameObject.name)
        {
            case Black:
                {
                    currentColorName = Black;
                    SetHexCode();
                    break;
                }
            case Brown:
                {
                    currentColorName = Brown;
                    currentHexCode = ColoringPens[currentColorName];
                    Debug.Log("Current color: " + currentColorName + ". Current hexCode: " + currentHexCode);
                    break;
                }
            case Grey:
                {
                    currentColorName = Grey;
                    currentHexCode = ColoringPens[currentColorName];
                    Debug.Log("Current color: " + currentColorName + ". Current hexCode: " + currentHexCode);
                    break;
                }
            case White:
                {
                    currentColorName = White;
                    currentHexCode = ColoringPens[currentColorName];
                    Debug.Log("Current color: " + currentColorName + ". Current hexCode: " + currentHexCode);
                    break;
                }
            case Beige:
                {
                    currentColorName = Beige;
                    currentHexCode = ColoringPens[currentColorName];
                    Debug.Log("Current color: " + currentColorName + ". Current hexCode: " + currentHexCode);
                    break;
                }
            case Orange:
                {
                    currentColorName = Orange;
                    currentHexCode = ColoringPens[currentColorName];
                    Debug.Log("Current color: " + currentColorName + ". Current hexCode: " + currentHexCode);
                    break;
                }
            case Yellow:
                {
                    currentColorName = Yellow;
                    currentHexCode = ColoringPens[currentColorName];
                    Debug.Log("Current color: " + currentColorName + ". Current hexCode: " + currentHexCode);
                    break;
                }
            case Green:
                {
                    currentColorName = Green;
                    currentHexCode = ColoringPens[currentColorName];
                    Debug.Log("Current color: " + currentColorName + ". Current hexCode: " + currentHexCode);
                    break;
                }
            case Blue:
                {
                    currentColorName = Blue;
                    currentHexCode = ColoringPens[currentColorName];
                    Debug.Log("Current color: " + currentColorName + ". Current hexCode: " + currentHexCode);
                    break;
                }
            case Purple:
                {
                    currentColorName = Purple;
                    currentHexCode = ColoringPens[currentColorName];
                    Debug.Log("Current color: " + currentColorName + ". Current hexCode: " + currentHexCode);
                    break;
                }
            case Red:
                {
                    currentColorName = Red;
                    currentHexCode = ColoringPens[currentColorName];
                    Debug.Log("Current color: " + currentColorName + ". Current hexCode: " + currentHexCode);
                    break;
                }
        }
    }

    private void Paint(SpriteRenderer spriteRenderer)
    {
        spriteRenderer.color = HexToColor();
    }

    private Color HexToColor()
    {
        switch (currentColorName)
        {
            case "Black":
                if (ColorUtility.TryParseHtmlString("#300F07", out currentColor))
                {
                    Debug.Log("New color is " + currentColor);
                    return currentColor;
                }
                else
                {
                    return Color.white;
                }
            case "Brown":
                if (ColorUtility.TryParseHtmlString("#743B09", out currentColor))
                {
                    Debug.Log("New color is " + currentColor);
                    return currentColor;
                }
                else
                {
                    return Color.white;
                }
            case "Grey":
                if (ColorUtility.TryParseHtmlString("#66605C", out currentColor))
                {
                    Debug.Log("New color is " + currentColor);
                    return currentColor;
                }
                else
                {
                    return Color.white;
                }
            case "White":
                if (ColorUtility.TryParseHtmlString("#FFF1E9", out currentColor))
                {
                    Debug.Log("New color is " + currentColor);
                    return currentColor;
                }
                else
                {
                    return Color.white;
                }
            case "Beige":
                if (ColorUtility.TryParseHtmlString("#F5CDAF", out currentColor))
                {
                    Debug.Log("New color is " + currentColor);
                    return currentColor;
                }
                else
                {
                    return Color.white;
                }
            case "Orange":
                if (ColorUtility.TryParseHtmlString("#F4A259", out currentColor))
                {
                    Debug.Log("New color is " + currentColor);
                    return currentColor;
                }
                else
                {
                    return Color.white;
                }
            case "Yellow":
                if (ColorUtility.TryParseHtmlString("#F4CA70", out currentColor))
                {
                    Debug.Log("New color is " + currentColor);
                    return currentColor;
                }
                else
                {
                    return Color.white;
                }
            case "Green":
                if (ColorUtility.TryParseHtmlString("#96B369", out currentColor))
                {
                    Debug.Log("New color is " + currentColor);
                    return currentColor;
                }
                else
                {
                    return Color.white;
                }
            case "Blue":
                if (ColorUtility.TryParseHtmlString("#5585A5", out currentColor))
                {
                    Debug.Log("New color is " + currentColor);
                    return currentColor;
                }
                else
                {
                    return Color.white;
                }
            case "Purple":
                if (ColorUtility.TryParseHtmlString("#944FA1", out currentColor))
                {
                    Debug.Log("New color is " + currentColor);
                    return currentColor;
                }
                else
                {
                    return Color.white;
                }
            case "Red":
                if (ColorUtility.TryParseHtmlString("#BC4B51", out currentColor))
                {
                    Debug.Log("New color is " + currentColor);
                    return currentColor;
                }
                else
                {
                    return Color.white;
                }
        }
        return Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the mouse position
            Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // RaycastHit hit;

            RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);
            Debug.Log("Clicking");
            // Check if the ray hits any colliders in the scene
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.tag);
                //Check if the GameObject hit by the ray has the "ColoringPen" tag
                if (hit.collider.CompareTag("ColoringPen"))
                {
                    Debug.Log("pen selected");
                    SelectPens(hit);
                }

                // Check if the GameObject hit by the ray has the "Paintable" tag
                else if (hit.collider.CompareTag("Paintable"))
                {
                    Debug.Log("Paintable detected");
                    SpriteRenderer spriteRenderer = hit.collider.GetComponent<SpriteRenderer>();
                    if (spriteRenderer != null)
                    {
                        // Calls Paint() with the accesed spriteRenderer component as argument
                        Paint(spriteRenderer);
                        Debug.Log("Painting now");
                    }
                }

                else if (hit.collider.CompareTag("Button1"))
                {
                    menuManager.MuslingClick();
                }

                else if (hit.collider.CompareTag("Button2"))
                {
                    menuManager.PuslingClick();
                }
                else if (hit.collider.CompareTag("Button3"))
                {
                    menuManager.MislingClick();
                }
                else
                {
                    // GameObjects with collider without Tag found
                    Debug.LogError("Clicked on GameObject with a different tag.");
                }
            }
        }



        // Start is called before the first frame update
        void Start()
        {

        }
    }
}

