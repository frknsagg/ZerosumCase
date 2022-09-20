using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject tapToPlay;
    [SerializeField] private GameObject levelEndPanel;
    [SerializeField] private TextMeshProUGUI currencyText;
    [SerializeField] private TextMeshProUGUI currentLevelText;
    [SerializeField] private TextMeshProUGUI collectedCurrenyText;
    [SerializeField] private GameObject noMoney;
    [SerializeField] private Transform noMoneyPoint;
    [SerializeField] private TextMeshProUGUI upgradeButtonText;

    private int _currencyAmount;
    
    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnStartLevel,ActivateTapToPlay);
        EventManager.AddHandler(GameEvent.OnStartLevel,DeActivateLevelEndPanel);
        EventManager.AddHandler(GameEvent.OnStartLevel,SetLevelText);
        EventManager.AddHandler(GameEvent.OnStartLevel,ActivateLevelPanel);
        EventManager.AddHandler(GameEvent.OnStartLevel,UpgradePriceAndName);
        EventManager.AddHandler(GameEvent.OnLevelEnd,DeActivateLevelPanel);
        EventManager.AddHandler(GameEvent.OnLevelEnd,ActivateLevelEndPanel);
        EventManager.AddHandler(GameEvent.OnUpdateUI,OnUpdateUI);
        EventManager.AddHandler(GameEvent.OnIncreaseCurrencyAmount,IncreaseCurrencyAmount);
        
        EventManager.Broadcast(GameEvent.OnUpdateUI);
        EventManager.Broadcast(GameEvent.OnStartLevel);
    }

    void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnStartLevel,ActivateTapToPlay);
        EventManager.RemoveHandler(GameEvent.OnStartLevel,DeActivateLevelEndPanel);
        EventManager.RemoveHandler(GameEvent.OnStartLevel,SetLevelText);
        EventManager.RemoveHandler(GameEvent.OnStartLevel,ActivateLevelPanel);
        EventManager.RemoveHandler(GameEvent.OnStartLevel,UpgradePriceAndName);
        EventManager.RemoveHandler(GameEvent.OnLevelEnd,ActivateLevelEndPanel);
        EventManager.RemoveHandler(GameEvent.OnLevelEnd,DeActivateLevelPanel);
        EventManager.RemoveHandler(GameEvent.OnIncreaseCurrencyAmount,IncreaseCurrencyAmount);
        EventManager.RemoveHandler(GameEvent.OnUpdateUI,OnUpdateUI);
    }

    void ActivateTapToPlay()
    {
        tapToPlay.gameObject.SetActive(true);
        _currencyAmount = 0;
        
    }
    void DeActivateTapToPlay()
    {
        tapToPlay.gameObject.SetActive(false);
    }
    public void OnPlaying()
    {
        DeActivateTapToPlay();
        EventManager.Broadcast(GameEvent.OnPlaying);
    }

    void ActivateLevelEndPanel()
    {
        levelEndPanel.SetActive(true);
        SetCollectedCurrency();
    }

    void DeActivateLevelEndPanel()
    {
        levelEndPanel.SetActive(false);
    }

    void ActivateLevelPanel()
    {
        currentLevelText.gameObject.SetActive(true);
    }
    void DeActivateLevelPanel()
    {
        currentLevelText.gameObject.SetActive(false);
    }

    void OnUpdateUI()
    {
        currencyText.text = "" + PrefsManager.instance.GetCurrencyAmount();
        UpgradePriceAndName();
    }

    void IncreaseCurrencyAmount()
    {
        _currencyAmount += 1;
        PrefsManager.instance.SaveCurrencyAmount(10);
        currencyText.text = "" + PrefsManager.instance.GetCurrencyAmount();
        
    }

    void SetLevelText()
    {
        currentLevelText.text = "Level " + PrefsManager.instance.GetLevelCount();
    }

    public void NextLevelButton()
    {
        EventManager.Broadcast(GameEvent.OnStartLevel);
    }

    void SetCollectedCurrency()
    {
        collectedCurrenyText.text = "" + _currencyAmount;
    }

    public void UpgradeButton()
    {
        UpgradeStackAmount();
    }

    void UpgradeStackAmount()
    {
        var temp = 5 * PrefsManager.instance.GetMultiplierUpgrade();
        
        if (temp<PlayerPrefs.GetInt("CurrencyAmount"))
        {
            var temp2 = PrefsManager.instance.GetCurrencyAmount() - (int) Mathf.Round(temp);
            PlayerPrefs.SetInt("CurrencyAmount",temp2);
            EventManager.Broadcast(GameEvent.OnUpdateStartStack);
            PrefsManager.instance.IncreaseMultiplierUpgrade();
            OnUpdateUI();
        }
        else
        {
          var obje=Instantiate(noMoney, noMoneyPoint.position,Quaternion.identity);
          obje.transform.SetParent(noMoneyPoint);
          obje.transform.localScale=Vector3.one;
            
        }
        
    }

    void UpgradePriceAndName()
    {
        float temp = 5 * PrefsManager.instance.GetMultiplierUpgrade();
        upgradeButtonText.text = "Upgrade " + Mathf.Round(temp);
    }
    


}
