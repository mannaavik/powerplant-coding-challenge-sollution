using System;
using PowerplantService.DataModel;

namespace PowerplantService.BusinessLayer.Intefaces
{
	/// <summary>
	/// Inteface for merit order
	/// </summary>
	public interface IMeritOrder
	{
		/// <summary>
		/// Determine plant merit list
		/// </summary>
		/// <param name="fuel">fule detail</param>
		/// <param name="powerplants">plants list and info</param>
		/// <returns>Merit order</returns>
		public Dictionary<string, double> DecideMeritOrder(Fuel fuel, List<PowerPlant> powerplants);
    }
}

