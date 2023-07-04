using System;
using System.Threading.Tasks;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AuthenticationManager : MonoBehaviour {
    [SerializeField] private TMP_InputField _joinInput;
    [SerializeField] private GameObject _buttons;
    [SerializeField] private UnityTransport _transport;
    public static event Action<string> LobbyJoined;
    private async void Awake()
    {
        
        _transport = FindObjectOfType<UnityTransport>();
        DontDestroyOnLoad(gameObject);
        await Authenticate();
        _buttons.SetActive(true);
    }
    
    private static async Task Authenticate()
    {
        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }


    public async void LoginAnonymously() {
        using (new Load("Logging you in...")){
            await Authentication.Login();
            SceneManager.LoadSceneAsync("Lobby");
        }
    }
    public async void JoinGame()
    {
        _buttons.SetActive(false);
        string a = _joinInput.text;
        SceneManager.LoadSceneAsync("Lobby");
        LobbyJoined?.Invoke(a);
    }
}