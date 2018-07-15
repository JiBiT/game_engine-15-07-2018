using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.ressources.Scripts
{
    public class Health : MonoBehaviour
    {
        public const float maxHealth = 100;
        public float currentHealth = maxHealth;

        [SerializeField]
        private float fillAmount;

        [SerializeField]
        private Image Content;

        void Update()
        {
            HandleBar();
        }
        void HandleBar()
        {
            Content.fillAmount = Map(currentHealth, 0, maxHealth, 0, 1);
        }
        public float Map(float value, float inMin, float inMax, float outMin, float outMax)
        {
            return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        }
        public float TakeDamage(float amount)
        {
            currentHealth -= amount;
            //if(currentHealth <= 0)
            //{
            //    currentHealth = 0;
            //    Debug.Log("Dead!");
            //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //}
            return amount;
        }
    }
}
