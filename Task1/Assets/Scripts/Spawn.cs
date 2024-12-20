using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Spawn : MonoBehaviour
{
    float currentTime;
    public float startingTime = 10f;
    public Transform[] spawnpoints;
    public GameObject player;

    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private GameObject Timer;

    private bool hasSpawned = false; 

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        if (Timer.activeInHierarchy)
        {
            if (hasSpawned) return;

            currentTime -= Time.deltaTime;
            countdownText.text = currentTime.ToString("0");

            if (currentTime <= 0)
            {
                currentTime = 0;
                Timer.SetActive(false);
                SpawnPlayer();
                hasSpawned = true;
            }
        }
    }

    void SpawnPlayer()
    {
        int randomIndex = Random.Range(0, spawnpoints.Length);
        Transform chosenSpawnpoint = spawnpoints[randomIndex];

        Instantiate(player, chosenSpawnpoint.position, chosenSpawnpoint.rotation);

        Debug.Log($"Player spawned at spawn point: {chosenSpawnpoint.name}");
    }
}