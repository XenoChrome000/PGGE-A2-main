using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    PlayerSpawnPoints - Creates a list of spawn points, then selects one at random when called.
*/
public class PlayerSpawnPoints : MonoBehaviour
{
    public List<Transform> mSpawnPoints = new List<Transform>();

    public Transform GetSpawnPoint()
    {
        if (mSpawnPoints.Count == 0) return this.transform;
        return mSpawnPoints[Random.Range(0, mSpawnPoints.Count)].transform;
    }
}
