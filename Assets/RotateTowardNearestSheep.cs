using UnityEngine;

public class RotateTowardNearestSheep : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;

    [Header("Fallback Target")]
    [SerializeField] private Transform fallbackTarget;

    private void Update()
    {
        Transform target = GetTargetToLookAt();
        if (target == null) return;

        Vector3 direction = target.position - transform.position;
        direction.y = 0f; // Y-axis only

        if (direction.sqrMagnitude < 0.01f) return;

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }

    private Transform GetTargetToLookAt()
    {
        GameObject nearestSheep = FindNearestActiveSheep();

        if (nearestSheep != null)
            return nearestSheep.transform;

        return fallbackTarget;
    }

    private GameObject FindNearestActiveSheep()
    {
        GameObject[] sheep = GameObject.FindGameObjectsWithTag("Sheep");

        GameObject closest = null;
        float closestDistance = float.MaxValue;

        foreach (GameObject s in sheep)
        {
            ChasePlayerNavMesh chase = s.GetComponent<ChasePlayerNavMesh>();

            if (chase == null || chase.enabled)
                continue;

            float distance = Vector3.Distance(transform.position, s.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closest = s;
            }
        }

        return closest;
    }
}
