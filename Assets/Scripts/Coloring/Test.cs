using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse button down detected.");

            // Check if the mouse is hitting a collider
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Collider detected.");
            }
            else
            {
                Debug.Log("no ");
            }

        }
    }

    public void Debugs()
    {
        Debug.Log("HELLO SOFIE");
    }
    // Update is called once per frame
    void Update()
    {
        OnMouseDown();
    }
}
