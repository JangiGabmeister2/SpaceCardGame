using System;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

namespace Networking.Server.Multiplayer
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
        
        //properties
        public Server Server { get; private set; }
        //port number
        [SerializeField] private ushort port;
        //max amount of clients allowed to connect
        [SerializeField] private ushort maxClientCount;

        public ushort Port
        {
            get { return port; }
            set { port = value; }
        }
        private void Awake()
        {
            NetworkManagerInstance = this;
        }

        private void Start()
        {
            //sends messages displaying network activity
            RiptideLogger.Initialize(Debug.Log, Debug.Log, Debug.LogWarning, Debug.LogError, false);
            //creates new server
            Server = new Server();
        }

        public void StartServer()
        {
            //starts the server at port x with y amount of max clients
            Server.Start(port, maxClientCount);
        }

        public void StopServer()
        {
            Server.Stop();
        }

        private void FixedUpdate()
        {
            Server.Update();
        }

        private void OnApplicationQuit()
        {
            Server.Stop();
        }
    }
}