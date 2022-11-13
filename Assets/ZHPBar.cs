using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZHPBar : MonoBehaviour
{
    public Image ZhealthBarimg;
    public GameObject Zombie;

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
        ZhealthBarimg.fillAmount = Zombie.GetComponent<hunt>().health;
    }
}
