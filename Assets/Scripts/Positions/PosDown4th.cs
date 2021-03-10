using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PosDown4th : MonoBehaviour
{
    public GameObject positionDisplay;

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Position")
        {
            positionDisplay.GetComponent<Text>().text = "2nd";
        }
    }
}
