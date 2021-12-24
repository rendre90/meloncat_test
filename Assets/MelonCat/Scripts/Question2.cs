using System;
using System.Net.Mime;
using UnityEngine;

namespace MelonCat.Test
{
	public class Question2 : MonoBehaviour
	{
		[SerializeField] private Camera cam;
		[SerializeField] private GameObject cubeObj;
		[SerializeField] private int size = 2;
		[SerializeField] private Texture2D baseTexture;
		[SerializeField] private Material drawMaterial;

		private Texture2D generatedTexture;
		[SerializeField] private Color color = Color.black;

		private void Start()
		{
			SetUpDraw();
		}
		private void SetUpDraw()
		{
			Color[] textureColor = baseTexture.GetPixels();
			Texture2D texture2D = new Texture2D(baseTexture.width, baseTexture.height, TextureFormat.RGBA64, false);
			texture2D.SetPixels(textureColor);
			generatedTexture = texture2D;
		}

		private void FixedUpdate()
		{
			if (Input.GetMouseButton(0))
			{
				RaycastHit hit;
				if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
					return;

				Renderer rend = hit.transform.GetComponent<Renderer>();
				Collider meshCollider = hit.collider as Collider;

				if (rend == null || meshCollider == null)
					return;

				rend.material = new Material(drawMaterial);
				rend.material.mainTexture = generatedTexture;
				Texture2D tex = rend.material.mainTexture as Texture2D;
				Vector2 pixelUV = hit.textureCoord;
				pixelUV.x *= tex.width;
				pixelUV.y *= tex.height;

				int startX = (int)(pixelUV.x - Mathf.Round(size / 2f));
				int startY = (int)(pixelUV.y - Mathf.Round(size / 2f));

				for (int i = 0; i < size; i++)
				{
					tex.SetPixel(startX + i, startY + i, color);
				}

				tex.Apply();
			}
		}
	}

}
