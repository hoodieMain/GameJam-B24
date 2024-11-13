using System.Collections;
using System.Collections.Generic;
using Game.MinigameFramework.Scripts.Framework;
using Game.MinigameFramework.Scripts.Framework.Input;
using Game.MinigameFramework.Scripts.Framework.PlayerInfo;
using UnityEngine;

public class LemmingUnalive : MonoBehaviour
{

    public GameObject manager;
    private int pawnID;
    // in seconds
    public int lifespan = 3; 

    private void Start ()
    {
        manager = GameObject.Find("FumperFallsManager");
        Destroy(gameObject, lifespan);
    }

    private void OnTriggerEnter(Collider other)
    {
        //this can be set later to logic to check the identity of a shot -- all Increment needs is to be passed a number 0-3
        Pawn pawn = other.GetComponent<Pawn>();
        pawnID = pawn.playerIndex;
        manager.GetComponent<ExampleGameManager>().Increment(pawnID);

        Destroy(gameObject);
    }
}
