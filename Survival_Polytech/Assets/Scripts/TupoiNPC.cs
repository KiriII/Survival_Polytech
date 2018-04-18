using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class TupoiNPC : MonoBehaviour
{

    [Tooltip("How long NPC will stay in the new destination")]
    public float waitingTime = 1f;
    public Transform[] destinations;

    NavMeshAgent nav;
    Transform player;
    private bool newWay;
    private bool playerFollowing;


    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        SetRandomDestination();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        newWay = false;
        playerFollowing = false;
    }

    void Update()
    {
        if (!newWay && !playerFollowing && (nav.remainingDistance <= nav.stoppingDistance || nav.isStopped))
        {
            StartCoroutine(newRandomDestination(waitingTime));
            newWay = true;
        }
        else
        {
            if (playerFollowing)
                nav.SetDestination(player.position);
        }

    }

    private IEnumerator newRandomDestination(float value)
    {
        yield return new WaitForSeconds(value);
        SetRandomDestination();
        newWay = false;
    }

    private void SetRandomDestination()
    {
        nav.SetDestination(destinations[Random.Range(0, destinations.Length)].position);
    }

    private void SetDestination(int arrayIndex)
    {
        nav.SetDestination(destinations[arrayIndex].position);
    }

    private void SetCustomDestination(Transform newTarget)
    {
        nav.SetDestination(newTarget.position);
    }

    private void SetPlayerFollowing(bool isFollowing)
    {
        playerFollowing = isFollowing;
    }
}