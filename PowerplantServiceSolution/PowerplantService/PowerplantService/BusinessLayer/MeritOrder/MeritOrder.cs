using System;
using System.Collections.Generic;
using PowerplantService.BusinessLayer.Intefaces;
using PowerplantService.DataModel;

namespace PowerplantService.BusinessLayer
{
    /// <summary>
    /// Class to manage merit order
    /// </summary>
	public class MeritOrder : IMeritOrder
    {
		private IPowerplant _powerplant;

		public MeritOrder(IPowerplant Powerplant)
		{
			this._powerplant = Powerplant;
		}

        /// <summary>
        /// Determine merit order
        /// </summary>
        /// <param name="fuel">Fuel as input</param>
        /// <param name="powerplants">Powerplant list with all info</param>
        /// <returns>Merit list of powerplant</returns>
        public Dictionary<string, double> DecideMeritOrder(Fuel fuel, List<Powerplant> powerplants)
		{
			Dictionary<string, double> plantCost = new Dictionary<string, double>();
            Dictionary<string, double> meritOrder = new Dictionary<string, double>();

            double cost = 0.0;
			foreach(Powerplant p in powerplants)
			{
				if (p != null)
				{
					if (p.Type.ToLower() == PowerplantType.gasfired.ToString().ToLower())
					{
						this._powerplant = new GasPowerplant();
                        cost = this._powerplant.CalculatePrice(fuel.GasCost, p.Efficiency);
                    }
					else if (p.Type.ToLower() == PowerplantType.turbojet.ToString().ToLower())
					{
                        this._powerplant = new TurbojetPowerplant();
                        cost = this._powerplant.CalculatePrice(fuel.KerosineCost, p.Efficiency);
                    }
					else if (p.Type.ToLower() == PowerplantType.windturbine.ToString().ToLower())
					{
                        this._powerplant = new WindPowerplant();
                        cost = this._powerplant.CalculatePrice(0, p.Efficiency);
                    }
                    plantCost.Add(p.Name != null ? p.Name: string.Empty, value: cost);
                    
                }
			}

            // Create the merit list
            var items = from d in plantCost orderby d.Value ascending select d;

            foreach (KeyValuePair<string, double> i in items.OrderBy(key => key.Value))
            {
                meritOrder.Add(i.Key, i.Value);
            }

            return meritOrder;
        }

    }
}

