using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ITMO_BIM_m1_2_lab06
{
    class WeatherControl: DependencyObject
    {
        private int tmprtr;
        private string wndDir;
        private int wndStr;
        private int osadki;

        //public int Temperature
        //{
        //    get => tmprtr;
        //    set
        //    {
        //        if (value >= -50 && value <= 50)
        //            tmprtr = value;
        //    }
        //}
        
        public static readonly DependencyProperty TemperatureProperty =
            DependencyProperty.Register(
                //"Temperature", // property Name
                nameof(Temperature), // property Name
                typeof(int), // property Type
                typeof(WeatherControl), // property-Owner Type
                new FrameworkPropertyMetadata( // property Metadata
                    null, // default value
                    FrameworkPropertyMetadataOptions.AffectsMeasure | // Flags
                        FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemperature),
                    true, // IsAnimationProhibited
                    System.Windows.Data.UpdateSourceTrigger.LostFocus), // DefaultUpdateSourceTrigger
                    new ValidateValueCallback(ValidateTemperatureValue)
                    );

        private static bool ValidateTemperatureValue(object value)
        {
            int v = (int)value;
            if (v >= -50 && v <= 50)
                return true;
            else
                return false;
        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v < -50)
                v = -50;
            if (v > 50)
                v = 50;
            return v;
        }

        public int Temperature
        {
            //get { return (int) GetValue(TemperatureProperty); }
            //set { SetValue(TemperatureProperty, value); } 
            get => (int) GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }

        public string WindDirection
        {
            get => wndDir;
            set
            {
                switch (value.Length)
                {
                    case 2:
                        {
                            if (value.EndsWith("В") | value.EndsWith("З"))
                                goto case 1;
                            break;
                        }
                    case 1:
                        {
                            if (value.StartsWith("Ю") | value.StartsWith("С"))
                                wndDir = value;
                            break;
                        }
                    default:
                        break;
                }
            }
        }
        public int WindStrength
        {
            get => wndStr;
            set
            {
                if (value >= 0)
                    wndStr = value;
            }
        }
        public int Osadki
        {
            get => osadki;
            set
            {
                if (value >= 0 || value <= 3)
                    osadki = value;
            }
        }
    }
}
