using System;
using System.Collections;
using System.Collections.Generic;
using Networking.Client.Multiplayer;
using Riptide;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Networking.Client
{
    public class UIManager : MonoBehaviour
    {
        //singleton to ensure only 1 network manager
        private static UIManager _networkManager;
    
        public static UIManager LocalInstance
        {
            get => _networkManager;
            private set
            {
                //if no network manager yet exists, make one
                if (_networkManager == null)
                {
                    _networkManager = value;
                }
                //if one does exist, abort making one
                else if (_networkManager != value)
                {
                    Debug.Log($"{nameof(UIManager)} instance already exists");
                    Destroy(value);
                }
            }
        }
        //
        [Header("Connect")]
        [SerializeField] private GameObject connectUI;
        [SerializeField] private InputField usernameField;
        [SerializeField] private InputField ipField;
        [SerializeField] private InputField portField;

        public void Awake()
        {
            LocalInstance = this;
        }

        public void ConnectClicked()
        {
            usernameField.interactable = false;
            ipField.interactable = false;
            portField.interactable = false;
            connectUI.SetActive(false);

          NetworkManager.LocalInstance.Connect();
        }

        public void IPChange(string ip)
        {
            NetworkManager.LocalInstance.IP = ip;
        }
        public void PortChange(string port)
        {
            NetworkManager.LocalInstance.Port = port;
            Networking.Server.Multiplayer.NetworkManager.NetworkManagerInstance.Port = ushort.Parse(port);
        }
        public void BackToMain()
        {
            usernameField.interactable = true;
            ipField.interactable = true;
            portField.interactable = true;
            connectUI.SetActive(true);
        }

        public void SendName()
        {
            Message message = Message.Create(MessageSendMode.Reliable, (ushort)ClientToServerId.Name);
            message.AddString(usernameField.ToString());
            NetworkManager.LocalInstance.Client.Send(message);
        }
    }
    

    
}
