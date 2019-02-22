using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class domino : MonoBehaviour {

	public int force = 100;

	public int m = 1;
	public float g = 9.82f;
	public int H = 2;
	public int B = 1;
	private float r = sqrt(Math.pow(H, 2) + Math.pow(B, 2));

	public int tTot = 10;
	public float h = 0.005f;
	private int N = (int)(tTot/ h);

	private float[] alpha = new float[N];
	private float[] omega = new float[N];
	private float[] theta = new float[N];

	private int n = 0;
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		for(double t = 0; t < tTot; t += h;)
		{
			a[n + 1] = ((1/(Math.pow(m,2)))*(force*r) - (g*m*Distance(theta, H, n)));
			omega[n + 1] = omega[n] + a[n]*h;
			theta[n + 1] = theta[n] + omega[n]*h;

			if (theta[n+1] >= (Mathf.PI/2))
			{
				theta[n+1] = (Mathf.PI/2);
				a[n + 1] = 0f;
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

	float Distance(float theta, int H, int n)
	{
		if(Time.deltaTime == 0)
		{
			return (float)H/2;
		}
		else
		{
			if(theta > (Math.PI/4))	
			{
				d = -((float)(H / 2) * Math.sin (theta));
			}
			else
			{
				if(theta > (Math.PI/4))	
				{
					d = ((float)(H/2) * Math.sin(theta));
				}

			}
		}
		return d;
	}