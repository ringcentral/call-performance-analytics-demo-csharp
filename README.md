# Call Performance Demo Application (C# using RestSharp)

This is a simple C# application that uses RestSharp library to demonstrate how to call RingCentral Call Performance API. The resulting JSON is rendered on the standard console.

## PreRequisite:

1. .Net SDK (.Net or .Net Core)
2. RestSharp Library

## Steps to run the program

1. Clone this GitHub Repository
2. Navigate to the WebAPIClient folder
2. Edit the "Program.cs" file by adding your O-Auth 2.0 Token. For more information regarding the same refer to this [guide](https://developers.ringcentral.com/guide/authentication).
3. Compile and Run the program
```
dotnet add package RestSharp
dotnet run                  
```
4. Open Console to see the JSON Response of the Call Performance API Execution
