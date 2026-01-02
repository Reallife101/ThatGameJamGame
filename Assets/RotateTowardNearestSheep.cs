using UnityEngine;

public class RotateTowardNearestSheep : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;

    private void Update()
    {
        GameObject nearestSheep = FindNearestSheep();
        if (nearestSheep == null) return;

        Vector3 direction = nearestSheep.transform.position - transform.position;
        direction.y = 0f; // Y-axis only

        if (direction.sqrMagnitude < 0.01f) return;

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }

    private GameObject FindNearestSheep()
    {
        GameObject[] sheep = GameObject.FindGameObjectsWithTag("Sheep");

        GameObject closest = null;
        float closestDistance = float.MaxValue;

        foreach (GameObject s in sheep)
        {
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
