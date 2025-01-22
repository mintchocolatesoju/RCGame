using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public int gas = 100;
    public int maxGas = 100;
    public int gasDecrease = 10;
    public int gasIncrease = 30;

    public TextMeshProUGUI gasText;
    public GameObject gameOverScreen;

    public bool isGoing = true;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(DecreaseGas());

    }

    IEnumerator DecreaseGas()
    {
        while(isGoing)
        {
            yield return new WaitForSeconds(1f);
            gas -= gasDecrease;
            gas = Mathf.Clamp(gas, 0, maxGas);
            UpdateText();

            
            if(gas<=0)
            {
                isGoing = false;
                Time.timeScale = 0;
                gameOverScreen.SetActive(true);

                
            }
        }
    
    }
    
    public void AddGas()
    {
        gas +=gasIncrease;
        gas = Mathf.Clamp(gas,0, maxGas);
        UpdateText();
    }

    private void UpdateText()
    {
        gasText.text = "Gas: " + gas;
    } 
    
    public void ReStart()
    {
        SceneManager.LoadScene(0);
    }

}
