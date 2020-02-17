using System;

namespace AVToolkit
{
    public class ProgEventArgs : EventArgs
    {
        public ProgEventArgs(double progressPercentage)
        {
            ProgPercentage = progressPercentage;
        }

        /// <summary>
        ///     Gets or sets a token whether the Op that reports the progress should be canceled.
        /// </summary>
        public bool Cancel { get; set; }

        /// <summary>
        ///     Gets the progress percentage in a range from 0.0 to 100.0.
        /// </summary>
        public double ProgPercentage { get; }
    }
}