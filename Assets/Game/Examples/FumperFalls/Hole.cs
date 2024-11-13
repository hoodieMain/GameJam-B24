using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public GameObject lemmingPrefab;

    public void spawnLemming()
    {
        Instantiate(lemmingPrefab, transform.position, Quaternion.identity);
    }
}
