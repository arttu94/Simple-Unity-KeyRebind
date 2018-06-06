using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class KeyRebind : MonoBehaviour
{
    public Button RebindButton;
    public Text ButtonInputText;
    bool AwaitingUserInput;
    public string BindKeyName;
    public string DefaultKeyName;
    // Use this for initialization
    void Start()
    {
        AwaitingUserInput = false;

        ButtonInputText.text = PlayerPrefs.GetString(BindKeyName, DefaultKeyName);
    }

    // Update is called once per frame
    void Update()
    {
        if(AwaitingUserInput)
        {
            if(Input.anyKeyDown)
            {
                foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(kcode))
                    {
                        Debug.Log("KeyCode down: " + kcode);
                        ButtonInputText.text = kcode.ToString();
                        PlayerPrefs.SetString(BindKeyName, kcode.ToString());
                    }
                }
                AwaitingUserInput = false;
            }
        }
        else
        {
            return;
        }
    }

    public void SetInputListeningFlag()
    {
        AwaitingUserInput = true;
    }
}

/*
     In your player controller you want to do something like this 
     
     Store the variables 
     
        public string ForwardKeybind;
        
        public KeyCode ForwardKeyCode;
     
     at the start/init, search for the right key
     
        foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (kcode.ToString() == ForwardKeybind)
                ForwardKeyCode = kcode;
        }
    
     later on you can check for your custom key like 
     
        if (Input.GetKey(entity.ForwardKeyCode))
        {
            input.y = 1.0f;
        }


*/
