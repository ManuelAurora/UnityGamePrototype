using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
	public GameObject bulletPrefab;
	public Transform launchPosition;

	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void Update() {
		
	}

	private void firebullet() {
		GameObject bullet = Instantiate(bulletPrefab) as GameObject;
		bullet.transform.position = launchPosition.position;
		bullet.GetComponent<Rigidbody>().velocity = transform.parent.forward * 400;
	}
}
