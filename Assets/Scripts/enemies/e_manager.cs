using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_manager : MonoBehaviour
{
	#region singleton
	private e_manager() { }
	public static e_manager instance { get { return _e_manager._instance; } }
	private class _e_manager
	{
		// Explicit static constructor to tell C# compiler
		// not to mark type as beforefieldinit
		static _e_manager() { }
		internal static readonly e_manager _instance = new e_manager();
	}
	#endregion singleton

	public List<enemy> e_all;

	// Update is called once per frame
	void Update()
	{
	}
}
