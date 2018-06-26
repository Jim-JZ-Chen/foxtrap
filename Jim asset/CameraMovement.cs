using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed;
    public Animator ani;
    public Animator ani2;

    public Vector3[] stagePos;

    public Vector3[] cameraPos;

    // Use this for initialization
    void Start ()
    {
        if (ani !=null) { ani.SetBool("isOn", true); }
        if (ani2) { ani2.SetBool("isOn", true); }
        stagePos[0] = PlayerAvatar.inst.transform.position;
        PlayerAvatar.inst.transform.position = stagePos[Data.inst.currStage];
        transform.position = cameraPos[Data.inst.currStage];
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (PlayerAvatar.inst.transform.position.x >20 && this.transform.position.x < cameraPos[1].x && ani)
        {
            ani.SetBool("isOn", false);
            transform.Translate(Vector3.right* Time.deltaTime * speed);
            Data.inst.currStage = 1;
        }


        if (PlayerAvatar.inst.transform.position.x > 66 && this.transform.position.x < cameraPos[2].x && ani2)
        {
            ani2.SetBool("isOn", false);
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            Data.inst.currStage = 2;
        }


    }
}
