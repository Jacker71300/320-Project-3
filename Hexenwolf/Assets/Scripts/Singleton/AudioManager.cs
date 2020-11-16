using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public enum AudioState { Stealth, Combat, CombatEnd };

    public AudioState currentState = AudioState.Stealth;
}
