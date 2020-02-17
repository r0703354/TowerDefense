﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    public Color hoverColor;

    [Header("Optional")]
    public GameObject turret;
    public Vector3 positionOffset;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }


    void OnMouseDown()
    {

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        } 

        if (buildManager.CanBuild)
        {
            return;
        }

        if(turret != null)
        {
            Debug.Log("Can't build there - TODO:display on screen");
            return;
        }

        buildManager.BuildTurretOn(this);

    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (buildManager.CanBuild)
        {
            return;
        }

        rend.material.color = hoverColor;

    }

 
    void OnMouseExit()
    {
        rend.material.color = startColor;    
    }
}
