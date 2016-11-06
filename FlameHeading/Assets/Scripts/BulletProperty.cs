using UnityEngine;
using System.Collections;

public class BulletProperty : MonoBehaviour {

    public float speed;
    public float damage;
	void Start () {
        StartCoroutine(DestroyBullet());
	}
	
	void Update () {
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);
	}

    IEnumerator DestroyBullet() {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
        yield return null;
    }


}
