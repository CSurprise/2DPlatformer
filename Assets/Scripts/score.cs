using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;



public class score : MonoBehaviour
{
    public AudioSource sound, music;

    private float Score = 0F;
    public Text tracker;
    private string scoreWords = "Timer: ";
    private float time = 0f;
    
    private GameObject pause = null;


    private float defaultHighScore = 0f;
    // Start is called before the first frame update
    void Start()
    {
        startgame();
        time = Time.time;
        tracker.text = scoreWords + Score;
        pause = GameObject.Find("Panel");
        pause.SetActive(false);

        sound.volume = PlayerPrefs.GetFloat("SFXVol");
     
        music.volume = PlayerPrefs.GetFloat("musicVol");

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (!pause.activeInHierarchy)
            {
                PauseMe();
            }
            else
            {
                ContinueMe();
            }
        }
        if (pause.activeSelf)
        {

            sound.volume = PlayerPrefs.GetFloat("SFXVol");
            Debug.Log(sound.volume);
           
            music.volume = PlayerPrefs.GetFloat("musixVol");


            if (PlayerPrefs.GetInt("musicMute") == 1)
            {
                music.Pause();
            }
            else
            {
                music.UnPause();
            }
            if (PlayerPrefs.GetInt("SFXMute") == 1)
            {
                sound.Pause();
                
            }
            else
            {
                sound.UnPause();
            }
        }
        
        Score = Time.time - time;
       
        tracker.text = scoreWords + Score.ToString("F");

        if (!GameObject.Find("Ellie"))
        {
            Debug.Log(Score);
            if (Score > PlayerPrefs.GetFloat("high score 1"))
            {
              
                PlayerPrefs.SetFloat("high score 5", PlayerPrefs.GetFloat("high score 4"));
                PlayerPrefs.SetFloat("high score 4", PlayerPrefs.GetFloat("high score 3"));
                PlayerPrefs.SetFloat("high score 3", PlayerPrefs.GetFloat("high score 2"));
                PlayerPrefs.SetFloat("high score 2", PlayerPrefs.GetFloat("high score 1"));
                PlayerPrefs.SetFloat("high score 1", Score);
            }
            else if (Score > PlayerPrefs.GetFloat("high score 2"))
            {
             
                PlayerPrefs.SetFloat("high score 5", PlayerPrefs.GetFloat("high score 4"));
                PlayerPrefs.SetFloat("high score 4", PlayerPrefs.GetFloat("high score 3"));
                PlayerPrefs.SetFloat("high score 3", PlayerPrefs.GetFloat("high score 2"));
                PlayerPrefs.SetFloat("high score 2", Score);
            }
            else if (Score > PlayerPrefs.GetFloat("high score 3"))
            {
                PlayerPrefs.SetFloat("high score 5", PlayerPrefs.GetFloat("high score 4"));
                PlayerPrefs.SetFloat("high score 4", PlayerPrefs.GetFloat("high score 3"));
                PlayerPrefs.SetFloat("high score 3", Score);
            }
            else if (Score > PlayerPrefs.GetFloat("high score 4"))
            {
                PlayerPrefs.SetFloat("high score 5", PlayerPrefs.GetFloat("high score 4"));
                PlayerPrefs.SetFloat("high score 4", Score);
            }
            else if (Score > PlayerPrefs.GetFloat("high score 5"))
            {
                PlayerPrefs.SetFloat("high score 5", Score);
            }
   
            SceneManager.LoadScene("highscore");
        }

        if (!GameObject.Find("Elephant"))
        {
            SceneManager.LoadScene("highscore");
        }

       


    }

  


    private void startgame()
    {
        if (!PlayerPrefs.HasKey("high score 1"))
        { // Check to see if a high score is already saved
            PlayerPrefs.SetFloat("high score 1", defaultHighScore); // If it’s not, then save one
        }
        if (!PlayerPrefs.HasKey("high score 2"))
        { // Check to see if a high score is already saved
            PlayerPrefs.SetFloat("high score 2", defaultHighScore); // If it’s not, then save one
        }
        if (!PlayerPrefs.HasKey("high score 3"))
        { // Check to see if a high score is already saved
            PlayerPrefs.SetFloat("high score 3", defaultHighScore); // If it’s not, then save one
        }
        if (!PlayerPrefs.HasKey("high score 4"))
        { // Check to see if a high score is already saved
            PlayerPrefs.SetFloat("high score 4", defaultHighScore); // If it’s not, then save one
        }
        if (!PlayerPrefs.HasKey("high score 5"))
        { // Check to see if a high score is already saved
            PlayerPrefs.SetFloat("high score 5", defaultHighScore); // If it’s not, then save one
        }
    
     
        if (!PlayerPrefs.HasKey("musicVol"))
        { // Check to see if a high score is already saved
            PlayerPrefs.SetFloat("musicVol", 1f); // If it’s not, then save one
        }
        if (!PlayerPrefs.HasKey("SFXVol"))
        { // Check to see if a high score is already saved
            PlayerPrefs.SetFloat("SFXVol", 1f); // If it’s not, then save one
        }
        if (!PlayerPrefs.HasKey("musicMute"))
        { // Check to see if a high score is already saved
            PlayerPrefs.SetInt("musicMute", 1); // If it’s not, then save one
        }
        if (!PlayerPrefs.HasKey("SFXMute"))
        { // Check to see if a high score is already saved
            PlayerPrefs.SetInt("SFXMute", 1); // If it’s not, then save one
        }


    }
    private void PauseMe()
    {
        Time.timeScale = 0;
        pause.SetActive(true);
    }

    private void ContinueMe()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
    }

}
