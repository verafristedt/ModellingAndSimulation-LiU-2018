using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class domino : MonoBehaviour {

	public int force = 100;

	public float m = 1f;
	public float g = 9.82f;
	public static float H = 2f;
	public static float B = 1f;
	private float r = Mathf.Sqrt(Mathf.Pow(H, 2) + Mathf.Pow(B, 2));

	public static int tTot = 10;
	public static float h = 0.005f;
	private static int N = (int)(tTot/ h);

	private float[] alpha = new float[N];
	private float[] omega = new float[N];
	private float[] theta = new float[N];

	private int n = 0;
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		for(double t = 0; t < tTot; t += h)
		{
			alpha[n + 1] = ((1/(Mathf.Pow(m,2)))*(force*r) - (g*m*Distance(theta[n], H, n)));
			omega[n + 1] = omega[n] + alpha[n]*h;
			theta[n + 1] = theta[n] + omega[n]*h;

			if (theta[n+1] >= (Mathf.PI/2))
			{
				theta[n+1] = (Mathf.PI/2);
				alpha[n + 1] = 0f;
				omega[n + 1] = 0f;
				break;
			}
			n++;
		}
	}

	void Force(){
		if(Time.deltaTime > 0.1)
		{			
			force = 0;
		}
	}
	float d;
	float Distance(float theta, float H, int n)
	{
		
		if(Time.deltaTime == 0)
		{
			d = (float)H/2;
		}
		else
		{
			if(theta > (Mathf.PI/4))	
			{
				d = -((float)(H / 2) * Mathf.Sin (theta));

			}
			else
			{
				if(theta > (Mathf.PI/4))	
				{
					d = ((float)(H/2) * Mathf.Sin(theta));
				
				}
			}
		}
		return d;
	}
}