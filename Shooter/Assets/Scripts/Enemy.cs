using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    [SerializeField] private Transform target;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        StartCoroutine(updatePath());
    }

    IEnumerator updatePath() {
        float refreshRate = 0.25f;
        while (true)
        {
            navMeshAgent.SetDestination(target.position);
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
