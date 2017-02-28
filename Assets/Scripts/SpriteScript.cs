using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpriteScript : MonoBehaviour {

    public Transform target;
    float zOffset = 2;
    public float xOffset;
    float yOffset = -4;

    private Animator animator;
    public NavMeshAgent myAgent;

    // Use this for initialization
    void Start () {


        animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
       // Debug.Log (animator.GetInteger("Direction"));
       // Debug.Log("x: " + myAgent.velocity.x);
       // Debug.Log("z: " + myAgent.velocity.z);
        if (myAgent.velocity.x == 0)
        {
            animator.SetInteger("Direction", 0);
        }
        else if (myAgent.velocity.z > 0.4)
        {
            animator.SetInteger("Direction", 1);
        }
        else if (myAgent.velocity.z < -0.4)
        {
            animator.SetInteger("Direction", 2);
        }
        else if (myAgent.velocity.x > 0.4)
        {
            animator.SetInteger("Direction", 3);
        }
        else if (myAgent.velocity.x < -0.4)
        {
            animator.SetInteger("Direction", 4);
        }

    }

    private void LateUpdate()
    {

        transform.localPosition = new Vector3(target.localPosition.x + xOffset, target.localPosition.y + yOffset, target.localPosition.z + zOffset);

    }
}
