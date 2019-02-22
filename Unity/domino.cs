using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class domino : MonoBehaviour
{

    public float force = 0.005f;

    public float m = 0.00456f;
    public float g = 9.82f;
    public static float H = 0.04353f;
    public static float B = 0.02156f;
    public static float T = 0.00679f;
    private float r = Mathf.Sqrt(Mathf.Pow(H, 2) + Mathf.Pow(B, 2));

    public static int tTot = 1;
    public static float h = 0.0005f;
    private static int N = (int)(tTot / h);

    private float[] alpha = new float[N];
    private float[] omega = new float[N];
    private float[] theta = new float[N];

    private int n = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       

            alpha[n + 1] = ((1 / (Mathf.Pow(m, 2))) * (force * r) - (g * m * Distance(theta[n], H, n)));
            omega[n + 1] = omega[n] + alpha[n] * h;
            theta[n + 1] = theta[n] + omega[n] * h;

            if (theta[n + 1] >= (Mathf.PI / 2))
            {
                theta[n + 1] = (Mathf.PI / 2);
                alpha[n + 1] = 0f;
                omega[n + 1] = 0f;

            }
            n++;
        
    }

    void Force()
    {
        if (Time.deltaTime > 0.1)
        {
            force = 0;
        }
    }
    float d;
    float Distance(float theta, float H, int n)
    {

        if (Time.deltaTime == 0)
        {
            d = (float)H / 2;
        }
        else
        {
            if (theta > (Mathf.PI / 4))
            {
                d = -((float)(H / 2) * Mathf.Sin(theta));

            }
            else
            {
                if (theta > (Mathf.PI / 4))
                {
                    d = ((float)(H / 2) * Mathf.Sin(theta));

                }
            }
        }
        return d;
    }
        
}