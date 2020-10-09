using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSwitcher : MonoBehaviour
{
    public GameObject[] shape;
    private int whichShape;

    private void Start()
    {
        whichShape = 1;
    }

    private void Update()
    {
    }

    public void ShapeSwitch()
    {
        shape[whichShape].SetActive(false);
        if (whichShape > -1 && whichShape < 2)
        {
            whichShape++;
        }
        else
        {
            whichShape = 0;
        }
        shape[whichShape].SetActive(true);
    }
}