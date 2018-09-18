using System;

namespace Sonos.Integration.ParameterValidation
{
    public class ParameterValidator : IParameterValidator
    {
        public void VolumeLevelCheck(int volume)
        {
            if (volume < 0)
            {
                throw new ArgumentException("Volume cannot be less than 0");
            }

            if (volume > 100)
            {
                throw new ArgumentException("Volume cannot be more than 100");
            }
        }
    }
}