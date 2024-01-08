using System;
using System.Resources;
using PowerplantService.BusinessLayer.BasePowerplant;
using PowerplantService.BusinessLayer.Intefaces;
using PowerplantService.DataModel;

namespace PowerplantService.BusinessLayer
{
    /// <summary>
    /// Class to manage Wind powerplants
    /// </summary>
	public class WindPowerplant: BaseWindPowerplant, IPowerplant
    {
        /// <summary>
        /// Calculate cost of powerplant
        /// </summary>
        /// <param name="fuelRate">fuel cost</param>
        /// <param name="efficiency">efficiency</param>
        /// <returns>Cost</returns>
        public double CalculatePrice(double fuelRate, double efficiency)
        {
            return Math.Round((fuelRate * 100) / (efficiency * 100), 2);
        }

        /// <summary>
        /// Calculate PMax of powerplant
        /// </summary>
        /// <param name="wind">current wind value</param>
        /// <param name="pMax">Maximum power</param>
        /// <returns>Current possible maximum power</returns>
        public override double CalculatePMax(double wind, double pMax)
        {
            return Math.Round((wind * pMax) / 100, 2);
        }
    }
}

