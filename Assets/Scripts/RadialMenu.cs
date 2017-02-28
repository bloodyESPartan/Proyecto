using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.AI;

public class RadialMenu : MonoBehaviour {
    public Text label;
    public RadialButton buttonPrefab;
    public RadialButton selected;
    public exampleUI diagUI;
    public AgentScript myAgent;
    public VIDE_Data dialogue2;

    // Use this for initialization


 

    public void SpawnButtons (Interactable obj) {
        StartCoroutine(AnimateButtons(obj));  //Animar las opciones//
       
	}

    IEnumerator AnimateButtons (Interactable obj)
    {
        for (int i = 0; i < obj.options.Length; i++)

        {

            RadialButton newButton = Instantiate(buttonPrefab) as RadialButton;
            newButton.transform.SetParent(transform, false);
            float theta = (2 * Mathf.PI / obj.options.Length) * i;
            float xPos = Mathf.Sin(theta);
            float Ypos = Mathf.Cos(theta);
            newButton.transform.localPosition = new Vector3(xPos, Ypos, 0f) * 100f;  //posicion respecto al centro//

            newButton.circle.color = obj.options[i].color;
            newButton.icon.sprite = obj.options[i].sprite;
            newButton.title = obj.options[i].title;
            newButton.myMenu = this;//caracterisiticas de las opciones//
            newButton.Anim();
            yield return new WaitForSeconds(0.06f); //animacion de salida//


        }
    }

  

    public void Update()
    {
        if (Input.GetMouseButtonUp(0)) 
        {
   
            

            if (selected)
            {
                Debug.Log (selected.title + " was selected!");  //para saber si detecta la opción//

                myAgent = GameObject.FindGameObjectWithTag("Prota").GetComponent<AgentScript>();
                
                Debug.Log(myAgent);
                myAgent.MoverPersonaje();
            




                if (selected.title == "talk")
                {
                    Debug.Log(selected.title + " VAMOS PROGRESANDO COÑO!");  //para saber si detecta la opción//
                                                                             

                   // VIDE_Assign assigned;
                   // assigned = GameObject.Find("ElaineMenu").AddComponent<VIDE_Assign>();
                 //   Debug.Log("ASSIGNED: " + assigned);
                 // diagUI.Begin(assigned);
                //   GameObject x = GameObject.Find("NPC_Charlie");
                 //   dialogue2 = x.AddComponent<VIDE_Data>();
                 //   Debug.Log("DIALOGUE: " + assigned);
                    //myAgent.TryInteract(assigned);
                    // dialogue.BeginDialogue(GetComponent<VIDE_Assign>());
                //    Debug.Log("ASSIGNED2: " + assigned);
                    //myAgent.OnGUI(dialogue);
                    myAgent.TryInteract(/*dialogue.GetComponent<VIDE_Assign>()*/);
                  /*  assigned = GameObject.Find("NPC_Charlie").GetComponent<VIDE_Assign>();

                    if (!diagUI.dialogue.isLoaded)
                    {
                        
                        //... and use it to begin the conversation
                        diagUI.Begin(assigned);
                        while (diagUI.dialogue.isLoaded)
                        {

                        
                            if (Input.GetMouseButtonDown(0))
                        {

                            diagUI.NextNode();

                        }
                        }
                    }
                    else
                    {
                        //If conversation already began, let's just progress through it
                        diagUI.NextNode();
                    }*/


                }
            }
   

            Destroy(gameObject);

        }
    }


}
