using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonGhost : MonoBehaviour
{
    [HideInInspector]
    public MeshRenderer meshRenderer;
    Color32 startColor = new Color32(110, 110, 110, 0);
    Color32 endColor = new Color32(40, 40, 40, 0);
    float duration = .3f;


    // Start is called before the first frame update
    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    public void GiveEffect()
    {
      
    
        meshRenderer.material.DOColor(startColor, "_EmissionColor", duration)
            .OnComplete(() =>
            {
                meshRenderer.material.DOColor(endColor, "_EmissionColor", duration)
                    .OnComplete(() => ReverseEffect());
            });
    }

    void ReverseEffect()
    {
       

        meshRenderer.material.DOColor(startColor, "_EmissionColor", duration)
            .OnComplete(() =>
            {
                meshRenderer.material.DOColor(endColor, "_EmissionColor", duration)
                    .OnComplete(() =>
                    {
                        gameObject.SetActive(false);
                        ColliderDedector.Instance.isShiine=false;
                        });
            });
    }


}
