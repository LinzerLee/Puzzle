using UnityEngine;
using System.Collections.Generic;
using PuzzleSceneUtil;

public static class RuntimeManager {
	public static string res_xml = "PuzzleResource.xml";
	public static string section;
	public static string scene;
    public static string unlock_section;
    public static string unlock_scene;
    public static PuzzleSceneUtil.Resolution resolution = new PuzzleSceneUtil.Resolution ();
	public static int size;
	public static string music;
	public static cube cur_cube = null;

	static RuntimeManager()
	{
		resolution.Width = 768;
		resolution.Height = 1024;
        unlock_section = PlayerPrefs.GetString("unlock_section", "凤求凰");
        unlock_scene = PlayerPrefs.GetString("unlock_scene", "1.1");
        section = unlock_section;
        scene = unlock_scene;
        PuzzleXMLResource.Load(Application.streamingAssetsPath + "/" + res_xml);
	}

	public static List<State> GetPosition(string name)
	{
		char[] separator = {'_'};
		string[] st = name.Split(separator);
		return GetPosition(int.Parse (st [1]));
	}

    public static void UnlockNextScene()
    {
        bool flag = false;
        foreach(Section sec in PuzzleXMLResource.GameRes.Sections)
        {
            if(sec.Name.Equals(unlock_section) || flag)
            {
                foreach (Scene sce in sec.Scenes)
                {
                    if(sce.Name.Equals(unlock_scene))
                    {
                        flag = true;
                        continue;
                    }
                    else if(flag)
                    {
                        unlock_section = sec.Name;
                        unlock_scene = sce.Name;

                        PlayerPrefs.SetString("unlock_section", RuntimeManager.unlock_section);
                        PlayerPrefs.SetString("unlock_scene", RuntimeManager.unlock_scene);
                        return;
                    }

                }
            }
        }
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
