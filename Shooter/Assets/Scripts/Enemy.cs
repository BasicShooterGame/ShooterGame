using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Transform target;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(updatePath());
    }

    IEnumerator updatePath() {
        float refreshRate = 0.25f;
        while (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
            navMeshAgent.SetDestination(targetPosition);
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
