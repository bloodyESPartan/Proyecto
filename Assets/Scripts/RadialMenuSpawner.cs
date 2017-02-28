﻿using UnityEngine;
using System.Collections;

public class RadialMenuSpawner : MonoBehaviour {

    public static RadialMenuSpawner ins;
    public RadialMenu menuPrefab;


    void Awake()
    {
        ins = this;
    }
	
    public void SpawnMenu(Interactable obj)
    {
        RadialMenu newMenu = Instantiate(menuPrefab) as RadialMenu;
        newMenu.transform.SetParent(transform, false);
        newMenu.transform.position = Input.mousePosition;
        newMenu.label.text = obj.title.ToUpper();  //Para que ponga elnombre del objeto//
        newMenu.SpawnButtons(obj);
    }
}
