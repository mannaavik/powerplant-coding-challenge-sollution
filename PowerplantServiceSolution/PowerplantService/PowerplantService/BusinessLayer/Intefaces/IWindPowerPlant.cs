using System;
namespace PowerplantService.BusinessLayer.Intefaces
{
    /// <summary>
	/// Interface to manage wind plant functionalities
	/// </summary>
	public interface IWindPowerPlant
	{
        // <summary>
        /// Calvulate current pMax
        /// </summary>
        /// <param name="wind">Current wind</param>
        /// <param name="pMax">Maximum power</param>
        /// <returns>Maximum power at current time</returns>
        public double CalculatePMax(double wind, double pMax);
    }
}

