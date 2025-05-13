using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField inputField;

    public Button gameStartButton;

    private void Start()
    {
        gameStartButton.onClick.AddListener(OnGameStartButtonClicked);
    }

    private void OnGameStartButtonClicked()
    {
        string playername = inputField.text;
        if (string.IsNullOrEmpty(playername) )
        {
            Debug.Log("�÷��̾� �̸��� �Է��ϼ���.");
            return;
        }

        PlayerPrefs.SetString("PlayerName", playername);
        PlayerPrefs.Save();

        Debug.Log("�÷��̾� �̸� ���� ��:" + playername);

        SceneManager.LoadScene("Level_1");
    }
}
