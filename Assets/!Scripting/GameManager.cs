using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //UI 
    public GameObject[] objectArray;
    public TextMeshProUGUI tmpSubtitle, pageCounter, objectivesText;
    public int numberofPages;
    public string subtitleString;
    public GameObject objectivesPanel, subtitlePanel;


   
    // Start is called before the first frame update
    void Start()
    {
        numberofPages = 4;
        subtitleString = "What?... Where am I?";
        StartCoroutine(ShowSubtitles());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    void NextObjective()
    {

    }

    public IEnumerator ShowSubtitles()
    {
        ChangeSubtitleText(subtitleString);
        subtitlePanel.SetActive(true);
        

        yield return new WaitForSeconds(6f);

        subtitlePanel.SetActive(false);
    }

    void ChangeSubtitleText(string words)
    {
        
        tmpSubtitle.text = words;
    }
    
    public void LanternPickup()
    {
        subtitleString = "This might come in handy...";
        StartCoroutine (ShowSubtitles());
        objectivesText.text = "Find out what happened to you.";

    }

    public void PagePickup()
    {
        numberofPages--;
        objectivesText.text = "Find the remaining " + numberofPages + "  page(s).";


        if (numberofPages <= 0)
        {
            objectArray[0].SetActive(true);
            Time.timeScale = 0;
        }
        
    }

    
}
