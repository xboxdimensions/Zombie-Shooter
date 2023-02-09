using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    [SerializeField] Timer timer1;
    public int TimeSeconds;
    // Start is called before the first frame update
    void Start()
    {
        timer1.SetDuration(TimeSeconds).Begin();
    }

    // Update is called once per frame
}
