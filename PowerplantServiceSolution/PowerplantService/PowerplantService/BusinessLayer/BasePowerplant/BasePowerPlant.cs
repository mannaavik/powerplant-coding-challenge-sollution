using System;
using PowerplantService.BusinessLayer.Intefaces;
using PowerplantService.DataModel;

namespace PowerplantService.BusinessLayer.BasePowerplant
{
    /// <summary>
    /// Class to manage Wind powerplant feature
    /// </summary>
	public class BasePowerPlant : IPowerplant
    {
        /// <summary>
        /// Calculate cost of powerplant
        /// </summary>
        /// <param name="fuelRate">fuel cost</param>
        /// <param name="efficiency">efficiency</param>
        /// <returns>Cost</returns>
        public virtual double CalculatePrice(double gasRate, double efficiency)
        {
            return Math.Round((gasRate * 100) / (efficiency * 100), 2);
        }
    }
}

