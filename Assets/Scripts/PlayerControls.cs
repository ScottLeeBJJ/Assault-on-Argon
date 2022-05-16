using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float throwSpeed = 20f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 7f;

    [SerializeField] GameObject[] lasers;

    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float positionPitchFactor = -2f;

    [SerializeField] float positionYawFactor = 2f;

    [SerializeField] float controlRollFactor = -20f;

    float xThrow;
    float yThrow;

    void Update()
    {
      ProcessTranslation();
      ProcessRotation();
      processFiring();
    }

    void ProcessRotation()
    {
      float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
      float pitchDueToControlThrow = yThrow * controlPitchFactor;

      float yawDueToPosition = transform.localPosition.x * positionYawFactor;

      float pitch = pitchDueToPosition + pitchDueToControlThrow;
      float yaw = yawDueToPosition;
      float roll = xThrow * controlRollFactor;

      // A quaternion represents two things. It has an x, y, and z component, which represents the axis about which a rotation will occur. It also has a w component, which represents the amount of rotation which will occur about this axis. In short, a vector, and a float.
      transform.localRotation = Quaternion.Euler(pitch, yaw, roll); 
    }

    void ProcessTranslation()
    {
      // the positioning of these variables is critical, will not work unless laid out like this

      xThrow = Input.GetAxis("Horizontal");     
      yThrow = Input.GetAxis("Vertical");

      float xOffset = xThrow * Time.deltaTime * throwSpeed;
      float yOffset = yThrow * Time.deltaTime * throwSpeed;

      float rawXPos = transform.localPosition.x + xOffset;
      float rawYPos = transform.localPosition.y + yOffset;

      float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
      float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);


      transform.localPosition = new Vector3 (clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void processFiring()
    {
      if (Input.GetButton("Fire1"))
      {
        ActivateLasers();
      }
      else
      {
        DeactivateLasers();
      }
    }

    void ActivateLasers()
    {
      foreach (GameObject laser in lasers)
      {
        laser.SetActive(true);
      }
    }

    void DeactivateLasers()
    {
      foreach (GameObject laser in lasers)
      {
        laser.SetActive(false);
      }
    }
}