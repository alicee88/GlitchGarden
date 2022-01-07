using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    int liveAttackers = 0;
    bool levelTimerFinished = false;

    public void AddAttacker()
    {
        liveAttackers++;
    }

    public void RemoveAttacker()
    {
        liveAttackers--;
        Debug.Log("REMOVING ATTACKER " + liveAttackers);

        if (levelTimerFinished && liveAttackers <= 0)
        {
            Debug.Log("WIN SCREEN!");
        }
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i].StopSpawning();
        }
    }
}
