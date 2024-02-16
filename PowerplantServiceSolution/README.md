Please change the input as mentioned below due to the presence of special characters

{
  "load": 910,
  "fuels":
  {
    "gasCost": 13.4,
    "kerosineCost": 50.8,
    "co2Cost": 20,
    "wind": 60
  },
  "powerplants": [
    {
      "name": "gasfiredbig1",
      "type": "gasfired",
      "efficiency": 0.53,
      "pmin": 100,
      "pmax": 460
    },
    {
      "name": "gasfiredbig2",
      "type": "gasfired",
      "efficiency": 0.53,
      "pmin": 100,
      "pmax": 460
    },
    {
      "name": "gasfiredsomewhatsmaller",
      "type": "gasfired",
      "efficiency": 0.37,
      "pmin": 40,
      "pmax": 210
    },
    {
      "name": "tj1",
      "type": "turbojet",
      "efficiency": 0.3,
      "pmin": 0,
      "pmax": 16
    },
    {
      "name": "windpark1",
      "type": "windturbine",
      "efficiency": 1,
      "pmin": 0,
      "pmax": 150
    },
    {
      "name": "windpark2",
      "type": "windturbine",
      "efficiency": 1,
      "pmin": 0,
      "pmax": 36
    }
  ]
}

----Option 1: Using Visual Studio
1.	Please download and install Dotnet 2022 and make sure you have Dotnet 7.0 runtime in your system.
2.	Download the Project folder and open the solution file in Visual Studio.
3.	Right click on solution and click on build PowerplantService
4.	Select PowerplantService – https as default lauched and running project.
5.	Click the run button.
6.	The browser will run the API on url https://localhost:8888/swagger


----Option 2: Using Dotnet CLI
1.	Go to link https://dotnet.microsoft.com/en-us/download/dotnet/7.0 to download and install Dotnet SDK based on your operating system and Binaries. This will basically bypass the need of Visual Studio developer tool. 
2.	Run command “Dotnet build”
3.	Run command “Dotnet run –project powerplantservice/powerplantservice.csproj”
4.	Open the browser and browse url https://localhost:8888/swagger or http://localhost:8888/swagger 

----The docker file is also available by which anyone can containerize the application in Docker hub.
