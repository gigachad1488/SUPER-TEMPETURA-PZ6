using System;
using System.Collections.Generic;

namespace WeatherApp
{
    public class WeatherDatabase
    {
        private Random _random = new Random();
        private int RandomInt
        {
            get => _random.Next(-30, 61);
        }
        internal List<Weather> Weathers { get; private set; }

        public void Initialize()
        {
            Weathers = new List<Weather>
            {
                new Weather(RandomInt, MeasureUnits.Celsius, new City("Абакан")),
                new Weather(RandomInt, MeasureUnits.Celsius, new City("Черногорск")),              
                new Weather(RandomInt, MeasureUnits.Kelvin, new City("Сорск")),
                new Weather(RandomInt, MeasureUnits.Celsius, new City("Абаза")),
                new Weather(RandomInt, MeasureUnits.Celsius, new City("Аскиз")),
                new Weather(RandomInt, MeasureUnits.Kelvin, new City("Боград")),
                new Weather(RandomInt, MeasureUnits.Celsius, new City("Таштып")),
                new Weather(RandomInt, MeasureUnits.Celsius, new City("Копьёво"))
            };
        }
    }
}