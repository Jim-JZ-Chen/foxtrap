using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{
    public float range = 50f;
    new public ParticleSystem particleSystem;

    LineRenderer lineRenderer;
    ParticleSystem.ShapeModule shape;
    Vector3 endPoint;

    public GameObject hittedObj;

    public Transform pos;
    public GameObject g;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

        if (particleSystem != null)
        {
            shape = particleSystem.shape;
        }
    }

    void Update()
    {
//        
        RaycastHit hit;
        endPoint = pos.localPosition;
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            endPoint = transform.InverseTransformPoint(hit.point);
            // to previous hitted obj
            if (hittedObj != null && hittedObj != hit.collider.gameObject)
            {
                hittedObj.transform.GetChild(0).gameObject.SetActive(false);
                hittedObj = null;
                Debug.Log("previous hitted obj"+ this.transform.parent.gameObject.name);
            }

            
            //to new hitted obj
            if (hit.collider.gameObject.tag == "Player")
            {
                PlayerAvatar.inst.Die();
            }
            else if (hit.collider.tag == "trigger")
            {
                hit.collider.transform.GetChild(0).gameObject.SetActive(true);
                hittedObj = hit.collider.gameObject;
            }
            
        }

    
        if (particleSystem != null)
        {
            shape.radius = Mathf.Lerp(shape.radius, endPoint.magnitude / 2, Time.deltaTime);
            particleSystem.transform.localPosition = Vector3.Lerp(particleSystem.transform.localPosition, endPoint * 0.5f, Time.deltaTime);
        }
        //lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, endPoint);
    }


    private void OnDisable()
    {
        if (hittedObj != null)
        {
            hittedObj.transform.GetChild(0).gameObject.SetActive(false);
            hittedObj = null;
        }

    }
}
