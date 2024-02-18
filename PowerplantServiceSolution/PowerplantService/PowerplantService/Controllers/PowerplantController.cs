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
        [ProducesResponseType(typeof(List<RequiredPowerPlant>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DecidePowerplants(Resources resources)
        {
            List<RequiredPowerPlant> powerplants = new List<RequiredPowerPlant>();
            if (resources != null)
            {
                powerplants = this._plantSelection.SelectPlantAndPower(resources);
                return Ok(powerplants.ToArray());
            }
            else
            {
                return BadRequest();
            }
        }
	}
}

