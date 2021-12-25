using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace MelonCat.Test
{
	public class Question3 : MonoBehaviour
	{
		private readonly List<(float, float)> angles = new List<(float, float)>() { (-40f, -20f), (-20f, 20f), (20f, 40f) };
		

		public void SetParticleAngle()
		{
			float randomParticle = ParticleAngle();
			Debug.Log($"ANGLE :: {randomParticle}");
		}

		private float ParticleAngle()
		{
			float randomAngle = UnityEngine.Random.Range(angles[0].Item1, angles[2].Item2);

			if (randomAngle >= angles[1].Item1 && randomAngle <= angles[1].Item2)
			{
				return UnityEngine.Random.Range(angles[1].Item1, angles[1].Item2);
			}
			else
			{
				if (randomAngle < angles[1].Item1)
				{
					float dif = Mathf.Abs(angles[0].Item1 - angles[0].Item2);
					float rad = Mathf.Atan(100f/dif);
					float hypotenuse = Mathf.Sqrt(Mathf.Pow(dif, 2) + Mathf.Pow(100, 2));
					
					float random = UnityEngine.Random.Range(0, hypotenuse);
					float angle = angles[1].Item1 - random * (Mathf.Cos(rad));
					return angle;
				}
				else
				{
					float dif = Mathf.Abs(angles[2].Item2 - angles[2].Item1);
					float rad = Mathf.Atan(100f/dif);
					float hypotenuse = Mathf.Sqrt(Mathf.Pow(dif, 2) + Mathf.Pow(100, 2));
				
					float random = UnityEngine.Random.Range(0, hypotenuse);
					float angle = angles[1].Item2 + (random * Mathf.Cos(rad));
					return angle;
				}
			}
		}
	}
}
