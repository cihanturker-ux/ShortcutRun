using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PosDown1st : MonoBehaviour
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
