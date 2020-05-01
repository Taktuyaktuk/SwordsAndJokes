using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject MobPrefab;

    [SerializeField]
    float AreaRadious = 5f;

    [SerializeField]
    float Duration = 5f;

    void Start()
    {
        StartCoroutine(SpawnMobCourtine());
    }

    IEnumerator SpawnMobCourtine()
    {
        while (true)
        {
            SpawnMob();
            yield return new WaitForSeconds(Duration);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, AreaRadious);
    }

    private void SpawnMob()
    {
        var mob = Instantiate(MobPrefab);
        mob.transform.position = transform.position + Random.insideUnitSphere * AreaRadious;
    }
}
