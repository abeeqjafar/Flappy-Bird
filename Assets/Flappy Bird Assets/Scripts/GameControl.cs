using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour 
{
	public static GameControl instance;			
	public Text scoreText;						
	public GameObject gameOvertext;				
	private int score = 0;					
	public bool gameOver = false;	
	public float scrollSpeed = -1.5f;


	void Awake()
	{
		if (instance == null)
			instance = this;
		else if(instance != this)
			Destroy (gameObject);
	}

	void Update()
	{
		if (gameOver && Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")) 
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	public void BirdScored()
	{
		if (gameOver)	
			return;
		score++;
		scoreText.text = "Score: " + score.ToString();
        if (score%10 == 0)
        {
			scrollSpeed = scrollSpeed * 2;
        }
	}

	public void BirdDied()
	{
		gameOvertext.SetActive (true);
		gameOver = true;
	}
}
