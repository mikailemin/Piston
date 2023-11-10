using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateScrew : MonoBehaviour
{
    public float rotationDuration = 3.0f; 

    private void Start()
    {
      Vector3 tempp=Camera.main.transform.position;
        Camera.main.transform.DOLocalMove(new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y-2, Camera.main.transform.position.z + 2), 1f).OnComplete(() =>
        {
            transform.DORotate(new Vector3(0, 0, 1440), rotationDuration, RotateMode.LocalAxisAdd)
          .SetEase(Ease.Linear).OnComplete(() =>
          {
              Camera.main.transform.DOMove(tempp, 1f);
          });

          
        });
        
      
           
    }
}