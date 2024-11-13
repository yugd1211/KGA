using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public LayerMask targetLayer;

    private Renderer childRenderer;


    private void Awake()
    {
        childRenderer = GetComponentInChildren<Renderer>();
        childRenderer.enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, long.MaxValue, targetLayer))
            {
                transform.position = hit.point;
                transform.GetChild(0).DOLocalJump(Vector3.zero, 3f, 1, 0.5f)
                    .OnStart(() =>  childRenderer.enabled = true)
                    .OnComplete(() => childRenderer.enabled = false).
                    SetEase(Ease.InOutBack);
            }
        }
    }
}
