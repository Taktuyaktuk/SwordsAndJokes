using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DialogNpc : Interactable
{
    [SerializeField] private TextAssetsValue dialogValue;

    [SerializeField] private TextAsset myDialog;

    [SerializeField] private Notification branchingDialogNotification;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                dialogValue.value = myDialog;
                //branchingDialogNotification.Raise();
            }
        }
    }
}
