using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public static float MAX_HP = 100;

    public GameObject bullet;
    public float hp;
    public float speed;

    private GameManager gameManager;

	void Start () {
        gameManager = GameManager.getInstance();
        InitPlayer();
	}

    public void InitPlayer () {
        hp = MAX_HP;
    }
	
	void Update () {
        if (gameManager.CurrentState == GameState.RUNNING) {
            float x = Input.GetAxis("Horizontal");
            transform.position += new Vector3(speed * Time.deltaTime * x, 0, 0);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.5f, 3.5f), transform.position.y, 0);

            if (Input.GetKeyDown(KeyCode.Z)) {
                Instantiate(bullet, transform.GetChild(0).position, Quaternion.identity);
            }
        }
	}


    public void TakeDamage (float damage) {
        if (hp <= 0) {
            Death();
        }
    }

    public void Death () {

    }

    void OnTriggerEnter2D (Collider2D collider) {
        if (collider.CompareTag("Cloud")) {
            TakeDamage(MAX_HP);
        }
    }
}
