using System.Collections;
using System.Collections.Generic;
using Jonfoble.ScriptableSystem;
using UnityEngine;

namespace CC
{
	public class CollectableSpawner : MonoBehaviour
	{
		//FILL OUT A SCRIPTABLE LEVEL TO CREATE NEW LEVEL AND ASSIGN TROUGH EDITOR

		[SerializeField] private ScriptableLevel[] level;
		private Texture2D texture;
		[HideInInspector] public List<GameObject> cubeList = new List<GameObject>();
		public static int listAmount;

		float x = 0f, z = 0f;

		private void OnEnable()
		{
			GameManager.Instance.OnNextLevel += CreateCubes;
			GameManager.Instance.OnGameRestart += CreateCubes;
		}
		private void OnDisable()
		{ 
			GameManager.Instance.OnNextLevel -= CreateCubes;
			GameManager.Instance.OnGameRestart -= CreateCubes;
		}

		private void Start()
		{
			CreateCubes();
		}
		public void CreateCubes()
		{
			//SPAWNING CUBES FROM IMAGES USING OBJECT POOLING
			ScriptableLevel currentLevel = level[GameManager.Instance.currentLevel - 1];
			texture = currentLevel.sprite.texture;
			Debug.Log($"Texture Widht: {texture.width}  Texture Height: {texture.height}");
			CacheCubes(); //Adding all cubes back to the pool first
			for (int i = 0; i < texture.width; i++)
			{
				for (int j = 0; j < texture.height; j++)
				{
					Color newColor = texture.GetPixel(i, j);
					if (newColor.a != 0)
					{
						GameObject newObject = ObjectPoolManager.Instance.GetObject("Cube");
						if (newObject == null)
						{
							newObject = Instantiate(currentLevel.cubePrefab, transform.position, Quaternion.identity, this.transform);
						}
						cubeList.Add(newObject);
						newObject.transform.localPosition = new Vector3(x, newObject.transform.localPosition.y, z);
						SetColor(newObject, newColor);
						z += currentLevel.spacing.y;
					}
				}
				x += currentLevel.spacing.x;
				z = 0;
			}
			listAmount = cubeList.Count - 1;
		}
		public void CacheCubes()
		{
			for (int i = 0; i < cubeList.Count; i++)
			{
				ObjectPoolManager.Instance.AddObject("Cube", cubeList[i]);
			}
			x = 0f;
			z = 0f;
		}
		public void SetColor(GameObject go, Color a)
		{
			go.GetComponent<MeshRenderer>().material.color = a;
		}
	}
}