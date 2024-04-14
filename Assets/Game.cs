using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Game : MonoBehaviour
{
    private int maxValue = 100;
    private int minValue = 1;
    private int middleValue;
    private int attempsNumber = 0;



    [SerializeField] private GameObject _startMenu;
    [SerializeField] private GameObject _preGame;
    [SerializeField] private GameObject _playGame;
    [SerializeField] private GameObject _settingsMenu;
    [SerializeField] private GameObject _afterGame;
    [Space]
    [SerializeField] private Button _playGameButton;
    [Space]
    [SerializeField] private Button _selectButton;
    [Space]
    [SerializeField] private Button _openSettingButton;
    [SerializeField] private TextMeshProUGUI _guessingPlate;
    [SerializeField] private TextMeshProUGUI _attemptCounter;
    [SerializeField] private Button _noButton;
    [SerializeField] private Button _yesButton;
    [SerializeField] private Button _wonButton;
    [Space]
    [SerializeField] private Button _exitSettingButton;
    [Space]
    [SerializeField] private Button _returnButton;
    



    private void Start()

    {
       _startMenu.SetActive(true);
       _preGame.SetActive(false);
       _playGame.SetActive(false);
       _afterGame.SetActive(false);
       _settingsMenu.SetActive(false);


        _playGameButton.onClick.AddListener(OnPlayGameButtonClick);

        _selectButton.onClick.AddListener(OnSelectButtonClick);

        _openSettingButton.onClick.AddListener(OnOpenSettingButtonClick);
        _noButton.onClick.AddListener(OnNoButtonClick);
        _yesButton.onClick.AddListener(OnYesButtonClick);
        _wonButton.onClick.AddListener(OnWonButtonClick);

        _exitSettingButton.onClick.AddListener(OnExitSettingButtonClick);

        _returnButton.onClick.AddListener(OnReturnButtonClick);
    }


    private void OnPlayGameButtonClick()
    {
        maxValue = 100;
        minValue = 1;
        attempsNumber = 0;

        middleValue = (maxValue + minValue) / 2;
        _guessingPlate.text = $"IS YOUR NUMBER MORE THAN {middleValue}?";
        _attemptCounter.text = $"ATTEMP ¹:{attempsNumber}";

        _startMenu.SetActive(false);
        _afterGame.SetActive(false);
        _preGame.SetActive(true);
    }


    private void OnSelectButtonClick()
    {
        _preGame.SetActive(false);
        _playGame.SetActive(true);
    }

    private void OnOpenSettingButtonClick()
    {
        _settingsMenu.SetActive(true);
    }

    private void OnExitSettingButtonClick()
    {
        _settingsMenu.SetActive(false);
    }

    private void OnYesButtonClick() 
    {
        attempsNumber ++;
        minValue = middleValue;
        middleValue = (maxValue +  minValue) / 2;

        _attemptCounter.text = $"ATTEMP :{attempsNumber}";
        _guessingPlate.text = $"IS YOUR NUMBER MORE THAN {middleValue}?";

        Debug.Log($"YES\nMinValue:{minValue} MiddleValue:{middleValue} MaxValue:{maxValue}");
    }
     private void OnNoButtonClick()
    {
        attempsNumber ++;
        minValue = middleValue;
        middleValue = (maxValue - minValue) / 2;

        _attemptCounter.text = $"ATTEMP :{attempsNumber}";
        _guessingPlate.text = $"IS YOUR NUMBER MORE THAN {middleValue}?";

        Debug.Log($"No\nMinValue:{minValue} MiddleValue:{middleValue} MaxValue:{maxValue}");
    }

    private void OnWonButtonClick ()
    {
        _playGame.SetActive(false);
        _afterGame.SetActive(true);
    }

    private void OnReturnButtonClick()
    {
        _afterGame.SetActive(false);
        _startMenu.SetActive(true);
    }
}


  