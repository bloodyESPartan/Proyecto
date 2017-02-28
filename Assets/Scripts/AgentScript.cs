using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour {

	private NavMeshAgent agent;
    public exampleUI diagUI;

    // Use this for initialization
    public void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	public void Update () {

        //Only allow player to move and turn if there are no dialogs loaded
        /* if (!diagUI.dialogue.isLoaded)
         {
             transform.Rotate(0, Input.GetAxis("Mouse X") * 5, 0);
             float move = Input.GetAxisRaw("Vertical");
             transform.position += transform.forward * 5 * move * Time.deltaTime;
         }*/

        if (diagUI.dialogue.isLoaded && Input.GetMouseButtonDown(0))
        {
            diagUI.NextNode();
        }



        if (Input.GetMouseButtonDown(1))
        {

            MoverPersonaje();

        }
    }

    public void MoverPersonaje()
    {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider.tag == "Ground")
                {

                    agent.SetDestination(hit.point);

                }

            }

            
    }

    public void TryInteract( /*VIDE_Assign assigned*/)
    {
        // RaycastHit rHit;

        //  if (Physics.Raycast(transform.position, transform.forward, out rHit, 2))
        //  {
        //In this example, we will try to interact with any collider the raycast finds

        //Lets grab the NPC's DialogueAssign script... if there's any
        VIDE_Assign assigned;
        //  if (rHit.collider.GetComponent<VIDE_Assign>() != null)
        assigned = GameObject.Find("NPC_Charlie").GetComponent<VIDE_Assign>();
        //  else return;

        if (!diagUI.dialogue.isLoaded)
        {
            //... and use it to begin the conversation
            diagUI.Begin(assigned);

        }
        else
        {
            //If conversation already began, let's just progress through it
            diagUI.NextNode();
        }

        // }
    }

    

}
