using System;
using Microsoft.AspNetCore.Mvc;
using PowerplantService.BusinessLayer.Intefaces;
using PowerplantService.DataModel;

namespace PowerplantService.Controllers
{
    /// <summary>
    /// Powerplant controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PowerplantController: ControllerBase
    {
        private IPlantAndPowerSelection _plantSelection;
        
        public PowerplantController(IPlantAndPowerSelection plantSelection)
		{
            this._plantSelection = plantSelection;
        }

        /// <summary>
        /// Powerplant post api
        /// </summary>
        /// <param name="resources">Resources object</param>
        /// <returns>List of powerplant and required power</returns>
        [HttpPost(Name = "productionplan")]
        public IEnumerable<RequiredPowerplant> DecidePowerplants(Resources resources)
        {
            List<RequiredPowerplant> powerplants = new List<RequiredPowerplant>();
            if (resources != null)
            {
                powerplants = this._plantSelection.SelectPlantAndPower(resources);
            }
            return powerplants.ToArray();
        }
	}
}

