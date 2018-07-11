using System;
using FluentAssertions;
using FluentAssertions.Collections;
using Moq;
using Xunit;

namespace temperature.test {
    public class UnitTest1 {
        [Theory (DisplayName = "เปลี่ยนค่า องศา Fahrenheit ให้เป็น Celsius ได้สำเร็จ")]
        [InlineData (32, 0)]
        [InlineData (35.000006, 1.67)]  // 1.6666699999999994
        [InlineData (64, 17.78)]         // 17.777777777777779
        [InlineData (0, -17.78)]         //-17.777777777777779
        [InlineData (105, 40.56)]        //40.555555555555557
        [InlineData (1214, 656.67)] 
        [InlineData (121, 49.44)] 
        [InlineData (-8.1, -22.28)] 
        public void ConvertFahrenheitToCelsiusSuccess (double input, double  expectedResult) {
            var cal = new TempCalculator ();
            var x = cal.ConvertFahrenheitToCelsius (input);

            x.Should ().Be (expectedResult);
        }

        [Theory (DisplayName = "เปลี่ยนค่า องศา Kelvin ให้เป็น Celsius ได้สำเร็จ")]
        [InlineData (363.15, 90)]
        //[InlineData (373.15, 100)]
        [InlineData (-23.2, -296.35)]
        public void ConvertKelvinToCelsiusSuccess (double input, double expectedResult) {
            var cal = new TempCalculator ();
            var x = cal.ConvertKelvinToCelsius (input);

            x.Should ().Be (expectedResult);
        }

        [Theory (DisplayName = "เปลี่ยนค่า องศา celsius ให้เป็น Fahrenheit ได้สำเร็จ")]
        [InlineData (90, 194)]
        [InlineData (-1.5, 29.3)]
        
        public void ConvertCelsiusToFahrenheitSuccess (double input, double expectedResult) {
            var cal = new TempCalculator ();
            var x = cal.ConvertCelsiusToFahrenheit (input);

            x.Should ().Be (expectedResult);
        }

        [Theory (DisplayName = "เปลี่ยนค่า องศา Kelvin ให้เป็น Fahrenheit ได้สำเร็จ")]
        [InlineData (90, -297.67)]
        [InlineData (91.04, -295.80)]
        
        
        public void ConvertKelvinToFahrenheitSuccess (double input, double expectedResult) {
            var cal = new TempCalculator ();
            var x = cal.ConvertKelvinToFahrenheit (input);

            x.Should ().Be (expectedResult);
        }

        [Theory (DisplayName = "เปลี่ยนค่า องศา Fahrenheit ให้เป็น Kelvin ได้สำเร็จ")]
        [InlineData (-297.67, 90)]
        //[InlineData (-297.67, 90.0000)]
        public void ConvertFahrenheitToKelvinSuccess (double input, double expectedResult) {
            var cal = new TempCalculator ();
            var x = cal.ConvertFahrenheitToKelvin (input);

            x.Should ().Be (expectedResult);
        }

        [Theory (DisplayName = "เปลี่ยนค่า องศา celsius ให้เป็น Kelvin ได้สำเร็จ")]
        [InlineData (90, 363.15)]
        [InlineData (-12.9, 260.25)]
        public void ConvertCelsiusToKelvinSuccess (double input, double expectedResult) {
            var cal = new TempCalculator ();
            var x = cal.ConvertCelsiusToKelvin (input);

            x.Should ().Be (expectedResult);
        }
        // [Theory (DisplayName = "ไม่มีข้อมูล")]
        // [InlineData ("", "fail")]
        // [InlineData (null, "fail")]
        // public void NotSuccess (string input, string  expectedResult) {
        //     var cal = new TempCalculator ();
        //     var x = cal.NoData (input);
        //     x.Should ().Be (expectedResult);
        // }


    }
}