using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class domino1 : MonoBehaviour
{
    private float force = 100f;

    private bool hascollided = false;
    private const float ANGLE = 1.4f; // angle where blocks stop
    public static float m = 0.00456f; //mass
    public static float g = 9.82f; //gravity
    public static float H = 0.04353f; // Height
    public static float B = 0.02156f; // Bredd
    public static float T = 0.00679f; // Thickness

    private float r = Mathf.Sqrt(Mathf.Pow(H, 2) + Mathf.Pow(B, 2)); //distance from pivit point to force applied
    private float l = Mathf.Sqrt(Mathf.Pow(H / 2, 2) + Mathf.Pow(T / 2, 2)); //distance from piviot point to center of mass

    public static int tTot = 10; // time for simulation
    public static float h = 0.0005f; // step size
    private static int N = (int)(tTot / h); // Total samples

    private float[] alpha = new float[N]; // create array for angular acceleration with N samples
    private float[] omega = new float[N]; // create array for angular velocity with N samples
    private float[] theta = new float[N]; // create array for angle with N samples

    private int n = 0;

    public Collider col;
    public Rigidbody rb; //Body of cube
    private bool hasBegun = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Initialize rb
        col = GetComponent<Collider>();

        System.Array.Clear(omega, 0, N);
        System.Array.Clear(alpha, 0, N);
        System.Array.Clear(theta, 0, N);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            hasBegun = true;
        }

        while (hasBegun)
        {

            if (theta[n] < ANGLE)
            {
                alpha[n + 1] = ((1 / (Mathf.Pow(m, 2))) * (Force() * r) - (g * m * Distance(theta[n], l, T, H, n)));
                omega[n + 1] = omega[n] + alpha[n] * h;
                theta[n + 1] = theta[n] + omega[n] * h;

                if (theta[n + 1] < ANGLE)
                {
                    rb.transform.Rotate(0, (theta[n + 1] - theta[n]) * 180 / Mathf.PI, 0);
                }
                else rb.transform.Rotate(0, (ANGLE - theta[n]) * 180 / Mathf.PI, 0);
            }

            else
            {
                theta[n + 1] = ANGLE;
                enabled = false;
            }
            n++;
        }

    }


    float Force()
    {
        if (Time.deltaTime > 1)
        {
            force = 0;
        }
        return force;
    }


    void OnCollisionEnter()
    {
        if (!hascollided)
        {
            hascollided = true;
            System.Array.Clear(omega, 0, N);
            Destroy(col);
        }
    }

    float d;
    float Distance(float theta, float l, float T, float H, int n)
    {
        if (n == 0)
        {
            d = T / 2;
        }
        else if (theta > (Mathf.Atan(T / H) * 180 / Mathf.PI))
        {
            d = -l * Mathf.Sin(theta);
        }
        else
        {
            d = l * Mathf.Sin(theta);
        }

        return d;
    }


}
