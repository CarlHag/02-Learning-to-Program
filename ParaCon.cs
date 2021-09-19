using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParaCon : ProcessingLite.GP21
{
    class Parabolic
    {
        public static List<Parabolic> parabolics = new List<Parabolic>();
        public float x1;
        public float x2;
        public float y1;
        public float y2;
        public float nexusX;
        public float nexusY;
        public int lines;
        public Parabolic(float x1, float y1, float x2, float y2, float nexusX, float nexusY, int lines)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.nexusX = nexusX;
            this.nexusY = nexusY;
            this.lines = lines;
            parabolics.Add(this);
        } 
    }
    private void draw(Parabolic parabolic, System.Drawing.Color c1, System.Drawing.Color c2, System.Drawing.Color c3, int j)
    {
        float x1 = parabolic.x1;
        float x2 = parabolic.x2;
        float y1 = parabolic.y1;
        float y2 = parabolic.y2;
        float nexusY = parabolic.nexusY;
        float nexusX = parabolic.nexusX;
        int lines = parabolic.lines;
        if (lines < 0) lines = 0;
        for (int i = 0; i < lines; i++)
        {
            if ((i+j) % 3 == 0) Stroke(c1.R, c1.G, c1.B);
            else if((i + j + 1) % 3 == 0) Stroke(c2.R, c2.G, c2.B);
            else Stroke(c3.R, c3.G , c3.B);
            float _x1 = x1 * (1 - (float)i / lines) + nexusX;
            float _y1 = y1 * (1 - (float)i / lines) + nexusY;
            float _x2 = x2 * ((float)i / lines) + nexusX;
            float _y2 = y2 * ((float)i / lines) + nexusY;
            Line(_x1, _y1, _x2, _y2);
        }
    }
    private void Start()
    {
        new Parabolic(0, 4, 3, 3, 5, 5, 10);
        new Parabolic(3, 3, 4, 0, 5, 5, 10);
        new Parabolic(4, 0, 3, -3, 5, 5, 10);
        new Parabolic(3, -3, 0, -4, 5, 5, 10);
        new Parabolic(0, -4, -3, -3, 5, 5, 10);
        new Parabolic(-3, -3, -4, 0, 5, 5, 10);
        new Parabolic(-4, 0, -3, 3, 5, 5, 10);
        new Parabolic(-3, 3, 0, 4, 5, 5, 10);
        Background(100);
        StartCoroutine(draw());
    }
    IEnumerator draw()
    {
        int i = 0;
        while (true)
        {
            foreach (Parabolic p in Parabolic.parabolics) draw(p, System.Drawing.Color.Red, System.Drawing.Color.Orange, System.Drawing.Color.Yellow, i);
            i++;
            yield return new WaitForSeconds(0.25f);
        }
    }
}
