using UnityEngine;
using System.Collections;

public class CloudController : MonoBehaviour {

    public float hp;
    public float speed;
	void Start () {
	
	}
	
	void Update () {
        transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
	}
    

    void OnTriggerEnter2D (Collider2D collider) {
        Debug.Log("Bullet!!");
        if (collider.CompareTag("Bullet")) {
            TakeDamage(collider.gameObject.GetComponent<BulletProperty>().damage);
            Destroy(collider.gameObject);
        }
    }

    void TakeDamage (float damage) {
        hp -= damage;

        if (hp <= 0) {
            Death();
        }
    }

    void Death () {
        Destroy(gameObject);
    }
}
