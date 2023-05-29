using System;
using UnityEngine;


namespace Networking.Client.Multiplayer
{
    using Riptide;
    using Riptide.Utils;

    public enum ClientToServerId : ushort
    {
        Name = 1,
    }
    public class NetworkManager : MonoBehaviour
    {

        //singleton to ensure only 1 network manager
        private static NetworkManager _networkMangerInstance;
    
        public static NetworkManager LocalInstance
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
        [SerializeField] string ip;
        //port to connect to 
        [SerializeField] string port;
        
        public string IP
        {
            get { return ip; }
            set { ip = value; }
        }
        public string Port
        {
            get { return port; }
            set { port = value; }
        }
        private void Awake()
        {
            //set object this script is on to be this instance
            LocalInstance = this;
        }

        private void Start()
        {
            //sends message displaying Client activity
            RiptideLogger.Initialize(Debug.Log, Debug.Log, Debug.LogWarning, Debug.LogError, false);
            //creates new client
            Client = new Client();
            Client.Connected += DidConnect;
            Client.ConnectionFailed += FailedConnect;
            Client.Disconnected += DidDisconnect;
        }

        public void Connect()
        {
            Client.Connect($"{ip}:{port}");
        }

        private void DidConnect(object sender, EventArgs e)
        {
            UIManager.LocalInstance.SendName();
        }

        private void FailedConnect(object sender, EventArgs e)
        {
            UIManager.LocalInstance.BackToMain();
        }

        private void DidDisconnect(object sender, EventArgs e)
        {
            UIManager.LocalInstance.BackToMain();
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