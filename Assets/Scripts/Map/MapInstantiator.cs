using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(MapGenerator))]
public class MapInstantiator : MonoBehaviour 
{
	public Rect mappingZone = new Rect(Vector2.zero, Vector2.one * 10);
	
	public List<GameObject> priority;

	MapGenerator mapGenerator;

	void Start () 
	{
		mapGenerator = GetComponent<MapGenerator> ();
		Texture2D texture = mapGenerator.GenerateTexture ();
		float width = texture.width;
		float height = texture.height;

		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				float x = mappingZone.width * (i / width) + (mappingZone.x - mappingZone.width / 2);
				float y = mappingZone.height * (j / height) + (mappingZone.y - mappingZone.height / 2);

				
				int index = 0;
				GameObject instance = priority [index];
				while (InstanceByProbability (instance, texture.GetPixel(i, j).grayscale, new Vector2(x, y)) == false && index < priority.Count-1)
				{
					instance = priority [++index];
				}
			}
		}
	}

	bool InstanceByProbability(GameObject instance, float probability, Vector2 pos)
	{
		float proba = Random.Range (0.0f, 1.0f);

		if (proba < probability)
		{
			GameObject o = Instantiate (instance, pos, Quaternion.identity, transform);
			return true;
		}

		return false;
	}
}

[CustomEditor(typeof(MapInstantiator))]
public class MapInstantiatorEditor : Editor
{
	MapInstantiator refTarget;

    void OnEnable ()
    {
		refTarget = (MapInstantiator)target;
	}
    void OnSceneGUI ()
    {
        var rect = RectUtils.ResizeRect (
            refTarget.mappingZone,
            Handles.CubeCap,
            Color.green,
            Color.yellow,
            HandleUtility.GetHandleSize(Vector3.zero) * .1f,
            .1f);

        refTarget.mappingZone = rect;
    }
}