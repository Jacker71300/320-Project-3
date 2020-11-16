using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public enum AudioState { Stealth, StealthToCombat, Combat, CombatToCombatEnd, CombatEnd, CombatEndToStealth };

    public AudioState currentState = AudioState.Stealth;

    [SerializeField] float bpmStealth = 140f;
    [SerializeField] float bpmCombat = 110f;
    [SerializeField] float bpmCombatEnd = 110f;
    [SerializeField] float beatsPerMeasure = 4;

    [SerializeField] AudioSource stealth;
    [SerializeField] AudioSource combat;
    [SerializeField] AudioSource combatEnd;

    float currentBeatStealth = 0f;
    float currentMeasureStealth = 0f;
    float currentDeltaStealth = 0f;

    float currentBeatCombat = 0f;
    float currentMeasureCombat = 0f;
    float currentDeltaCombat = 0f;

    float currentBeatCombatEnd = 0f;
    float currentMeasureCombatEnd = 0f;
    float currentDeltaCombatEnd = 0f;

    private void Update()
    {
        switch(currentState)
        {
            case AudioState.Stealth:
                UpdateStealth();

                currentBeatCombat = 0f;
                currentBeatCombatEnd = 0f;

                currentMeasureCombat = 0f;
                currentMeasureCombatEnd = 0f;

                currentDeltaCombat = 0f;
                currentDeltaCombatEnd = 0f;

                break;
            case AudioState.StealthToCombat:
                UpdateStealth();

                if(currentBeatStealth == 3 || currentBeatStealth == 1)
                {
                    currentBeatStealth = 3; // keep the track playing until it's faded out
                    Crossfade(stealth, combat);
                    UpdateCombat();
                }
                break;
            case AudioState.Combat:
                UpdateCombat();

                currentBeatStealth = 0f;
                currentBeatCombatEnd = 0f;

                currentMeasureStealth = 0f;
                currentMeasureCombatEnd = 0f;

                currentDeltaStealth = 0f;
                currentDeltaCombatEnd = 0f;
                break;
            case AudioState.CombatToCombatEnd:
                UpdateCombat();
                if (currentBeatCombat == 0)
                {
                    currentBeatCombat = 0; // keep the track playing until it's faded out
                    if (Crossfade(combat, combatEnd))
                        currentState = AudioState.CombatEnd;
                    UpdateCombatEnd();
                }
                break;
            case AudioState.CombatEnd:
                UpdateCombatEnd();

                if (currentMeasureCombatEnd == 1) // switch back on measure 2
                    currentState = AudioState.CombatEndToStealth;

                currentBeatStealth = 0f;
                currentBeatCombat = 0f;

                currentMeasureStealth = 0f;
                currentMeasureCombat = 0f;

                currentDeltaStealth = 0f;
                currentDeltaCombat = 0f;
                break;
            case AudioState.CombatEndToStealth:
                UpdateCombatEnd();
                if (currentBeatCombatEnd == 3 && currentMeasureCombatEnd == 1)
                {
                    currentBeatCombatEnd = 3; // keep the track playing until it's faded out
                    if (Crossfade(combatEnd, stealth))
                        currentState = AudioState.Stealth;
                    UpdateStealth();
                }
                break;
        }
    }

    /// <summary>
    /// Crossfades between two songs
    /// </summary>
    /// <param name="current">the currently playing song</param>
    /// <param name="next">the song to transition to</param>
    /// <returns>true if crossfade is completed</returns>
    private bool Crossfade(AudioSource current, AudioSource next)
    {
        bool cur = false;
        bool nex = false;

        if(current.volume <= 0.01f)
        {
            current.volume = 0.0f;
            current.enabled = false;
            cur = true;
        }
        else
        {
            current.volume -= 0.01f;
        }


        if(next.volume == 0f)
        {
            next.enabled = true;
        }
        else if(next.volume >= 1f)
        {
            next.volume = 1f;
            nex = true;
        }
        else
        {
            next.volume += 0.01f;
        }

        return (cur && nex);
    }

    private void UpdateStealth()
    {
        currentDeltaStealth += Time.deltaTime;
        if (currentDeltaStealth >= 60 / bpmStealth)
        {
            currentBeatStealth += 1;
            currentDeltaStealth -= 60 / bpmStealth;

            if (currentBeatStealth >= beatsPerMeasure)
            {
                currentBeatStealth = 0;
                currentMeasureStealth += 1;
            }

        }

    }

    private void UpdateCombat()
    {
        currentDeltaCombat += Time.deltaTime;
        if (currentDeltaCombat >= 60 / bpmCombat)
        {
            currentBeatCombat += 1;
            currentDeltaCombat -= 60 / bpmCombat;

            if (currentBeatCombat >= beatsPerMeasure)
            {
                currentBeatCombat = 0;
                currentMeasureCombat += 1;
            }

        }

    }

    private void UpdateCombatEnd()
    {
        currentDeltaCombatEnd += Time.deltaTime;
        if (currentDeltaCombatEnd >= 60 / bpmCombatEnd)
        {
            currentBeatCombatEnd += 1;
            currentDeltaCombatEnd -= 60 / bpmCombatEnd;

            if (currentBeatCombatEnd >= beatsPerMeasure)
            {
                currentBeatCombatEnd = 0;
                currentMeasureCombatEnd += 1;
            }

        }

    }
}
