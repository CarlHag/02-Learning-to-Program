using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicScript : ProcessingLite.GP21
{
    // Start is called before the first frame update
    public float scale;
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Background(0);
        for (int i = 0; i < 10; i++)
        {
            float a = i / scale;
            float b = 10/scale - a;

            if (i % 3 == 0) Stroke(0);
            else Stroke(100);
            Line(0, b, a, 0);

        }
    }
}
