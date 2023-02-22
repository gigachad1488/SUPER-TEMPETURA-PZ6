using System.Linq;
using System.Windows.Forms;

namespace WeatherApp
{
    public partial class WeatherForm : Form
    {
        private WeatherDatabase _weather;

        public WeatherForm()
        {
            InitializeComponent();

            _weather = new WeatherDatabase();
            _weather.Initialize();
            
            comboBox1.Items.AddRange(new object[4] {"нет", MeasureUnits.Kelvin, MeasureUnits.Fahrenheit, MeasureUnits.Celsius });
            comboBox1.SelectedIndex = 0;
            WeatherDataGrid.DataSource = _weather.Weathers.ToList();
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                WeatherDataGrid.DataSource = _weather.Weathers.ToList();
            }
            else
            {
                var gor = _weather.Weathers.Where(s => s.CityName.ToLower().Contains(textBox1.Text.ToLower())).ToList();
                WeatherDataGrid.DataSource = gor;
            }
        }

        private void WeatherDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                WeatherDataGrid.DataSource = _weather.Weathers.ToList();
                return;
            }
            MeasureUnits me = new MeasureUnits();
            switch (comboBox1.SelectedItem)
            {
                case MeasureUnits.Celsius:
                    me = MeasureUnits.Celsius;
                    break;
                case MeasureUnits.Kelvin:
                    me = MeasureUnits.Kelvin;
                    break;
                case MeasureUnits.Fahrenheit:
                    me = MeasureUnits.Fahrenheit;
                    break;
            }

                var gor = _weather.Weathers.Where(s => s.MeasureUnit == me).ToList();
                WeatherDataGrid.DataSource = gor;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            WeatherDataGrid.DataSource = _weather.Weathers.ToList();
            comboBox1.SelectedIndex = 0;
            textBox1.Clear();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            var pl = _weather.Weathers.Where(s => s.Temperature > 0).ToList();
            WeatherDataGrid.DataSource = pl;
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            var sor = _weather.Weathers.OrderBy(s => s.Temperature).ToList();
            WeatherDataGrid.DataSource = sor;
        }
    }
}