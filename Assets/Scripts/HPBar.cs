using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Image healthBarimg;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        HealthFill();
    }


    public void HealthFill()
    {
        healthBarimg.fillAmount = Player.GetComponent<health>().pHealth;
    }
}
