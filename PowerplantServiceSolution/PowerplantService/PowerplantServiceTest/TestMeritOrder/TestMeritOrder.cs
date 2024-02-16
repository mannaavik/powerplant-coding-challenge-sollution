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
			IPowerPlant pp = new GasPowerplant();
			MeritOrder mo = new MeritOrder(pp);

			//Act
			var meritOrderResult = mo.DecideMeritOrder(fuel, powerplants);

			//Assert
			Assert.NotNull(meritOrderResult);
			Assert.Equal(6, meritOrderResult.Count);
		}
    }

	
}

public class MeritOrderTestData : TheoryData<Fuel, List<PowerPlant>>
{
	public MeritOrderTestData()
	{
		PowerPlant p1 = new PowerPlant { Name = "gasfiredbig1", Type = "gasfired", Efficiency = 0.53, Pmin = 100, Pmax = 460 };
        PowerPlant p2 = new PowerPlant { Name = "gasfiredbig2", Type = "gasfired", Efficiency = 0.53, Pmin = 100, Pmax = 460 };
        PowerPlant p3 = new PowerPlant { Name = "gasfiredsomewhatsmaller", Type = "gasfired", Efficiency = 0.3, Pmin = 0, Pmax = 16 };
        PowerPlant p4 = new PowerPlant { Name = "tj1", Type = "turbojet", Efficiency = 1, Pmin = 0, Pmax = 150 };
        PowerPlant p5 = new PowerPlant { Name = "windpark1", Type = "windturbine", Efficiency = 0.53, Pmin = 100, Pmax = 460 };
        PowerPlant p6 = new PowerPlant { Name = "windpark2", Type = "windturbine", Efficiency = 1, Pmin = 0, Pmax = 36 };
        List<PowerPlant> ps = new List<PowerPlant>();

		ps.Add(p1);
        ps.Add(p2);
        ps.Add(p3);
        ps.Add(p4);
        ps.Add(p5);
        ps.Add(p6);

        Add(new Fuel { GasCost = 13.4, KerosineCost = 50.8, Co2Cost = 20, Wind = 60 } , ps);
	}
}

