using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace MelonCat.Test
{
	public class Question3 : MonoBehaviour
	{
		private readonly List<(int, int)> angles = new List<(int, int)>() { (-40, -20), (-20, 20), (20, 40) };
		[SerializeField] private List<AnimationCurve> curves;

		public void SetParticleAngle()
		{
			int randomParticle = ParticleAngle();
			Debug.Log($"ANGLE :: {randomParticle}");
		}

		private int ParticleAngle()
		{
			int randomAngle = UnityEngine.Random.Range(angles[0].Item1, angles[2].Item2);
			
			if (randomAngle >= angles[1].Item1 && randomAngle < angles[1].Item2)
			{
				return UnityEngine.Random.Range(angles[1].Item1, angles[1].Item2);
			}
			else
			{
				if (randomAngle < angles[1].Item1)
				{
					float dif = Mathf.Abs(angles[0].Item1 - angles[0].Item2);
					
					List<int> possibles = new List<int>();
					for (int i = 0; i < dif; i++)
					{
						float x = (Mathf.Abs(angles[0].Item2) - i) / dif;
						int counter = Mathf.RoundToInt(curves[0].Evaluate(x) * 100);
						for (int j = 0; j < counter; j++)
						{
							//Debug.Log("item" + (angles[0].Item2 - i)); //This Debug For Check Possibility Every Number
							possibles.Add((angles[0].Item2 - i));
						}
					}

					int index = UnityEngine.Random.Range(0, possibles.Count);
					return possibles[index];
				}
				else
				{
					float dif = Mathf.Abs(angles[2].Item2 - angles[2].Item1);
					
					List<int> possibles = new List<int>();
					for (int i = 0; i < dif; i++)
					{
						float x = (i) / dif;
						int counter = Mathf.RoundToInt(curves[1].Evaluate(x) * 100);
						for (int j = 0; j < counter; j++)
						{
							//Debug.Log("item" + (angles[2].Item1 + i)); //This Debug For Check Possibility Every Number
							possibles.Add((angles[2].Item1 + i));
						}
					}

					int index = UnityEngine.Random.Range(0, possibles.Count);
					
					return possibles[index];
				}
			}
		}
	}
}
