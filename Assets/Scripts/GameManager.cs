﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour {
	public GameObject player;
	public GameObject alien;
	public GameObject[] spawnPoints;

	public int maxAliensOnScreen;
	public int totalAliens;
	public float maxSpawnTime;
	public float minSpawnTime;
	public int aliensPerSpawn;

	private int aliensOnScreen = 0;
	private float generatedSpawnTime = 0;
	private float currentSpawnTime = 0;

	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void Update() {
		currentSpawnTime += Time.deltaTime;

		if (currentSpawnTime > generatedSpawnTime) {
			currentSpawnTime = 0;
			generatedSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);

			if (aliensPerSpawn > 0 && aliensOnScreen < totalAliens) {
				List<int> previousSpawnLocations = new List<int>();

				if (aliensPerSpawn > spawnPoints.Length) {
					aliensPerSpawn = spawnPoints.Length - 1;
				}

				aliensPerSpawn = (aliensPerSpawn > totalAliens ? aliensPerSpawn - totalAliens : aliensPerSpawn);

				for (int i = 0; i < aliensPerSpawn; i++) {
					if (aliensOnScreen < maxAliensOnScreen) {
						aliensOnScreen += 1;
						int spawnPoint = -1;

						while (spawnPoint == -1) {
							int randomNumber = Random.Range(0, spawnPoints.Length - 1);
							if (!previousSpawnLocations.Contains(randomNumber)) {
								previousSpawnLocations.Add(randomNumber);
								spawnPoint = randomNumber;

							}
						}
						GameObject spawnLocation = spawnPoints[spawnPoint];
						GameObject newAlien = Instantiate(alien) as GameObject;
						newAlien.transform.position = spawnLocation.transform.position;
						Alien alienScript = newAlien.GetComponent<Alien>();
						alienScript.target = player.transform;

						Vector3 targetRotation = new Vector3(player.transform.position.x, newAlien.transform.position.y, player.transform.position.z);
						newAlien.transform.LookAt(targetRotation);
					}
				}
			}
		}
	}
}
