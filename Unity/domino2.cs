using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class domino2 : MonoBehaviour
{

	public float force = 100f;
	private bool hascollided = false; 
	private bool secondcollision = false;

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

	public Rigidbody rb; //Body of cube

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>(); //Initialize rb
		print("Angle is: " + transform.eulerAngles.x); //print angle (Debug)

		System.Array.Clear(omega, 0, N);
		System.Array.Clear(alpha, 0, N);
		System.Array.Clear(theta, 0, N);
	}

	// Update is called once per frame
	void Update()
	{
		if (hascollided) {
			
			print ("Theta is: " + theta [n]);
			print ("Unity angle is: " + transform.eulerAngles.x);




			if (theta [n] < Mathf.PI / 2) {
				alpha [n + 1] = ((1 / (Mathf.Pow (m, 2))) * (Force () * r) - (g * m * Distance (theta [n], l, T, H, n)));
				omega [n + 1] = omega [n] + alpha [n] * h;
				theta [n + 1] = theta [n] + omega [n] * h;

				if (theta [n + 1] < Mathf.PI / 2) {
					rb.transform.Rotate ((theta [n + 1] - theta [n]) * 180 / Mathf.PI, 0, 0);
				} else
					rb.transform.Rotate ((Mathf.PI / 2 - theta [n]) * 180 / Mathf.PI, 0, 0);
			} 

			else {

				theta [n + 1] = Mathf.PI / 2;
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

	float d;
	float Distance(float theta, float l, float T, float H, int n)
	{ 
		if (n == 0)
		{
			d = T / 2;
		}
		else if (theta > (Mathf.Atan(T / H)*180/Mathf.PI))
		{
			d = -l * Mathf.Sin(theta);
		}
		else
		{
			d = l * Mathf.Sin(theta);
		}

		return d;
	}

	void  OnCollisionEnter()
	{
		if (!hascollided) {
			hascollided = true;
			omega [n] = 0;
		}

	}


}
