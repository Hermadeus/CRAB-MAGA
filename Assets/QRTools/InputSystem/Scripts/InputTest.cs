using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QRTools.Inputs;

public class InputTest : MonoBehaviour
{
    public ButtonInput b;

    private void Update()
    {
        if (b.ReturnValue())
            b.inputEvent.Raise();
    }

    public void Jump()
    {
        Debug.Log("Jump");
    }
}
