using System;
using PowerplantService.BusinessLayer.Intefaces;
using PowerplantService.DataModel;

namespace PowerplantService.BusinessLayer.BasePowerplant
{
    /// <summary>
    /// Class to manage all powerplant feature
    /// </summary>
	public abstract class BasePowerPlant : IFuelPowerPlant, IWindPowerPlant
    {
        /// <summary>
        /// Calculate PMax of powerplant
        /// </summary>
        /// <param name="fuelRate">fuel cost</param>
        /// <param name="efficiency">efficiency</param>
        /// <returns>Cost</returns>
        public abstract double CalculatePMax(double wind, double pMax);

        /// <summary>
		/// Calculate price of powerplant
		/// </summary>
		/// <param name="fuelRate">Fuel rate</param>
		/// <param name="efficiency">Efficiency</param>
		/// <returns>Cost</returns>
		public abstract double CalculatePrice(double fuelRate, double efficiency);
    }
}

