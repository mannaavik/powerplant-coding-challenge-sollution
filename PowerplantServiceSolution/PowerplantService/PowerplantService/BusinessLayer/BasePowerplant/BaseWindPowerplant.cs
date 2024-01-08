using System;
using PowerplantService.DataModel;

namespace PowerplantService.BusinessLayer.BasePowerplant
{
    /// <summary>
    /// Class to manage Wind powerplant feature
    /// </summary>
	public class BaseWindPowerplant
	{
        /// <summary>
        /// Calvulate current pMax
        /// </summary>
        /// <param name="wind">Current wind</param>
        /// <param name="pMax">Maximum power</param>
        /// <returns>Maximum power at current time</returns>
        public virtual double CalculatePMax(double wind, double pMax)
        {
            return 0.00;
        }
    }
}

