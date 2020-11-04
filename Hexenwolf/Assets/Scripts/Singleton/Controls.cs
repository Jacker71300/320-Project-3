using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : Singleton<Controls>
{
    public KeyCode Left  { get { return keys[0]; } }
    public KeyCode Right { get { return keys[1]; } }
    public KeyCode Up    { get { return keys[2]; } }
    public KeyCode Down  { get { return keys[3]; } }
    public KeyCode Fire  { get { return keys[4]; } }

    private KeyCode[] keys = new KeyCode[5];
    private string[] keyLocations = new string[] { "left", "right", "up", "down", "fire" };

    private bool updatingKeyCode = false;
    private int updatingKeyOfIndex;
    private Event keyEvent;

    override protected void Awake()
    {
        base.Awake();

        keys = new KeyCode[] { (KeyCode)System.Enum.Parse(typeof(KeyCode),PlayerPrefs.GetString(keyLocations[0], "A")),
            (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(keyLocations[1], "D")),
            (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(keyLocations[2], "W")),
            (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(keyLocations[3], "S")),
            (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(keyLocations[4], "Mouse0"))
        };
    }

    private void OnGUI()
    {
        if (updatingKeyCode)
        {
            //get what key is being pushed and assign it to the key being updated
            keyEvent = Event.current;
            if (keyEvent.isKey || keyEvent.isMouse)
            {
                updatingKeyCode = false;
                if (checkKeyCodeInUse(keyEvent))
                {
                    KeyCode temp;
                    if (keyEvent.isKey) temp = keyEvent.keyCode;
                    else temp = ConvertMouseIntToKeycode(keyEvent.button);
                    keys[updatingKeyOfIndex] = temp;
                    PlayerPrefs.SetString(keyLocations[updatingKeyOfIndex], keys[updatingKeyOfIndex].ToString());
                }
            }

        }
    }

    private bool checkKeyCodeInUse(Event key)
    {
        KeyCode code;
        if (keyEvent.isKey)
        {
            code = key.keyCode;
        }
        else
        {
            code = ConvertMouseIntToKeycode(key.button);
        }
        return !(code == Right || code == Left || code == Up || code == Down || code ==Fire);

    }


    public KeyCode ConvertMouseIntToKeycode(int key)
    {
        return (KeyCode)System.Enum.Parse(typeof(KeyCode), "Mouse" + key);
    }

    public void UpdateKeyOfIndex(int index)
    {
        updatingKeyCode = true;
        updatingKeyOfIndex = index;
    }
}
