using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject[] npcPrefab;
    public int spawnAmount;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        int prefabNum;
        int count = 0;
        while(count < spawnAmount)
        {
            prefabNum = Random.Range(0, npcPrefab.Length);
            GameObject obj = Instantiate(npcPrefab[prefabNum]);
            Transform child = transform.GetChild(Random.Range(0, transform.childCount - 1));
            obj.GetComponent<WaypointNav>().currentWaypoint = child.GetComponent<Waypoint>();
            obj.transform.position = child.position;

            yield return new WaitForEndOfFrame();

            count++;
        }
    }
}
