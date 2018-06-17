using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Vault.World.Basics
{
    /* Klasse: Temperature
     * Diese Klasse dient zur internen Repräsentation von Temperaturen.
     * Sie ermöglicht vor allem eine schnelle Umrechnung in verschiedene Einheiten
     * und wird später noch weitere physikalische Eigenschaften in Abhängigkeit zur Temperatur stellen können.
     */

    class Temperature
    {
        private double temp = 0;

        public double Celsius
        {
            get => convertKelvinToCelsius(temp);
            set => temp = convertCelsiusToKelvin(value);
        }

        public double Kelvin
        {
            get => temp;
            set => temp = value;
        }

        public double Fahrenheit
        {
            get => convertKelvinToFahrenheit(temp);
            set => temp = convertFahrenheitToKelvin(value);
        }

        public Temperature(double initialValue, string scale = "Kelvin")
        {
            // Basierend auf der ausgewählten Skala wird der Anfangswert eingesetzt.
            switch (scale)
            {
                case "Kelvin":
                    Kelvin = initialValue;
                    break;
                case "Celsius":
                    Celsius = initialValue;
                    break;
                case "Fahrenheit":
                    Fahrenheit = initialValue;
                    break;
                #region sub-cases
                case "kelvin":
                    goto case "Kelvin";
                case "celsius":
                    goto case "Celsius";
                case "fahrenheit":
                    goto case "Fahrenheit";
                default:
                    goto case "Kelvin";
                    #endregion
            }
        }

        public static double convertFahrenheitToKelvin(double Fahrenheit) => (Fahrenheit + 459.67) / 1.8;

        public static double convertKelvinToFahrenheit(double Kelvin) => 1.8 * Kelvin + 459.67;

        public static double convertCelsiusToKelvin(double Celsius) => Celsius - 273.15;

        public static double convertKelvinToCelsius(double Kelvin) => Kelvin + 273.15;

        public static double convertCelsiusToFahrenheit(double Celsius) => 1.8 * Celsius - 32;

        public static double convertFahrenheitToCelsius(double Fahrenheit) => (Fahrenheit - 32) / 1.8;

        public double increment(string scale = "Kelvin")
        {
            switch (scale)
            {
                case "Kelvin":
                    return Kelvin++;
                case "Celsius":
                    return Celsius++;
                case "Fahrenheit":
                    return Fahrenheit++;
                #region sub-cases
                case "kelvin":
                    goto case "Kelvin";
                case "celsius":
                    goto case "Celsius";
                case "fahrenheit":
                    goto case "Fahrenheit";
                default:
                    goto case "Kelvin";
                    #endregion
            }
        }

        public static Temperature operator ++(Temperature temp)
        {
            temp.increment();
            return temp;
        }

        public static Temperature operator +(Temperature temp0, Temperature temp1)
        {
            return new Temperature(temp0.Kelvin + temp1.Kelvin);
        }

        public static Temperature operator -(Temperature temp0, Temperature temp1)
        {
            return new Temperature(temp0.Kelvin - temp1.Kelvin);
        }
    }
}
