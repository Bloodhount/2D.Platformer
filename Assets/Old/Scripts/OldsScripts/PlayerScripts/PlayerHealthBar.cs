using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private Text _healthText;//
    private float _curHealth;
    private float _maxHealth = 10;

    private float fill;


    // Start is called before the first frame update
    void Start()
    {
        _healthBar.fillAmount = _maxHealth;
        
        _curHealth = _healthBar.fillAmount ;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            _healthBar.fillAmount -= 0.1f;
            _curHealth = _healthBar.fillAmount;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //HealthBar(0.01f);
       // _healthBar.fillAmount -= 0.1f; 
        _healthText.text = "ENERGY %" + _curHealth.ToString();
    }

    public void HealthBar(float fNum)
    {
        _healthBar.fillAmount -= fNum;
        //_healthBar.fillAmount = fNum / _maxHealth;
    }
}
