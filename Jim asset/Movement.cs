using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public bool isToA;
    public Transform posA;
    public Transform posB;
    public float stopDistance;
    public Rigidbody rig;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isToA)
        {
            if (Vector3.Distance(rig.transform.position, posA.position) > stopDistance)
            {
                rig.transform.position = Vector3.MoveTowards(rig.transform.position, posA.position, speed * Time.deltaTime);
            }
            else
            {
                isToA = false;
            }
        }
        else
        {
            if (Vector3.Distance(rig.transform.position, posB.position) > stopDistance)
            {
                rig.transform.position = Vector3.MoveTowards(rig.transform.position, posB.position, speed * Time.deltaTime);
            }
            else
            {
                isToA = true;
            }
        }

		//this.transform.Translate()
            
	}
}
