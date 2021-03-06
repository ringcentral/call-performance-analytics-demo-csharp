# Call Performance Demo Application (C# using RestSharp)

This is a simple C# application that uses RestSharp library to demonstrate how to call RingCentral Call Performance API. The resulting JSON is rendered on the standard console. You would need to implement Authentication with RingCentral to run this demo application. 

More information about that can be found in the [developer guide.](https://developers.ringcentral.com/guide/analytics)

## PreRequisite:

1. .Net SDK (.Net or .Net Core)
2. RestSharp Library
3. Have a RingCentral Application with 'Analytics Permission'
4. Get the RingCentral Application ID & Secret Key from Developer Dashboard - Production Credentials as that will be used for authentication purpose

## Steps to run the program

1. Clone/Download this GitHub Repository
2. Navigate to the WebAPIClient folder
2. Edit the "[Program.cs](WebAPIClient/Program.cs)" file by adding authentication support. For more information regarding the same refer to this [guide](https://developers.ringcentral.com/guide/authentication).
3. Compile and Run the program by executing the following commands
```
dotnet add package RestSharp
dotnet run                  
```
4. Open Console to see the JSON Response of the Call Performance API Execution

