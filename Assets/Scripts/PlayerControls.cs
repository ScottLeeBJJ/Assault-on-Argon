using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float throwSpeed = 20f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 7f;

    void Update()
    {
      ProcessTranslation();
      ProcessRotation();
    }

    void ProcessRotation()
    {
      // A quaternion represents two things. It has an x, y, and z component, which represents the axis about which a rotation will occur. It also has a w component, which represents the amount of rotation which will occur about this axis. In short, a vector, and a float.
      transform.localRotation = Quaternion.Euler(-30f, 30f, 0f); 
    }

    void ProcessTranslation()
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