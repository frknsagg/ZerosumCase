using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefsManager : MonoBehaviour
{
  
    public static PrefsManager instance;
    private float _multiplierUpgradeStack;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnLevelEnd,SaveLevelCount);
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnLevelEnd,SaveLevelCount);
    }

    public int GetLevelCount()
    {
        var temp= PlayerPrefs.GetInt("LevelCount");
        return temp == 0 ? 1 : temp;
        
    }

    public void SaveLevelCount()
    {
        var temp=PlayerPrefs.GetInt("LevelCount");
        temp += 1;
        PlayerPrefs.SetInt("LevelCount",temp);
    }

    public int GetCurrencyAmount()
    {
        return PlayerPrefs.GetInt("CurrencyAmount");
    }

    public void SaveCurrencyAmount(int value)
    {
        var temp=PlayerPrefs.GetInt("CurrencyAmount");
        temp += value;
        PlayerPrefs.SetInt("CurrencyAmount",temp);
        
    }

   public float GetMultiplierUpgrade()
    {
        var temp = PlayerPrefs.GetFloat("MultiplierUpgradeButton") == 0
            ? 1
            : PlayerPrefs.GetFloat("MultiplierUpgradeButton");
        return temp;
    }

    public void IncreaseMultiplierUpgrade()
    {
        var temp = GetMultiplierUpgrade();
        temp *= 1.1f;
        PlayerPrefs.SetFloat("MultiplierUpgradeButton",temp);
        
    }
    
}
