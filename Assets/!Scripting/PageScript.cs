using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageScript : MonoBehaviour
{
    public GameManager GameManager;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = FindObjectOfType<GameManager>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Page was pressed!");

        //gameObject.SetActive(false);

    }

   
}
