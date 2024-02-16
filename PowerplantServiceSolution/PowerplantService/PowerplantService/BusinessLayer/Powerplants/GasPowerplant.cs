using System;
using System.Resources;
using PowerplantService.BusinessLayer.BasePowerplant;
using PowerplantService.BusinessLayer.Intefaces;
using PowerplantService.DataModel;

namespace PowerplantService.BusinessLayer
{
	/// <summary>
	/// Class to manage Gas powerplants
	/// </summary>
	public class GasPowerplant : BasePowerPlant
    {
        /// <summary>
        /// Calculate cost of powerplant
        /// </summary>
        /// <param name="fuelRate">fuel cost</param>
        /// <param name="efficiency">efficiency</param>
        /// <returns>Cost</returns>
        public override double CalculatePrice(double gasRate, double efficiency)
		{
			return Math.Round((gasRate * 100) / (efficiency * 100), 2);
		}
    }
}

