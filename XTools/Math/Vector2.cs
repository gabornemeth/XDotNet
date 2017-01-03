//
// Vector2.cs
//
// Author:
//    Gabor Nemeth (gabor.nemeth.dev@gmail.com)
//
//    Copyright (C) 2015, Gabor Nemeth
//
using System;

namespace XTools.Math
{
    /// <summary>
    /// 2D vector
    /// </summary>
    public struct Vector2
    {
        public double X { get; set; }
        public double Y { get; set; }

        /// <summary>
        /// Gets the length of the vector.
        /// </summary>
        public double Length
        {
            get { return System.Math.Sqrt(X * X + Y * Y); }
        }

        public Vector2(double x, double y) : this()
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Gets the scalar multiplication value of two vectors.
        /// </summary>
        /// <param name="v1">First vector.</param>
        /// <param name="v2">Second vector.</param>
        /// <returns></returns>
        public static double MultiplyScalar(Vector2 v1, Vector2 v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y;
        }

        public static double GetAngle(Vector2 v1, Vector2 v2)
        {
            return System.Math.Acos(MultiplyScalar(v1, v2) / (v1.Length * v2.Length));
        }
    }
}
