using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalstophealthBar;
    [SerializeField] private Image currenthealthBar;

    private void Start()
    {
        totalstophealthBar.fillAmount = playerHealth.currentLives / 10;
    }

    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentLives / 10;
    }
}
