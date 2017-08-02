using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour {

    [SerializeField]
    private Button startButton;

    [SerializeField]
    private Button exitButton;

	// Use this for initialization
	void Start () {
        Button start = startButton.GetComponent<Button>();
        start.onClick.AddListener(startGame);

        Button exit = exitButton.GetComponent<Button>();
        exit.onClick.AddListener(exitGame);
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void startGame() {
        Debug.Log("the start button has been clicked");
        SceneManager.LoadScene("FirstLevel");
    }

    private void exitGame() {
        Debug.Log("game has been exited");
        Application.Quit();
    }
}
