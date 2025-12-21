using UnityEngine;
using UnityEngine.AI;

public class ChasePlayerNavMesh : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float stopRadius = 2f;

    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > stopRadius)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
        else
        {
            agent.isStopped = true;
        }
    }
}
