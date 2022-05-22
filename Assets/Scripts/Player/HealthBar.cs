using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public Player player;

    private void Start()
    {
        player = Player.instance;
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = player.health;
        healthBar.value = player.health;
    }

    private void Update() {
        healthBar.value = player.health;
    }
    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }
}