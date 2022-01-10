using System;
using UnityEngine;
using TMPro;

namespace Code
{
    public class GameController : MonoBehaviour
    {
        public GameTime GameTime = new GameTime();
        public TextMeshProUGUI TextField;
        public GameObject SunObject;

        private void Start()
        {
            Time.timeScale = 60.0f;
        }

        private void Update()
        {
            GameTime.Update();

            TextField.text = GameTime.ToString();
            SunObject.transform.rotation = Quaternion.Euler(GameTime.SunRotation(), 90.0f, 0.0f);
        }
    }
}