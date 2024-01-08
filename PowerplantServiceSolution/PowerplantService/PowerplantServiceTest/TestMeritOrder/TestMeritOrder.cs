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
		public void TestDecideMeritOrder(Fuel fuel, List<Powerplant> powerplants)
		{
			//Arrange
			IPowerplant pp = new GasPowerplant();
			MeritOrder mo = new MeritOrder(pp);

			//Act
			var meritOrderResult = mo.DecideMeritOrder(fuel, powerplants);

			//Assert
			Assert.NotNull(meritOrderResult);
			Assert.Equal(6, meritOrderResult.Count);
		}
    }

	
}

public class MeritOrderTestData : TheoryData<Fuel, List<Powerplant>>
{
	public MeritOrderTestData()
	{
		Powerplant p1 = new Powerplant { Name = "gasfiredbig1", Type = "gasfired", Efficiency = 0.53, Pmin = 100, Pmax = 460 };
        Powerplant p2 = new Powerplant { Name = "gasfiredbig2", Type = "gasfired", Efficiency = 0.53, Pmin = 100, Pmax = 460 };
        Powerplant p3 = new Powerplant { Name = "gasfiredsomewhatsmaller", Type = "gasfired", Efficiency = 0.3, Pmin = 0, Pmax = 16 };
        Powerplant p4 = new Powerplant { Name = "tj1", Type = "turbojet", Efficiency = 1, Pmin = 0, Pmax = 150 };
        Powerplant p5 = new Powerplant { Name = "windpark1", Type = "windturbine", Efficiency = 0.53, Pmin = 100, Pmax = 460 };
        Powerplant p6 = new Powerplant { Name = "windpark2", Type = "windturbine", Efficiency = 1, Pmin = 0, Pmax = 36 };
        List<Powerplant> ps = new List<Powerplant>();

		ps.Add(p1);
        ps.Add(p2);
        ps.Add(p3);
        ps.Add(p4);
        ps.Add(p5);
        ps.Add(p6);

        Add(new Fuel { GasCost = 13.4, KerosineCost = 50.8, Co2Cost = 20, Wind = 60 } , ps);
	}
}

