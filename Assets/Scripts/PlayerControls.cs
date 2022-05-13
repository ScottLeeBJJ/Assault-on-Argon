using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float throwSpeed = 20f;

    void Update()
    {

      float xThrow = Input.GetAxis("Horizontal");     
      float yThrow = Input.GetAxis("Vertical");

      float xOffset = xThrow * Time.deltaTime * throwSpeed;
      float newXPos = transform.localPosition.x + xOffset;

      float yOffset = yThrow * Time.deltaTime * throwSpeed;
      float newYPos = transform.localPosition.y + yOffset;

      transform.localPosition = new Vector3 
      (newXPos, newYPos, transform.localPosition.z);
    }
}