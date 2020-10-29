using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public int Clear = 0;
    public int Open = 0;
    public bool Starting;
    public byte m_state = 0;
    public bool SoundOnOff = true;
    public int ReadTutorial = 0;
    public int Arrow = 0;
    public int Pipe = 0;


    void Awake()
    {

        try
        {
            Load();
        }
        catch
        {

        }
        Open = Clear + 1;

        //if (PlayerPrefs.HasKey("ClearStage"))
        //{
        //    Clear = PlayerPrefs.GetInt("ClearStage");
        //    Open = Clear + 1;
        //}

        if (instance)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StageClear()
    {
        Clear++;
        Open++;
        Save();

        //XmlDocument document = new XmlDocument();
        //XmlElement element = document.CreateElement("ClearStage");
        //element.SetAttribute("ClearStage", Clear.ToString());
        //document.AppendChild(element);
        //document.Save("Save.xml");

        //PlayerPrefs.SetInt("ClearStage", Clear);
        //PlayerPrefs.Save();
    }

    void Save()
    {
        string FilePath;
        FilePath = Application.persistentDataPath + "/Save.xml";
        XmlDocument document = new XmlDocument();
        XmlDeclaration xmlDeclaration = document.CreateXmlDeclaration("1.0", "UTF-8", null);
        document.AppendChild(xmlDeclaration);

        XmlElement element = document.CreateElement("ClearStage");
        element.SetAttribute("ClearStage", Clear.ToString());
        document.AppendChild(element);
        document.Save(FilePath);
    }

    void Load()
    {
        string FilePath;
        FilePath = Application.persistentDataPath + "/Save.xml";
        XmlDocument document = new XmlDocument();
        document.Load(FilePath);
        XmlElement ClearStage = document["ClearStage"];
        Clear = System.Convert.ToInt32(ClearStage.GetAttribute("ClearStage"));
    }
}
