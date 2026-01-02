using UnityEngine;
using UnityEngine.AI;

public class ChasePlayerNavMesh : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float stopRadius = 2f;
    [SerializeField] private float rotationSpeed = 8f;

    private NavMeshAgent agent;
    private Animator anim;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();

        // Let us control rotation manually
        agent.updateRotation = false;
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > stopRadius)
        {
            agent.isStopped = false;
            anim.SetBool("isMoving", true);
            agent.SetDestination(player.position);
        }
        else
        {
            agent.isStopped = true;
            anim.SetBool("isMoving", false);
        }

        FacePlayer();
    }

    private void FacePlayer()
    {
        Vector3 direction = player.position - transform.position;
        direction.y = 0f; // Y-axis only

        if (direction.sqrMagnitude < 0.001f)
            return;

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }
}
