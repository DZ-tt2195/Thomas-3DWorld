using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class RebindControl : MonoBehaviour
{
    public InputActionReference action;
    int bindingIndex;

    TMP_Text bindingtext;
    Button button;
    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    // Start is called before the first frame update
    void Awake()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(StartRebinding);
        bindingtext = this.transform.GetChild(0).GetComponent<TMP_Text>();
        bindingIndex = action.action.GetBindingIndexForControl(action.action.controls[0]);

        bindingtext.text = InputControlPath.ToHumanReadableString(
            action.action.bindings[bindingIndex].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice);
    }

    public void StartRebinding()
    {
        MainMenu.instance.PlayMenu();
        bindingtext.text = "Enter Input";

        rebindingOperation = action.action.PerformInteractiveRebinding()
            
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => RebindComplete())
            .Start();
    }

    private void RebindComplete()
    {
        bindingtext.text = InputControlPath.ToHumanReadableString(
            action.action.bindings[bindingIndex].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice);

        rebindingOperation.Dispose();
        OverlappingControls.instance.Ping();
    }
}
