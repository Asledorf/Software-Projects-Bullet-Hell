using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whiteboard : MonoBehaviour
{
	private whiteboard(){}
	public static whiteboard instance { get { return Nested._instance; } }
	private class Nested
	{
		// Explicit static constructor to tell C# compiler
		// not to mark type as beforefieldinit
		static Nested(){}
		internal static readonly whiteboard _instance = new whiteboard();
	}

    private void Start()
    {
		DontDestroyOnLoad(this.gameObject);
    }

    public Player player;

	public int score = 0;
}
