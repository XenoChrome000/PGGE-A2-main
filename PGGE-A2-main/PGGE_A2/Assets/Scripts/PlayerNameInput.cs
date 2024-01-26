using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

/*
    PlayerNameInput - Handles Input of player nickname in Multiplayer.
*/
public class PlayerNameInput : MonoBehaviour
{
    private InputField mInputField;
    const string playerNamePrefKey = "PlayerName";

    // Start is called before the first frame update
    void Start()
    {
        mInputField = this.GetComponent<InputField>();

        string defaultName = string.Empty;

        //X: Changed nested if statement to one statement.
        if (mInputField != null && PlayerPrefs.HasKey(playerNamePrefKey))
        {       
                defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                mInputField.text = defaultName;
        }
        PhotonNetwork.NickName = defaultName;
    }

    public void SetPlayerName()
    {
        string value = mInputField.text;
        if (string.IsNullOrEmpty(value))
        {
            Debug.LogError("Player Name is null or empty");
            return;
        }
        PhotonNetwork.NickName = value;
        PlayerPrefs.SetString(playerNamePrefKey, value);

        Debug.Log("Nickname entered: " + value);
    }

}
