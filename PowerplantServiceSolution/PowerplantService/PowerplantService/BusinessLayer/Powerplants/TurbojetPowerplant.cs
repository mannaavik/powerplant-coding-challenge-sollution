using System;
using PowerplantService.BusinessLayer.BasePowerplant;
using PowerplantService.BusinessLayer.Intefaces;
using PowerplantService.DataModel;

namespace PowerplantService.BusinessLayer
{
    /// <summary>
	/// Class to manage Turbojet powerplants
	/// </summary>
	public class TurbojetPowerplant : IPowerplant
    {
        /// <summary>
        /// Calculate cost of powerplant
        /// </summary>
        /// <param name="fuelRate">fuel cost</param>
        /// <param name="efficiency">efficiency</param>
        /// <returns>Cost</returns>
        public double CalculatePrice(double kerosineRate, double efficiency)
        {
            return Math.Round((kerosineRate * 100) / (efficiency * 100), 2);
        }
    }
}

