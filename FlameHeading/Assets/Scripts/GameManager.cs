using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public enum GameState {
    READY, RUNNING, GAMEOVER
}
public class GameManager : MonoBehaviour {

    private static GameManager instance;
    public static GameManager getInstance () {
        if (!instance) {
            instance = GameObject.FindObjectOfType<GameManager>() as GameManager;
        }

        return instance;
    }

    public Text scoreText;
    public Slider hpSlider;
    public GameObject[] clouds;
    private GameState currentState;
    private int score;
    private int cursor;
	void Start () {
        currentState = GameState.READY;
        cursor = 0;
        UpdateScore(0);
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Z)) {
            ChangeState(GameState.RUNNING);
        }	
	}

    public void ChangeState (GameState state) {
        if (currentState == state) {
            return;
        }
        switch (state) {
            case GameState.RUNNING:
                StartCoroutine(UpdateCursor());
                StartCoroutine(RespawnCloud());
                break;
            case GameState.GAMEOVER:
                StopAllCoroutines();
                break;
        }
        currentState = state;
    }

    IEnumerator UpdateCursor () {
        while (true) {
            if (cursor >= clouds.Length) {
                break;
            }
            yield return new WaitForSeconds(10f);
            cursor++;
        }
        yield return null;
    }

    IEnumerator RespawnCloud () {
        while (true) {
            float xPos = cursor == clouds.Length-1 ? 0 : UnityEngine.Random.Range(-3, 3);
            Instantiate(clouds[cursor], new Vector3(xPos, 7, 0), Quaternion.identity);
            Debug.Log("Respawn!");
            if (cursor == clouds.Length -1) {
                break;
            }
            yield return new WaitForSeconds(3f);
        }
    }

    public void ResetStage () {
        UpdateScore(0);
        cursor = 0;
        currentState = GameState.READY;
    }

    public void UpdateScore (int _score) {
        score = _score;
        scoreText.text = "Score : " + Convert.ToString(_score);
    }

    public GameState CurrentState {
        get {
            return currentState;
        }

        set {
            currentState = value;
        }
    }


}
