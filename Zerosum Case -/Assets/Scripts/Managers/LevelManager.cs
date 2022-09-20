using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelPrefabs mLevelPrefabs = null;
    
    private int _currentLevel;
    private GameObject _currentLevelObject;

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnStartLevel,CreateLevel);
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnStartLevel,CreateLevel);
    }

    void CreateLevel()
    {
        Destroy(_currentLevelObject);
        _currentLevel = PrefsManager.instance.GetLevelCount();
        int levelIndex = _currentLevel % mLevelPrefabs.LevelList.Count;
        _currentLevelObject = Instantiate(mLevelPrefabs.LevelList[levelIndex]);
        _currentLevelObject.transform.position=Vector3.zero;
    }
}
