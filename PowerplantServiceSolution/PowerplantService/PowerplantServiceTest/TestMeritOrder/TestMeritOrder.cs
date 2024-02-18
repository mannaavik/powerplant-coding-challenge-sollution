using System;
using PowerplantService.BusinessLayer;
using PowerplantService.BusinessLayer.Intefaces;
using PowerplantService.DataModel;

namespace PowerplantServiceTest.TestMeritOrder
{
    public class TestMeritOrder
	{
		[Theory]
        [ClassData(typeof(MeritOrderTestData))]
		public void TestDecideMeritOrder(Fuel fuel, List<PowerPlant> powerplants)
		{
			//Arrange
			IFuelPowerPlant pp = new GasPowerplant();
			MeritOrder mo = new MeritOrder(pp);

            //Act
            var meritOrderResult = mo.DecideMeritOrder(fuel, powerplants);

			//Assert
			Assert.NotNull(meritOrderResult);
			Assert.Equal(6, meritOrderResult.Count);
			Assert.Equal(0, meritOrderResult["windpark1"]);
            Assert.Equal(0, meritOrderResult["windpark2"]);
            Assert.Equal(25.28, meritOrderResult["gasfiredbig1"]);
            Assert.Equal(25.28, meritOrderResult["gasfiredbig2"]);
            Assert.Equal(36.22, meritOrderResult["gasfiredsomewhatsmaller"]);
            Assert.Equal(169.33, meritOrderResult["tj1"]);
        }
    }

	
}

public class MeritOrderTestData : TheoryData<Fuel, List<PowerPlant>>
{
	public MeritOrderTestData()
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

        Add(new Fuel { GasCost = 13.4, KerosineCost = 50.8, Co2Cost = 20, Wind = 60 } , plantList);
	}
}

