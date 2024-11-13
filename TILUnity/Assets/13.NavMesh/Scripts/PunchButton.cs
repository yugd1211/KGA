using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PunchButton : MonoBehaviour
{
    private Button button;
    private Tweener punchTween;

    private void Awake()
    {
        button = GetComponent<Button>();
        // button.onClick.AddListener(Punch);
        button.onClick.AddListener(Shake);
    }


    private void Punch()
    {
        if (punchTween != null)
            punchTween.Complete();
        Vector3 punchSize = new Vector3(0.1f, 0.1f, 0.1f);
        
        punchTween = transform.DOPunchScale(punchSize, 0.5f);
    }
    
    
    private void Shake()
    {
        if (punchTween != null)
            punchTween.Complete();
        
        punchTween = transform.DOShakePosition(0.5f, strength:10, snapping:true);
    }
    
}
