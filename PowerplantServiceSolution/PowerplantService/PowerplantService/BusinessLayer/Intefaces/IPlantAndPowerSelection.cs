using System;
using PowerplantService.DataModel;

namespace PowerplantService.BusinessLayer.Intefaces
{
    /// <summary>
    /// Interface to determine plant and generated power
    /// </summary>
	public interface IPlantAndPowerSelection
    {
        /// <summary>
        /// Determine plant list with generated power
        /// </summary>
        /// <param name="resources">Resources</param>
        /// <returns>Powerplant list with power</returns>
        List<RequiredPowerPlant> SelectPlantAndPower(Resources resources);
    }
}

