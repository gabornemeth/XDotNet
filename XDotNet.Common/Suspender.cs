//
// EventSuspender.cs
//
// Author:
//    Gabor Nemeth (gabor.nemeth.dev@gmail.com)
//
//    Copyright (C) 2015, Gabor Nemeth
//
        
namespace XDotNet
{
    /// <summary>
    /// Helper class for temporarily suspend event handling
    /// </summary>
    public class Suspender
    {
        private int _count;

        /// <summary>
        /// Gets whether it is currently suspended
        /// </summary>
        public bool IsSuspended
        {
            get
            {
                return _count != 0;
            }
        }

        /// <summary>
        /// Suspend event handling
        /// </summary>
        public void Suspend()
        {
            _count++;
        }

        /// <summary>
        /// Allow event handling
        /// </summary>
        public void Allow()
        {
            _count--;
        }
    }
}
