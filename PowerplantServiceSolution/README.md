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
