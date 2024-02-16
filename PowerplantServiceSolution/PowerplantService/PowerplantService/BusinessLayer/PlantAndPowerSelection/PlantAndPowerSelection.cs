using System;
using System.Collections.Generic;
using System.Resources;
using PowerplantService.BusinessLayer.BasePowerplant;
using PowerplantService.BusinessLayer.Intefaces;
using PowerplantService.DataModel;

namespace PowerplantService.BusinessLayer
{
    /// <summary>
    /// Class to manage gnerated and required power by plants
    /// </summary>
	public class PlantAndPowerSelection : IPlantAndPowerSelection
    {
        private IMeritOrder _meritOrder;
        private IWindPowerPlant _windPowerplant;

        public PlantAndPowerSelection(IMeritOrder meritOrder, IWindPowerPlant windPowerplant)
        {
            this._meritOrder = meritOrder;
            this._windPowerplant = windPowerplant;
        }

        /// <summary>
        /// Determine list of powerplants and their generated power
        /// </summary>
        /// <param name="resources">All resources</param>
        /// <returns>List of powerplnats and power</returns>
        public List<RequiredPowerPlant> SelectPlantAndPower(Resources resources)
        {
            List<RequiredPowerPlant> reqPowerplants = new List<RequiredPowerPlant>();
            Dictionary<string, double> meritOrder = this._meritOrder.DecideMeritOrder(resources.Fuels, resources.Powerplants);
            double alreadyGeneratedPower = 0.00;
            foreach (KeyValuePair<string, double> item in meritOrder)
            {
                if (resources.Powerplants.Any(p => p.Name.ToLower() == item.Key.ToLower()))
                {
                    Powerplant selectedPlant = resources.Powerplants.Where(p => p.Name.ToLower() == item.Key.ToLower()).First();
                    RequiredPowerPlant reqPlant = new RequiredPowerPlant();
                    if (selectedPlant.Type.ToLower() == PowerplantType.gasfired.ToString().ToLower())
                    {
                        reqPlant.P = DeterminePower(alreadyGeneratedPower, selectedPlant.Pmax, resources.Load);
                    }
                    else if (selectedPlant.Type.ToLower() == PowerplantType.turbojet.ToString().ToLower())
                    {
                        reqPlant.P = DeterminePower(alreadyGeneratedPower, selectedPlant.Pmax, resources.Load);
                    }
                    else if (selectedPlant.Type.ToLower() == PowerplantType.windturbine.ToString().ToLower())
                    {
                        this._windPowerplant = new WindPowerPlant();
                        double pMaxBasedOnWind = this._windPowerplant.CalculatePMax(resources.Fuels.Wind, selectedPlant.Pmax);
                        reqPlant.P = DeterminePower(alreadyGeneratedPower, pMaxBasedOnWind, resources.Load);
                    }

                    reqPlant.Name = selectedPlant.Name;
                    reqPowerplants.Add(reqPlant);
                    alreadyGeneratedPower = alreadyGeneratedPower + reqPlant.P;
                }
            }
            return reqPowerplants;
        }

        /// <summary>
        /// Determine required power
        /// </summary>
        /// <param name="alreadyGeneratedPower">Already generated power</param>
        /// <param name="pMax">Maximum power of a powerplant</param>
        /// <param name="totalLoad">Total load required</param>
        /// <returns>Generated power by plant</returns>
        private double DeterminePower(double alreadyGeneratedPower, double pMax, double totalLoad)
        {
            if (alreadyGeneratedPower < totalLoad)
            {
                if (totalLoad - alreadyGeneratedPower > pMax)
                {
                    return pMax;
                }
                else
                {
                    return totalLoad - alreadyGeneratedPower;
                }
            }
            else
            {
                return 0.00;
            }
        }
    }
}

