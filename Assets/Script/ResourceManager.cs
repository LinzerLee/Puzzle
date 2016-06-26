using UnityEngine;
using System.Collections.Generic;
using PuzzleSceneUtil;

public static class ResourceManager {
	public static string res_xml = "PuzzleResource.xml";
	public static string section = "凤求凰";
	public static string scene = "1.1";
	public static PuzzleSceneUtil.Resolution resolution = new PuzzleSceneUtil.Resolution ();
	public static int size;
	public static string music;
	public static cube cur_cube = null;

	static ResourceManager()
	{
		resolution.Width = 768;
		resolution.Height = 1024;
		Debug.Log (GetRootPath() + "/StreamingAssets/" + res_xml);
		PuzzleXMLResource.Load(GetRootPath() + "/StreamingAssets/" + res_xml);
	}

	public static string GetRootPath()
	{
		return Application.dataPath.Substring (0, Application.dataPath.Length - 5);
	}

	public static List<State> GetPosition(string name)
	{
		char[] separator = {'_'};
		string[] st = name.Split(separator);
		return GetPosition(int.Parse (st [1]));
	}

	public static List<State> GetPosition(int type)
	{
		type = (type - 1 + 7) % 7;
		List<State> states = new List<State> ();
		foreach(Section sec in PuzzleXMLResource.GameRes.Sections)
		{
			if (sec.Name.Equals (section)) 
			{
				foreach (Scene sce in sec.Scenes) 
				{
					if (sce.Name.Equals (scene)) 
					{
						foreach (SceneResol sr in sce.SceneResols) 
						{
							if (sr.Resolution.Equals (resolution)) 
							{
								foreach (Programme prog in sr.Programmes) 
								{
									foreach (State state in prog.Cubes[type].States) 
									{
										states.Add (state);
									}
								}
								break;
							}
						}
						break;
					}
				}
				break;
			}
		}

		return states;
	}
}
