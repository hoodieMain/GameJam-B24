using System;
using System.Collections;
using System.Collections.Generic;
using Game.MinigameFramework.Scripts.Framework;
using Game.MinigameFramework.Scripts.Framework.Input;
using Game.MinigameFramework.Scripts.Framework.PlayerInfo;
using UnityEngine;

public class ExampleGameManager : MonoBehaviour {
    public float duration = 30;
    public float timer = 0;

    public float score0 = 0;
    public float score1 = 0;
    public float score2 = 0;
    public float score3 = 0;
    private float max;

    private List<Player> players = new();

    MinigameManager.Ranking ranking = new();


    private void Start() {
        players.AddRange(PlayerManager.players);

        //if not starting in editor (or if all players are bound ahead of time)
        // stop time + player input
        // 3 2 1 countdown
        // start time + player input
    }

    // i don't think our game has player death? 
    /*   private void OnTriggerEnter(Collider other) {
           Pawn pawn = other.GetComponent<Pawn>();
           if(pawn != null) {
               KillPlayer(pawn);
           }
       }


       private void KillPlayer(Pawn pawn) {
           print($"Player Index: {pawn.playerIndex}");
           if(pawn.playerIndex < 0) return;


           Player player = PlayerManager.players[pawn.playerIndex];
           alivePlayers.Remove(player);
           ranking.AddFromEnd(player.playerIndex); // add player to lowest available rank

           if (alivePlayers.Count <= 1) {
               StopMinigame();
           }
    }
    */

    public void Increment(int playerID)
    {
        if(playerID == 0) {
            score0++;
        }
        else if (playerID == 1)
        {
            score1++;
        }
        else if (playerID == 2)
        {
            score2++; 
        }
        else
        {
            score3++;
        }
    }

    private void Update() {
    timer += Time.deltaTime;
    if (timer >= duration)
    {
        for (int i = 0; i < 4; i++) {
            // there is almost definitely a better way to do this but whatever this is what i can write in 10 minutes
            // this means ties are broken by player order (if all players get 0 points, player 1 beats 2 beats 3 beats 4) 
            max = Mathf.Max(score0, score1, score2, score3);
            if (max == score0)
            {
                score0 = -1;
                ranking.AddFromStart(0);
            }
            else if (max == score1)
            {
                score1 = -1;
                ranking.AddFromStart(1);
            }
            else if (max == score2)
            {
                score2 = -1;
                ranking.AddFromStart(2);
            }
            else
            {
                score3 = -1;
                ranking.AddFromStart(3);
            }
        }
        StopMinigame();
    }
}

    private void StopMinigame() {
        StartCoroutine(EndMinigame());
    }
    
    IEnumerator EndMinigame() {
        // "FINISH" ui
        yield return new WaitForSeconds(2);
        MinigameManager.instance.EndMinigame(ranking);
    }
    
    
}
