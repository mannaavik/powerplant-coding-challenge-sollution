using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PowerplantService.BusinessLayer;
using PowerplantService.BusinessLayer.Intefaces;
using PowerplantService.Controllers;
using PowerplantService.DataModel;

namespace PowerplantServiceTest.TestControllers
{
	public class TestPowerPlantController
	{
        [Theory]
        [ClassData(typeof(ResourceTestData))]
        public void TestDecidePowerplants(Resources resources)
        {
            //Arrange
            IFuelPowerPlant pp = new GasPowerplant();
            MeritOrder mo = new MeritOrder(pp);
            WindPowerPlant windPlant = new WindPowerPlant();
            PlantAndPowerSelection plantSelection = new PlantAndPowerSelection(mo, windPlant);
            PowerplantController powerPlantCtrl = new PowerplantController(plantSelection);

            //Act
            var decidePlantResult = powerPlantCtrl.DecidePowerplants(resources);

            //Assert
            Assert.NotNull(decidePlantResult);
        }

        [Fact]
        public void TestDecidePowerplantsBadRequest()
        {
            //Arrange
            IFuelPowerPlant pp = new GasPowerplant();
            MeritOrder mo = new MeritOrder(pp);
            WindPowerPlant windPlant = new WindPowerPlant();
            PlantAndPowerSelection plantSelection = new PlantAndPowerSelection(mo, windPlant);
            PowerplantController powerPlantCtrl = new PowerplantController(plantSelection);

            //Act
            var decidePlantResult = powerPlantCtrl.DecidePowerplants(resources: null);

            //Assert
            Assert.IsType<BadRequestResult>(decidePlantResult);
        }
    }


    public class ResourceTestData : TheoryData<Resources>
    {
        public ResourceTestData()
        {
            PowerPlant gasfiredbig1 = new PowerPlant { Name = "gasfiredbig1", Type = "gasfired", Efficiency = 0.53, Pmin = 100, Pmax = 460 };
            PowerPlant gasfiredbig2 = new PowerPlant { Name = "gasfiredbig2", Type = "gasfired", Efficiency = 0.53, Pmin = 100, Pmax = 460 };
            PowerPlant gasfiredsomewhatsmaller = new PowerPlant { Name = "gasfiredsomewhatsmaller", Type = "gasfired", Efficiency = 0.37, Pmin = 40, Pmax = 210 };
            PowerPlant tj1 = new PowerPlant { Name = "tj1", Type = "turbojet", Efficiency = 0.3, Pmin = 0, Pmax = 16 };
            PowerPlant windpark1 = new PowerPlant { Name = "windpark1", Type = "windturbine", Efficiency = 1, Pmin = 0, Pmax = 150 };
            PowerPlant windpark2 = new PowerPlant { Name = "windpark2", Type = "windturbine", Efficiency = 1, Pmin = 0, Pmax = 36 };
            List<PowerPlant> plantList = new List<PowerPlant>();
            plantList.Add(gasfiredbig1);
            plantList.Add(gasfiredbig2);
            plantList.Add(gasfiredsomewhatsmaller);
            plantList.Add(tj1);
            plantList.Add(windpark1);
            plantList.Add(windpark2);

            Fuel fuels = new Fuel { GasCost = 13.4, KerosineCost = 50.8, Co2Cost = 20, Wind = 60 };
            Resources resources = new Resources
            {
                Load = 910,
                Fuels = fuels,
                Powerplants = plantList
            };

            Add(resources);
        }
    }
}

