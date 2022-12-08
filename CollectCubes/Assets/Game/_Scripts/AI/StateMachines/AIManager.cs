using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    [SerializeField] private float gathererSpeed = 4f;
    [SerializeField] private float aggroRadius = 4f;

    public static float speedAI => Instance.gathererSpeed;
    public static float AggroRadius => Instance.aggroRadius;


    public static AIManager Instance { get; private set; }
	private void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
		}
	}
}

