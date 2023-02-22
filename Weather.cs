namespace WeatherApp
{
    public enum MeasureUnits
    {
        Celsius,
        Fahrenheit,
        Kelvin
    }

    internal class Weather
    {
        private int _temperature;
        private MeasureUnits _measureUnit = MeasureUnits.Celsius;
        private City _city;

        public int Temperature
        {
            get => _temperature;
        }

        public MeasureUnits MeasureUnit
        {
            get => _measureUnit;
        }

        private City City
        {
            get => _city;
        }

        public string CityName
        {
            get { return City != null ? City.Name : "Не назначено"; }
        }

        public Weather(int temperature, MeasureUnits measureUnit, City city)
        {
            _temperature = temperature;
            _measureUnit = measureUnit;
            _city = city;
        }


    }
}
