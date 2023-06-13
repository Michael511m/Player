using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Hp : MonoBehaviour
{
    [SerializeField] Image imgSliderHp;
    [SerializeField] int MaxHp = 2;

    [SerializeField] private FloatSO scoreSO;
        
     int hp;
   
    void Start()
    {
        hp = MaxHp;
        UpdateUiSlider();
        
    }

    public void TakeDamage(int damage)
    {
        
        hp -= damage;
        
        UpdateUiSlider();
        if(hp <=0)
        {
            if (CompareTag("Player"))
            {
                
               GameManager.Instance.GoToEnd();               
                
            }                                    
                Destroy(gameObject);       
            }
    }

    void UpdateUiSlider()
    {
        if (imgSliderHp != null)
        {
            imgSliderHp.fillAmount = (float)hp / MaxHp;
            if(imgSliderHp.fillAmount<=0.4f)
            {
                imgSliderHp.color = Color.yellow;
            }
            else
            {
                imgSliderHp.color = Color.red;
            }
        }
    }

    public  void AddHp(int hp) 
    {
        int hpNeeded = MaxHp - this.hp;
        if(hpNeeded > hp)
        {
            this.hp += hp;
        }
        else
        {
            this.hp += hpNeeded;
        }
        UpdateUiSlider();
    }

}
