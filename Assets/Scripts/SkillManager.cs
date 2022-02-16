using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static float forceForPins;
    public static float verticalForce, horizontalForce;
    private void Start()
    {
        horizontalForce = 5;
        verticalForce = 500;
        forceForPins = 1;
    }
    public void OnBeginnerClick()
    {
        forceForPins = 1;
    }
    public void OnIntermediateClick()
    {
        forceForPins = 2;
        horizontalForce = 7;
    }
    public void OnAdvancedClick()
    {
        forceForPins = 5;
        horizontalForce = 10;
    }
}
