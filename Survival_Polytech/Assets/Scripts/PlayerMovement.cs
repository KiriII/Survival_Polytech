using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{

    public Interactable focus;

    Transform target; // for not static focuses
    NavMeshAgent mesh;

    void Start()
    {
        mesh = GetComponent<NavMeshAgent>();
    }


    void Update()
    {

        if (EventSystem.current.IsPointerOverGameObject())   // чтобы когда открыто что то на UI он не ходил при клике на UI
            return;

        if (target != null)
        {
            MoveToPoint(target.position);
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000) && Input.GetMouseButtonDown(0))
        {
            Interactable inter = hit.collider.GetComponent<Interactable>();
            if (inter != null)
            {
                mesh.SetDestination(transform.position);
                SetFocus(inter);
            }
            else
            {
                MoveToPoint(hit.point);
                RemoveFocus();
            }
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        mesh.stoppingDistance = 0f;     // for safety
        mesh.SetDestination(point);
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();
            focus = newFocus;
            FollowTarget(newFocus);
        }
        newFocus.OnFocused(transform);

        //MoveToPoint(newFocus.transform.position); не получится если объект в движении
    }

    private void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();
        focus = null;
        StopFollowing();
    }

    void FollowTarget(Interactable newTarget)
    {
        mesh.stoppingDistance = newTarget.radius * 0.8f;
        target = newTarget.interactTransform;
    }

    public void StopFollowing()
    {
        mesh.stoppingDistance = 0f;
        target = null;
    }
}
