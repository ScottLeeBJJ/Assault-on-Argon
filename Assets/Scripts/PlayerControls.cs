using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float throwSpeed = 20f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 10f;

    void Update()
    {

      // the positioning of these variables is critical, will not work unless laid out like this

      float xThrow = Input.GetAxis("Horizontal");     
      float yThrow = Input.GetAxis("Vertical");

      float xOffset = xThrow * Time.deltaTime * throwSpeed;
      float yOffset = yThrow * Time.deltaTime * throwSpeed;

      float rawXPos = transform.localPosition.x + xOffset;
      float rawYPos = transform.localPosition.y + yOffset;

      float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
      float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);


      transform.localPosition = new Vector3 (clampedXPos, clampedYPos, transform.localPosition.z);
    }
}