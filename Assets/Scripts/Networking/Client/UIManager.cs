using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Networking.Client
{
    public class UIManager : MonoBehaviour
    {
        //singleton to ensure only 1 network manager
        private static UIManager _networkMangerInstance;
    
        public static UIManager NetworkManagerInstance
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
        
        
    }
    

    
}
