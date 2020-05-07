using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Text scoreText;
    private Controls player;
    public Transform start;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Controls>();
        InvokeRepeating("RunTimer", 1, 1);  
	}
	
	 
	void RunTimer() {
		scoreText.text = (int.Parse(scoreText.text) - 1).ToString();
        if (scoreText.text == 0.ToString() ) {
        player.transform.position = start.position;
        player.GetComponent<Renderer>().enabled = true;
        player.enabled = true;
        scoreText.text = 30.ToString();                     
        }

	}
}
