using UnityEngine;
using UnityEditor;
using System.IO;


public class LevelLoader :ILevelLoader{

    private LevelModel levelModel;

    public LevelModel Level {
        get { return levelModel; }
    }

    public Vector2Int Size {
        get { return levelModel.size; }
    }

    public LevelLoader(int level) {
        levelModel = ReadLevel(level);
    }

    public LevelModel ReadLevel(int level) {
        try {
            var path = Constants.LEVEL_DIR + string.Format(Constants.LEVEL, level);
            StreamReader reader = new StreamReader(path);
            string json = reader.ReadToEnd();
            levelModel = JsonUtility.FromJson<LevelModel>(json);
            return levelModel;
        } catch (FileNotFoundException){
            throw new UnityException("Can't load level");
        }
        
    }

}