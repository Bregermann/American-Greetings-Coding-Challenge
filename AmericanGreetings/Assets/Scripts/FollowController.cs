using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowController : MonoBehaviour
{
    public static int mover;
    private int whichWay;
    public GameObject[] follows;
    public GameObject target;
    public GameObject chaseMe;

    // Start is called before the first frame update
    private void Start()
    {
        mover = 80;
        whichWay = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (mover == 0)
        {
            whichWay = Random.Range(0, 9);
            mover = 80;
        }
        target = follows[whichWay];
        chaseMe.transform.position = target.transform.position;
    }

    private void FixedUpdate()
    {
        mover--;
    }
}