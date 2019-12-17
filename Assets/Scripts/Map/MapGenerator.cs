using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MapGenerator : MonoBehaviour 
{
	public Rect dimensions = new Rect(Vector2.zero, Vector2.one * 256);

	public float scale = 20f;

	public Color CalculateColor (int x, int y)
	{
		float xCoord = ((x / dimensions.width) * scale) + dimensions.x;
		float yCoord = ((y / dimensions.height) * scale) + dimensions.y;

		float sample = Mathf.PerlinNoise (xCoord, yCoord);

		return new Color (sample, sample, sample);
	}

	public Texture2D GenerateTexture ()
	{
		Texture2D newTexture = new Texture2D (
			(int)dimensions.width,
			(int)dimensions.height);
		
		newTexture.filterMode = FilterMode.Point;

		for (int i = 0; i < dimensions.width; i++)
		{
			for (int j = 0; j < dimensions.height; j++)
			{
				Color color = CalculateColor (i, j);
				newTexture.SetPixel (i, j, color);
			}
		}
		newTexture.Apply ();
		return newTexture;
	}
}

[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorEditor : Editor
{
	MapGenerator refTarget;

    void OnEnable ()
    {
		refTarget = (MapGenerator)target;
	}

	public override bool HasPreviewGUI ()
	{
		return true;
	}

	public override void OnPreviewGUI (Rect r, GUIStyle background)
	{
		base.OnPreviewGUI (r, background);
		Texture2D texture = refTarget.GenerateTexture ();
		if (texture)
			GUI.DrawTexture (r, texture, ScaleMode.ScaleToFit);
	}
}