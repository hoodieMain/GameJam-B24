using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    private float spawnTimer;
    // spawnFrequency controls, in seconds, how frequently lemmings are spawned
    public int spawnFrequency;
    public int holesNum;
    private GameObject chosenHole;

    void Start()
    {
        spawnTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer >= spawnFrequency) {
            spawnTimer = 0;
            // chooses hole (randomly), then spawns a lemming there. this relies on maintaining the Hole naming convention of Hole0, Hole1 etc!
            chosenHole = GameObject.Find("Hole" + (Random.Range(0, holesNum)));
            chosenHole.GetComponent<Hole>().spawnLemming();
        }
    }
}
