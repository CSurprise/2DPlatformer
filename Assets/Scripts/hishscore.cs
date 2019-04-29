using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class hishscore : MonoBehaviour
{
    public Text one, two, three, four, five;
    private string first = "1. ";
    private string second = "2. ";
    private string third = "3. ";
    private string fourth = "4. ";
    private string fifth = "5. ";
   

    // Start is called before the first frame update
    void Start()
    {
        one.text = first + PlayerPrefs.GetFloat("high score 1");
        two.text = second + PlayerPrefs.GetFloat("high score 2");
        three.text = third + PlayerPrefs.GetFloat("high score 3");
        four.text = fourth + PlayerPrefs.GetFloat("high score 4");
        five.text = fifth + PlayerPrefs.GetFloat("high score 5");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
