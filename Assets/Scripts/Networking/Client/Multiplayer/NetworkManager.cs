using System;
using UnityEngine;


namespace Networking.Client.Multiplayer
{
    using Riptide;
    using Riptide.Utils;

    public class NetworkManager : MonoBehaviour
    {
        //singleton to ensure only 1 network manager
        private static NetworkManager _networkMangerInstance;
    
        public static NetworkManager NetworkManagerInstance
        {
            get => _networkMangerInstance;
            private set
            {
                //if no network manager yet exists, make one
                if (_networkMangerInstance == null)
                {
                    _networkMangerInstance = value;
                }
                //if one does exist, abort making one
                else if (_networkMangerInstance != value)
                {
                    Debug.Log($"{nameof(NetworkManager)} instance already exists");
                    Destroy(value);
                }
            }
        }
        public Client Client { get; private set; }
        //ip address to connect to
        [SerializeField] private string ip;
        //port to connect to 
        [SerializeField] private string port;
        private void Awake()
        {
            //set object this script is on to be this instance
            NetworkManagerInstance = this;
        }

        private void Start()
        {
            //sends message displaying Client activity
            RiptideLogger.Initialize(Debug.Log, Debug.Log, Debug.LogWarning, Debug.LogError, false);
            //creates new client
            Client = new Client();
        }

        public void Connect()
        {
            Client.Connect($"{ip}:{port}");
        }

        private void FixedUpdate()
        {
            Client.Update();
        }

        private void OnApplicationQuit()
        {
            Client.Disconnect();
        }
    }


    
}