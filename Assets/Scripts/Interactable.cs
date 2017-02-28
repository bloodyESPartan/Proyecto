using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour {
    [System.Serializable]
    public class Action
    {
        public Color color;
            public Sprite sprite;
        public string title;
    }

    public string title;
    public Action[] options;

    void Start()
    {
        if (title == "" || title == null)
        {
            title = gameObject.name;
        }
    }

    void OnMouseDown()//Decirle al canvas que aparezca el menu//
    {
        RadialMenuSpawner.ins.SpawnMenu(this);
    }
}
