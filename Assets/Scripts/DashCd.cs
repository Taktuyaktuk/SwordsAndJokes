using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class DashCd : MonoBehaviour
{
    [Header("Ability 1")]
    public Image abilityImage1;
    public float coolDownTime;
    bool isColdown = false;
    //public KeyCode ability1;


    // Start is called before the first frame update
    void Start()
    {
        abilityImage1.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Ability1();
    }

    void Ability1()
    {
        if ((Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.Mouse1) && isColdown == false))
        {
            isColdown = true;
            abilityImage1.fillAmount = 1;
        }
        else if ((Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Mouse1) && isColdown == false))
        {
            isColdown = true;
            abilityImage1.fillAmount = 1;
        }

        else if ((Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Mouse1) && isColdown == false))
        {
            isColdown = true;
            abilityImage1.fillAmount = 1;
        }

        else if ((Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Mouse1) && isColdown == false))
        {
            isColdown = true;
            abilityImage1.fillAmount = 1;
        }

        if (isColdown)
        {
            abilityImage1.fillAmount -= 1 / coolDownTime * Time.deltaTime;

            if (abilityImage1.fillAmount <= 0)
            {
                abilityImage1.fillAmount = 0;
                isColdown = false;
            }
        }
    }
}
