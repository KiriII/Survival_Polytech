using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class move : MonoBehaviour {

    public interaction focus;

    Transform target; // for not static focuses
    NavMeshAgent mesh; 
	
	void Start () {
        mesh = GetComponent<NavMeshAgent>();
	}
	
	
	void Update () {

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
            interaction inter = hit.collider.GetComponent<interaction>();
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
        mesh.SetDestination(point);
    }

    void SetFocus(interaction newFocus)
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
        if  (focus != null)
        focus.OnDefocused();
        focus = null;
        StopFollowing();
    }

    void FollowTarget(interaction newTarget)
    {
        mesh.stoppingDistance = newTarget.radius* 0.8f;
        target = newTarget.interactTransform;
    } 

    void StopFollowing()
    {
        mesh.stoppingDistance = 0f;
        target = null;
    }
}
