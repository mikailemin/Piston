using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoved : MonoBehaviour
{
    public Transform target; // Objeyi referans almak için kullanılacak transform
    public float rotationSpeed = 5f; // Kamera dönüş hızı

    void Update()
    {
        if (Input.GetMouseButton(0)&&!ColliderDedector.Instance.isClicked)
        {
            float horizontalInput = Input.GetAxis("Mouse X");
            float verticalInput = Input.GetAxis("Mouse Y");

        
            RotateCameraHorizontal(horizontalInput);

           
               
               RotateCameraVertical(verticalInput);
            
           
        }
    
    }

    void RotateCameraHorizontal(float horizontalInput)
    {
       
        transform.RotateAround(target.position, Vector3.up, horizontalInput * rotationSpeed);
    }

    void RotateCameraVertical(float verticalInput)
    {
      
            transform.RotateAround(target.position, transform.right, verticalInput * rotationSpeed);
           
        
      
    }
}
