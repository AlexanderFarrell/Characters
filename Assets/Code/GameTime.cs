using System;
using UnityEngine;

namespace Code
{
    /// <summary>
    /// Keeps track of the day and night cycle.
    /// </summary>
    public class GameTime
    {
        public int Hour = 0;
        public int Minute = 0;
        public float RemainingTime = 0.0f;

        public Vector3 SunPosition()
        {
            float progression = (float)((Hour / 24.0f) * Math.PI * 2.0f) - (float)Math.PI/2.0f;
            return new Vector3(
                (float)Math.Sin(progression), 
                (float)Math.Cos(progression), 
                0.0f); //Sine and Cosine, and Tangent
        }

        public float SunRotation()
        {
            float progression = (float)(((Hour + (Minute/60.0f)) / 24.0f) * Math.PI * 2.0f) - (float)Math.PI/2.0f;

            return Mathf.Rad2Deg * progression;
        }
        
        public bool IsDay()
        {
            return Hour >= 6 && Hour < 18;
        }

        public bool IsAM()
        {
            return Hour < 12;
        }

        public override string ToString()
        {
            //return $"{Hour}:{Minute}"; //Military Time   Hour - 5   Minute - 54   5:54

            var newHour = Hour;
            if (newHour == 0)
            {
                newHour = 12;
            }
            else if (newHour > 12)
            {
                newHour -= 12;
            }

            var minute = $"{((Minute >= 10) ? $"{Minute}" : $"0{Minute}")}";

            return $"{newHour}:{minute} {(IsAM() ? "AM" : "PM")}";
        }

        public void Update()
        {
            RemainingTime += Time.deltaTime; 
            //0.017
            //2.0

            if (RemainingTime > 1.0f)
            {
                var seconds = Mathf.Floor(RemainingTime);
                RemainingTime -= seconds; //1.7 - 1.0 = 0.7

                Minute += (int)seconds;

                if (Minute >= 60)
                {
                    Minute -= 60;
                    Hour += 1;

                    if (Hour >= 24)
                    {
                        Hour -= 24;
                    } 
                }
            }
        }
    }
}