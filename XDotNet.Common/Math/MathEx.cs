using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XDotNet.Math
{
    public class MathEx
    {
        /// <summary>
        /// 1 degree = Rad radians
        /// </summary>
        public const double Rad = System.Math.PI * 2 / 360;
        /// <summary>
        /// 1 radian = Deg degrees
        /// </summary>
        public const double Deg = 360 / (System.Math.PI * 2);

        public static double Deg2Rad(double deg)
        {
            return deg * Rad;
        }

        public static double Rad2Deg(double rad)
        {
            return rad * Deg;
        }

        /// <summary>
        /// Reversing angle in degrees. 0 -> 180, 90-> 270, 45 -> 225, etc.
        /// </summary>
        /// <param name="angleInDegrees">Angle in degrees.</param>
        /// <returns></returns>
        public static double ReverseAngleDeg(double angleInDegrees)
        {
            return (angleInDegrees + 180) % 360;
        }
    }
}
