using UnityEngine;
using System.Collections;

public class playerInteractor : MonoBehaviour
{
    [Header("Interaction")]
    [SerializeField] private float interactRadius = 2.5f;
    [SerializeField] private float viewAngle = 45f;
    [SerializeField] private LayerMask interactableLayers;
    [SerializeField] private KeyCode interactKey = KeyCode.E;

    [Header("No Interaction Feedback")]
    [SerializeField] private GameObject noInteractFeedback;
    [SerializeField] private float feedbackDuration = 3f;

    private playerController pController;

    private IInteractable currentInteractable;
    private IInteractable oldInteractable;

    private Animator anim;
    private Coroutine feedbackRoutine;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        pController = GetComponent<playerController>();
        noInteractFeedback.SetActive(false);
    }

    private void Update()
    {
        FindInteractable();
        UpdateUI();
        oldInteractable = currentInteractable;

        if (Input.GetKeyDown(interactKey))
        {
            if (currentInteractable != null)
            {
                anim.SetTrigger("petTrigger");
                pController.DisableMovement();
                currentInteractable.Interact();
            }
            else
            {
                OnInteractNothing();
            }
        }
    }

    private void OnInteractNothing()
    {
        anim.SetTrigger("callTrigger");
        pController.DisableMovement();
        if (noInteractFeedback == null)
            return;

        // Restart timer if already playing
        if (feedbackRoutine != null)
            StopCoroutine(feedbackRoutine);

        feedbackRoutine = StartCoroutine(NoInteractFeedbackRoutine());
    }

    private IEnumerator NoInteractFeedbackRoutine()
    {
        noInteractFeedback.SetActive(true);
        yield return new WaitForSeconds(feedbackDuration);
        noInteractFeedback.SetActive(false);
        feedbackRoutine = null;
    }

    private void FindInteractable()
    {
        Collider[] hits = Physics.OverlapSphere(
            transform.position,
            interactRadius,
            interactableLayers
        );

        currentInteractable = null;
        float closestDistance = float.MaxValue;

        foreach (Collider hit in hits)
        {
            IInteractable interactable = hit.GetComponent<IInteractable>();
            if (interactable == null) continue;

            Vector3 directionToObject = (hit.transform.position - transform.position).normalized;

            // Check if object is within view angle
            float angle = Vector3.Angle(transform.forward, directionToObject);
            if (angle > viewAngle * 0.5f)
                continue;

            float distance = Vector3.Distance(transform.position, hit.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                currentInteractable = interactable;
            }
        }
    }

    private void UpdateUI()
    {
        if (currentInteractable != null)
        {
            currentInteractable.SetUIActive(true);

            if (currentInteractable != oldInteractable && oldInteractable != null)
            {
                oldInteractable.SetUIActive(false);
            }
        }
        else if (oldInteractable != null)
        {
            oldInteractable.SetUIActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRadius);

        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(transform.position, transform.forward * interactRadius);
    }
}
