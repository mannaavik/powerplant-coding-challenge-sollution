using System;
using PowerplantService.DataModel;

namespace PowerplantService.BusinessLayer.Intefaces
{
	/// <summary>
	/// Interface to manage plant price and others
	/// </summary>
	public interface IFuelPowerPlant
	{
		/// <summary>
		/// Calculate price of powerplant
		/// </summary>
		/// <param name="fuelRate">Fuel rate</param>
		/// <param name="efficiency">Efficiency</param>
		/// <returns>Cost</returns>
		public double CalculatePrice(double fuelRate, double efficiency);
    }
}

