using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTextScript : MonoBehaviour
{
    public string texttodisplay;
    public GameManager gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUpAsButton()
    {
        gamemanager.subtitleString = texttodisplay;
        StartCoroutine(gamemanager.ShowSubtitles());
    }
}
