using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public GameObject[] Points;
    public int line = 0;
    float destination;

    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();        
    }

    void Update()
    {
        destination = Vector3.Distance(transform.position, Points[line].transform.position);
        if (destination < 1)
        {
            line++;
        }
        if (line == Points.Length)
        {
            line = 5;
        }
        agent.SetDestination(Points[line].transform.position);
    }
}
