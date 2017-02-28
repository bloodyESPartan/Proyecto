using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class RadialButton : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler

{

    public Image circle;
    public Image icon;
    public string title;
    public RadialMenu myMenu;
    public float speed = 8f;

    Color defaultColor;

    public void Anim()
    {
        StartCoroutine(AnimateButtonIn()); 
    }

    IEnumerator AnimateButtonIn()
    {
        transform.localScale = Vector3.zero; //las opciones empiezan en una misma posicion//
        float timer = 0f; 
        while (timer < (1 / speed))
        {
           
            transform.localScale = Vector3.one * timer * speed;
            timer += Time.deltaTime;
            yield return null; //Aumentan segun el tiempo pasa//
        }
        transform.localScale = Vector3.one;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        myMenu.selected = this;
        defaultColor = circle.color;
        circle.color = Color.white;
          //Cuando pasas el raton por encima se pone blanco//
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        myMenu.selected = null;
        circle.color = defaultColor;
        //Cuando no esta el raton encima pilla el color normal//
    }
}


