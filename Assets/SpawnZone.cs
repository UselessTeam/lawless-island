using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
	public GameObject prefab;
	public float spawnRate = 1;
	public float characteristicDistance = 0.2F;

	Collider2D spawnArea;
	Vector3 areaCenter;
	Vector3 areaExtents;

	float timeSinceSpawn = 0;
	public int lastElementsSize = 3;
	Queue<Vector3> lastElements = new Queue<Vector3>();
	// Start is called before the first frame update
	void Start()
	{
		spawnArea = GetComponent<Collider2D>();
		areaCenter = spawnArea.bounds.center;
		areaExtents = spawnArea.bounds.extents;
	}

	// Update is called once per frame
	void Update()
	{
		if (Time.fixedTime - timeSinceSpawn > 60 / spawnRate)
		{
			Instantiate(prefab, GeneratePosition(), new Quaternion(), transform);
			timeSinceSpawn = Time.fixedTime;
		}
	}

	Vector3 GeneratePosition()
	{
		Vector3 position;
		float probablityKeep;
		do
		{
			position = areaCenter;
			position.x += Random.Range(-areaExtents.x, areaExtents.x);
			position.y += Random.Range(-areaExtents.y, areaExtents.y);
			probablityKeep = 1;
			foreach (var element in lastElements)
			{
				probablityKeep *= Mathf.Min(1,
								Mathf.Exp(-Mathf.Pow(characteristicDistance * areaExtents.magnitude / (position - element).magnitude, 2))
																);
			}
		} while ((Random.Range(0, 1F) > probablityKeep) || !spawnArea.OverlapPoint(position));
		lastElements.Enqueue(position);
		if (lastElements.Count > lastElementsSize)
			lastElements.Dequeue();
		return position;
	}
}
