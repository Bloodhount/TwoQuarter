using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveDataRepository : ISaveDataRepository
{

    private readonly IData<SavedData> _data;
    private const string _folderName = "dataSave";
    private const string _fileName = "data.bat";
    private readonly string _path;
    public SaveDataRepository()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            _data = new PlayerPrefsData();
        }
        else
        {
            _data = new JsonData<SavedData>();
        }
        _path = Path.Combine(Application.dataPath, _folderName);
    }
    public void Save(PlayerBase player)
    {
        if (!Directory.Exists(Path.Combine(_path)))
        {
            Directory.CreateDirectory(_path);
        }
        var savePlayer = new SavedData
        {
            Position = player.transform.position,
            Name = "Roman",
            IsEnabled = true
        };
        _data.Save(savePlayer, Path.Combine(_path, _fileName));
    }
    public void Load(PlayerBase player)
    {
        var file = Path.Combine(_path, _fileName);
        if (!File.Exists(file)) return;
        var newPlayer = _data.Load(file);
        player.transform.position = newPlayer.Position;
        player.name = newPlayer.Name;
        player.gameObject.SetActive(newPlayer.IsEnabled);
        Debug.Log(newPlayer);
    }

}
