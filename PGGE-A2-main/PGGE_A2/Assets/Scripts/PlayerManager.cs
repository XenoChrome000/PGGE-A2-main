﻿using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    PlayerManager - Gets the player object, handles the spawning of the player, and the position of the camera. 
                    Also handles what happens when the player leaves the room.
*/
public class PlayerManager : MonoBehaviourPunCallbacks
{

    public string mPlayerPrefabName;
    public PlayerSpawnPoints mSpawnPoints;
    bool mFiring;

    [HideInInspector]
    public GameObject mPlayerGameObject;
    [HideInInspector]
    private ThirdPersonCamera mThirdPersonCamera;

    private void Start()
    {
        Transform randomSpawnTransform = mSpawnPoints.GetSpawnPoint();
        mPlayerGameObject = PhotonNetwork.Instantiate(mPlayerPrefabName,
            randomSpawnTransform.position,
            randomSpawnTransform.rotation,
            0);

        mThirdPersonCamera = Camera.main.gameObject.AddComponent<ThirdPersonCamera>();

        //mPlayerGameObject.GetComponent<PlayerMovement>().mFollowCameraForward = false;
        mThirdPersonCamera.mPlayer = mPlayerGameObject.transform;
        mThirdPersonCamera.mDamping = 20.0f;
        mThirdPersonCamera.mCameraType = CameraType.Follow_Track_Pos_Rot;
    }

    public void LeaveRoom()
    {
        Debug.LogFormat("LeaveRoom");
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        //Debug.LogFormat("OnLeftRoom()");
        SceneManager.LoadScene("Menu");
    }

}
