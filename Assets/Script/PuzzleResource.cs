using System;
using System.Collections.Generic;
using System.Xml;

namespace PuzzleSceneUtil
{
    public class Resolution
    {
        private int _width;
        public int Width
        {
            get
            {
                return _width;
            }

            set
            {
                _width = value;
            }
        }

        private int _height;
        public int Height
        {
            get
            {
                return _height;
            }

            set
            {
                _height = value;
            }
        }

        private string _device;
        public string Device
        {
            get
            {
                if (null == _device)
                {
                    _device = "";
                }
                return _device;
            }

            set
            {
                _device = value;
            }
        }

        public override bool Equals(object obj)
        {
            Resolution o = obj as Resolution;
            return o.Width==Width && o.Height==Height;
        }
        public override string ToString()
        {
            return Width + "*" + Height + "   [" + Device + "]";
        }
    }

    public class State
    {
        private double _x = .0;
        public double X
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
            }
        }

        private double _y = .0;
        public double Y
        {
            get
            {
                return _y;
            }

            set
            {
                _y = value;
            }
        }

        private double _r = .0;
        public double R
        {
            get
            {
                return _r;
            }

            set
            {
                _r = value;
            }
        }

        private bool _isFliped = false;
        public bool IsFliped
        {
            get
            {
                return _isFliped;
            }

            set
            {
                _isFliped = value;
            }
        }
    }

    public class Cube
    {
        private int _type;
        public int Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        private List<State> _states;
        public List<State> States
        {
            get
            {
                if (null == _states)
                {
                    _states = new List<State>();
                }

                return _states;
            }

            set
            {
                _states = value;
            }
        }
    }

    public class Programme
    {
        private int _id;
        public int ID
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        private Cube[] _cubes;
        public Cube[] Cubes
        {
            get
            {
                if (null == _cubes)
                {
                    _cubes = new Cube[7];
                }

                return _cubes;
            }

            set
            {
                _cubes = value;
            }
        }
    }

    public class SceneResol
    {
        private Resolution _resolution;
        public Resolution Resolution
        {
            get
            {
                if (null == _resolution)
                {
                    _resolution = new Resolution();
                }

                return _resolution;
            }

            set
            {
                _resolution = value;
            }
        }

        private List<Programme> _programmes;
        public List<Programme> Programmes
        {
            get
            {
                if (null == _programmes)
                {
                    _programmes = new List<Programme>();
                }
                return _programmes;
            }

            set
            {
                _programmes = value;
            }
        }

        private int _size;
        public int Size
        {
            get
            {
                return _size;
            }

            set
            {
                _size = value;
            }
        }
        
    }

    public class Scene
    {
        private string _name;
        public string Name
        {
            get
            {
                if (null == _name)
                {
                    _name = "";
                }

                return _name;
            }

            set
            {
                _name = value;
            }
        }

        private string _background;
        public string Background
        {
            get
            {
                if (null == _background)
                {
                    _background = "";
                }

                return _background;
            }

            set
            {
                _background = value;
            }
        }

        private List<SceneResol> _sceneResols;
        public List<SceneResol> SceneResols
        {
            get
            {
                if (null == _sceneResols)
                {
                    _sceneResols = new List<SceneResol>();
                }

                return _sceneResols;
            }

            set
            {
                _sceneResols = value;
            }
        }
        
    }

    public class Section
    {
        private string _name;
        public string Name
        {
            get
            {
                if (null == _name)
                {
                    _name = "";
                }

                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string _music;
        public string Music
        {
            get
            {
                if (null == _music)
                {
                    _music = "";
                }

                return _music;
            }

            set
            {
                _music = value;
            }
        }

        private List<Scene> _scenes;
        public List<Scene> Scenes
        {
            get
            {
                if (null == _scenes)
                {
                    _scenes = new List<Scene>();
                }

                return _scenes;
            }

            set
            {
                _scenes = value;
            }
        }
    }

    public class GameRes
    {
        private List<Section> _sections;

        public List<Section> Sections
        {
            get
            {
                if (null == _sections)
                {
                    _sections = new List<Section>();
                }

                return _sections;
            }

            set
            {
                _sections = value;
            }
        }
    }

    public class PuzzleRes
    {
        private List<string> _sectionRes;
        public List<string> SectionRes
        {
            get
            {
                if(null == _sectionRes)
                {
                    _sectionRes = new List<string>();
                }

                return _sectionRes;
            }

            set
            {
                _sectionRes = value;
            }
        }

        private List<string> _musicRes;
        public List<string> MusicRes
        {
            get
            {
                if (null == _musicRes)
                {
                    _musicRes = new List<string>();
                }

                return _musicRes;
            }

            set
            {
                _musicRes = value;
            }
        }

        private List<string> _sceneRes;
        public List<string> SceneRes
        {
            get
            {
                if (null == _sceneRes)
                {
                    _sceneRes = new List<string>();
                }

                return _sceneRes;
            }

            set
            {
                _sceneRes = value;
            }
        }

        private List<Resolution> _resolutionRes;
        public List<Resolution> ResolutionRes
        {
            get
            {
                if (null == _resolutionRes)
                {
                    _resolutionRes = new List<Resolution>();
                }

                return _resolutionRes;
            }

            set
            {
                _resolutionRes = value;
            }
        }

        private List<int> _sizeRes;
        public List<int> SizeRes
        {
            get
            {
                if (null == _sizeRes)
                {
                    _sizeRes = new List<int>();
                }

                return _sizeRes;
            }

            set
            {
                _sizeRes = value;
            }
        }

        private List<string> _backgroundRes;
        public List<string> BackgroundRes
        {
            get
            {
                if (null == _backgroundRes)
                {
                    _backgroundRes = new List<string>();
                }

                return _backgroundRes;
            }

            set
            {
                _backgroundRes = value;
            }
        }

        public void AddResource(string type, object res)
        {
            List<string> resource = null;
            type = type.ToLower();
            switch (type)
            {
                case "section":
                    resource = SectionRes;
                    break;
                case "music":
                    resource = MusicRes;
                    break;
                case "scene":
                    resource = SceneRes;
                    break;
                case "background":
                    resource = BackgroundRes;
                    break;
                default:
                    break;
            }

            if(resource!=null)
            {
                foreach(string r in resource)
                {
                    if (r.Equals(res))
                        return;
                }

                resource.Add(res as string);

                return;
            }

            if(type.Equals("resolution"))
            {
                foreach (Resolution r in ResolutionRes)
                {
                    if (r.Equals(res))
                        return;
                }

                ResolutionRes.Add(res as Resolution);
                return;
            }


            if (type.Equals("size"))
            {
                foreach (int r in SizeRes)
                {
                    if (r.Equals(res))
                        return;
                }

                SizeRes.Add((int)res);
                return;
            }
        }

        public void RemoveResource(string type, object res)
        {
            List<string> resource = null;
            type = type.ToLower();
            switch (type)
            {
                case "section":
                    resource = SectionRes;
                    break;
                case "music":
                    resource = MusicRes;
                    break;
                case "scene":
                    resource = SceneRes;
                    break;
                case "background":
                    resource = BackgroundRes;
                    break;
                default:
                    break;
            }

            if (resource != null)
            {
                resource.Remove(res as string);
                return;
            }

            if (type.Equals("resolution"))
            {
                ResolutionRes.Remove(res as Resolution);
                return;
            }

            if (type.Equals("size"))
            {
                SizeRes.Remove((int)res);
                return;
            }
        }

        public void ReleaseResource(string type)
        {
            List<string> resource = null;
            type = type.ToLower();
            switch (type)
            {
                case "section":
                    resource = SectionRes;
                    break;
                case "music":
                    resource = MusicRes;
                    break;
                case "scene":
                    resource = SceneRes;
                    break;
                case "background":
                    resource = BackgroundRes;
                    break;
                default:
                    break;
            }

            if (resource != null)
            {
                resource.Clear();
                return;
            }

            if (type.Equals("resolution"))
            {
                ResolutionRes.Clear();
                return;
            }

            if (type.Equals("size"))
            {
                SizeRes.Clear();
                return;
            }
        }
        
        public void ReleaseAll()
        {
            ReleaseResource("Section");
            ReleaseResource("Music");
            ReleaseResource("Scene");
            ReleaseResource("Resolution");
            ReleaseResource("Size");
            ReleaseResource("Background");
        }
    }

    public static class PuzzleXMLResource
    {
        private static PuzzleRes puzzleRes = new PuzzleRes();
        private static GameRes gameRes = new GameRes();

        public static PuzzleRes PuzzleRes { get { return puzzleRes; } set { puzzleRes = value; } }
        public static GameRes GameRes { get { return gameRes; } set { gameRes = value; } }

        public static bool Load(string xml_file)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xml_file);

            // 加载资源
            XmlNodeList nodelist = xmlDoc.SelectNodes("//SectionRes/String");
            for (int i = 0; i < nodelist.Count; i++)
            {
                XmlElement e = (XmlElement)nodelist.Item(i);
                PuzzleRes.AddResource("Section", e.InnerText);
            }

            nodelist = xmlDoc.SelectNodes("//MusicRes/String");
            for (int i = 0; i < nodelist.Count; i++)
            {
                XmlElement e = (XmlElement)nodelist.Item(i);
                PuzzleRes.AddResource("Music", e.InnerText);
            }

            nodelist = xmlDoc.SelectNodes("//SceneRes/String");
            for (int i = 0; i < nodelist.Count; i++)
            {
                XmlElement e = (XmlElement)nodelist.Item(i);
                PuzzleRes.AddResource("Scene", e.InnerText);
            }

            nodelist = xmlDoc.SelectNodes("//ResolutionRes/Resolution");
            for (int i = 0; i < nodelist.Count; i++)
            {
                XmlElement e = (XmlElement)nodelist.Item(i);
                Resolution r = new Resolution();

                r.Width = int.Parse(e.GetAttribute("width"));
                r.Height = int.Parse(e.GetAttribute("height"));
                r.Device = e.InnerText;
                PuzzleRes.AddResource("Resolution", r);
            }

            nodelist = xmlDoc.SelectNodes("//SizeRes/Int");
            for (int i = 0; i < nodelist.Count; i++)
            {
                XmlElement e = (XmlElement)nodelist.Item(i);
                PuzzleRes.AddResource("Size", int.Parse(e.InnerText));
            }

            nodelist = xmlDoc.SelectNodes("//BackgroundRes/String");
            for (int i = 0; i < nodelist.Count; i++)
            {
                XmlElement e = (XmlElement)nodelist.Item(i);
                PuzzleRes.AddResource("Background", e.InnerText);
            }

            // 加载场景资源
            nodelist = xmlDoc.SelectNodes("//GameRes/Section");
            for (int i = 0; i < nodelist.Count; ++i)
            {
                XmlElement e = (XmlElement)nodelist.Item(i);
                Section section = new Section();
                section.Name = e.GetAttribute("name");
                section.Music = e.GetAttribute("music");

                XmlNodeList sceneNodeList = e.ChildNodes;

                for (int j = 0; j < sceneNodeList.Count; ++j)
                {
                    XmlElement ee = (XmlElement)sceneNodeList.Item(j);

                    Scene scene = new Scene();
                    scene.Name = ee.GetAttribute("name");
                    scene.Background = ee.GetAttribute("background");

                    XmlNodeList resolNodeList = ee.ChildNodes;
                    for (int k=0; k<resolNodeList.Count; ++k)
                    {
                        XmlElement eee = (XmlElement)resolNodeList.Item(k);

                        Resolution r = new Resolution();
                        SceneResol resol = new SceneResol();

                        r.Width = int.Parse(eee.GetAttribute("width"));
                        r.Height = int.Parse(eee.GetAttribute("height"));
                        r.Device = eee.GetAttribute("device");

                        resol.Resolution = r;
                        resol.Size = int.Parse(eee.GetAttribute("size"));

                        XmlNodeList progmNodeList = eee.ChildNodes;
                        for (int m=0; m< progmNodeList.Count; ++m)
                        {
                            XmlElement eeee = (XmlElement)progmNodeList.Item(m);

                            Programme programme = new Programme();

                            programme.ID = int.Parse(eeee.GetAttribute("id"));

                            XmlNodeList cubeNodeList = eeee.ChildNodes;
                            for (int n = 0; n < cubeNodeList.Count; ++n)
                            {
                                XmlElement eeeee = (XmlElement)cubeNodeList.Item(n);
                                Cube cube = new Cube();

                                cube.Type = int.Parse(eeeee.GetAttribute("type"));

                                string content = eeeee.InnerText;
                                char[] separator = { '#'};
                                string[] st = content.Split(separator);

                                foreach(string s in st)
                                {
                                    State state = new State();
                                    if (s.Contains("f"))
                                        state.IsFliped = true;
                                    else
                                        state.IsFliped = false;

                                    string tmp;
                                    if (state.IsFliped)
                                        tmp = s.Substring(1, s.Length - 3);
                                    else
                                        tmp = s.Substring(1, s.Length - 2);

                                    char[] septr = { ',' };
                                    string[] temps = tmp.Split(septr);

                                    state.X = double.Parse(temps[0]);
                                    state.Y = double.Parse(temps[1]);
                                    state.R = double.Parse(temps[2]);

                                    cube.States.Add(state);
                                }

                                programme.Cubes[cube.Type-1] = cube;
                            }
                            resol.Programmes.Add(programme);
                        }
                        scene.SceneResols.Add(resol);
                    }
                    section.Scenes.Add(scene);
                }
                GameRes.Sections.Add(section);
            }
            
            return true;
        }

        public static bool Save(string xml_file)
        {
            XmlDocument xmlDoc = new XmlDocument();
            // 加入XML的声明段落,<?xml version="1.0" encoding="utf-8"?>
            XmlDeclaration xmlDecl = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDoc.AppendChild(xmlDecl);

            // <Puzzle>
            XmlElement puzzleElem = xmlDoc.CreateElement("", "Puzzle", "");
            // <PuzzleRes>
            XmlElement puzzleResElem = xmlDoc.CreateElement("", "PuzzleRes", "");

            // <SectionRes>
            XmlElement sectionResElem = xmlDoc.CreateElement("", "SectionRes", "");
            // <String>
            foreach(string s in PuzzleRes.SectionRes)
            {
                XmlElement stringElem = xmlDoc.CreateElement("", "String", "");
                stringElem.InnerText = s;
                sectionResElem.AppendChild(stringElem);
            }
            puzzleResElem.AppendChild(sectionResElem);

            // <MusicRes>
            XmlElement musicResElem = xmlDoc.CreateElement("", "MusicRes", "");
            // <String>
            foreach (string s in PuzzleRes.MusicRes)
            {
                XmlElement stringElem = xmlDoc.CreateElement("", "String", "");
                stringElem.InnerText = s;
                musicResElem.AppendChild(stringElem);
            }
            puzzleResElem.AppendChild(musicResElem);

            // <SceneRes>
            XmlElement sceneResElem = xmlDoc.CreateElement("", "SceneRes", "");
            // <String>
            foreach (string s in PuzzleRes.SceneRes)
            {
                XmlElement stringElem = xmlDoc.CreateElement("", "String", "");
                stringElem.InnerText = s;
                sceneResElem.AppendChild(stringElem);
            }
            puzzleResElem.AppendChild(sceneResElem);

            // <ResolutionRes>
            XmlElement resolutionResElem = xmlDoc.CreateElement("", "ResolutionRes", "");
            // <Resolution>
            foreach (Resolution r in PuzzleRes.ResolutionRes)
            {
                XmlElement resolutionElem = xmlDoc.CreateElement("", "Resolution", "");
                resolutionElem.SetAttribute("width", r.Width.ToString());
                resolutionElem.SetAttribute("height", r.Height.ToString());
                resolutionElem.InnerText = r.Device;
                resolutionResElem.AppendChild(resolutionElem);
            }
            puzzleResElem.AppendChild(resolutionResElem);

            // <SizeRes>
            XmlElement sizeResElem = xmlDoc.CreateElement("", "SizeRes", "");
            // <Int>
            foreach (int i in PuzzleRes.SizeRes)
            {
                XmlElement intElem = xmlDoc.CreateElement("", "Int", "");
                intElem.InnerText = i.ToString();
                sizeResElem.AppendChild(intElem);
            }
            puzzleResElem.AppendChild(sizeResElem);

            // <BackgroundRes>
            XmlElement backgroundResElem = xmlDoc.CreateElement("", "BackgroundRes", "");
            // <String>
            foreach (string s in PuzzleRes.BackgroundRes)
            {
                XmlElement stringElem = xmlDoc.CreateElement("", "String", "");
                stringElem.InnerText = s;
                backgroundResElem.AppendChild(stringElem);
            }
            puzzleResElem.AppendChild(backgroundResElem);

            // <GameRes>
            XmlElement gameResElem = xmlDoc.CreateElement("", "GameRes", "");
            // <Section>
            foreach(Section section in GameRes.Sections)
            {
                XmlElement sectionElem = xmlDoc.CreateElement("", "Section", "");
                sectionElem.SetAttribute("name", section.Name);
                sectionElem.SetAttribute("music", section.Music);

                // <Scene>
                foreach (Scene scene in section.Scenes)
                {
                    XmlElement sceneElem = xmlDoc.CreateElement("", "Scene", "");
                    sceneElem.SetAttribute("name", scene.Name);
                    sceneElem.SetAttribute("background", scene.Background);

                    // <SceneResol>
                    foreach (SceneResol resol in scene.SceneResols)
                    {
                        XmlElement sceneResolElem = xmlDoc.CreateElement("", "SceneResol", "");
                        sceneResolElem.SetAttribute("width", resol.Resolution.Width.ToString());
                        sceneResolElem.SetAttribute("height", resol.Resolution.Height.ToString());
                        sceneResolElem.SetAttribute("device", resol.Resolution.Device);
                        sceneResolElem.SetAttribute("size", resol.Size.ToString());

                        // <Programme>
                        foreach (Programme p in resol.Programmes)
                        {
                            XmlElement programmeElem = xmlDoc.CreateElement("", "Programme", "");

                            programmeElem.SetAttribute("id", p.ID.ToString());
                            // <Cube>
                            for (int i=0; i<p.Cubes.Length; ++i)
                            {
                                XmlElement cubeElem = xmlDoc.CreateElement("", "Cube", "");
                                cubeElem.SetAttribute("type", (i+1).ToString());

                                string temp = "";
                                foreach(State s in p.Cubes[i].States)
                                {
                                    temp += "(" + s.X + "," + s.Y + "," + s.R + ")";
                                    if (s.IsFliped)
                                        temp += "f";
                                    temp += "#";
                                }

                                temp = temp.Remove(temp.Length-1);

                                cubeElem.InnerText = temp;

                                programmeElem.AppendChild(cubeElem);
                            }

                            sceneResolElem.AppendChild(programmeElem);
                        }
                        sceneElem.AppendChild(sceneResolElem);
                    }
                    sectionElem.AppendChild(sceneElem);
                }
                gameResElem.AppendChild(sectionElem);
            }

            puzzleElem.AppendChild(puzzleResElem);
            puzzleElem.AppendChild(gameResElem);
            xmlDoc.AppendChild(puzzleElem);

            xmlDoc.Save(xml_file);

            return true;
        }
    }
    
}
