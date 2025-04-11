using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MultiplayerManager : MonoBehaviour
{
    private List<PlayerConfiguration> _playerConfigs;
    [SerializeField] private int maxPlayers = 2;
    [SerializeField] private UnityEvent OnAllReady;

    public static MultiplayerManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null)
        {
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            _playerConfigs = new List<PlayerConfiguration>();
        }

    }

    public void HandlePlayerJoin(PlayerInput pi)
    {
        Debug.Log("Player joined " + pi.playerIndex);
        pi.transform.SetParent(transform);

        if(!_playerConfigs.Any(p => p.PlayerIndex == pi.playerIndex))
        {
            _playerConfigs.Add(new PlayerConfiguration(pi));
        }
    }

    public List<PlayerConfiguration> GetPlayerConfigs()
    {
        return _playerConfigs;
    }

    public void SetPlayerColor(int index, Material color)
    {
        _playerConfigs[index].playerMaterial = color;
    }

    public void ReadyPlayer(int index)
    {
        _playerConfigs[index].isReady = true;
        if (_playerConfigs.Count == maxPlayers && _playerConfigs.All(p => p.isReady == true))
        {
            OnAllReady.Invoke();
        }
    }
}

public class PlayerConfiguration
{
    public PlayerConfiguration(PlayerInput pi)
    {
        PlayerIndex = pi.playerIndex;
        Input = pi;
    }

    public PlayerInput Input { get; private set; }
    public int PlayerIndex { get; private set; }
    public bool isReady { get; set; }
    public Material playerMaterial { get; set; }
}