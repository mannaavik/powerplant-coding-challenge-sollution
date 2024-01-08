using System;
namespace PowerplantService.DataModel
{
    /// <summary>
    /// Resource infos
    /// </summary>
	public class Resources
	{
		public double Load { get; set; }
        public required Fuel Fuels { get; set; }
        public required List<Powerplant> Powerplants { get; set; }
	}

    /// <summary>
    /// Fuel infos
    /// </summary>
	public class Fuel
	{
        public double GasCost { get; set; }
        public double KerosineCost { get; set; }
        public double Co2Cost { get; set; }
        public double Wind { get; set; }
    }

    /// <summary>
    /// Powerplant infos
    /// </summary>
	public class Powerplant
	{
        public required string Name { get; set; }
        public required string Type { get; set; }
        public double Efficiency { get; set; }
        public double Pmin { get; set; }
        public double Pmax { get; set; }
    }

    /// <summary>
    /// Powerplant types
    /// </summary>
    public enum PowerplantType
    {
        gasfired,
        turbojet,
        windturbine
    }

}

