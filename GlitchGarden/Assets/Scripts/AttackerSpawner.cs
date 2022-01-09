using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnTime = 1f;
    [SerializeField] float maxSpawnTime = 3.5f;
    [SerializeField] Attacker[] attackerPrefabArray;

    bool spawn = true;

    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
         //   if (spawn)
            {
                SpawnAttacker();
            }
        }
    }

    private void SpawnAttacker()
    {
        int arrayIndex = Random.Range(0, attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[arrayIndex]);
    }

    private void Spawn(Attacker attackerToSpawn)
    {
        Attacker newAttacker = Instantiate(attackerToSpawn, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }

    public void StopSpawning()
    {
        spawn = false;
    }
}
