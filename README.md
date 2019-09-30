# SDCSpaceXChallenge
SmileDirectClub coding challenge - create a basic RESTFul service which exposes the SpaceX launch pad information. Design the service keeping in mind that the call to the SpaceX Launchpad API will be replaced by a DB containing the data in the future. Strive to keep changes minimal when this change occurs. 

## Getting Started
You can clone this project to either a Windows or Linux machine to build/run using .NET Core 2.1

## Prerequisites
You will need to ensure the following are installed to build this project:
* [.NET Core](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.1.505-windows-x64-installer) - Windows (64-bit) **or**
* [.NET Core](https://dotnet.microsoft.com/download/linux-package-manager/ubuntu14-04/sdk-2.1.505) - Linux
* [Node.js](https://nodejs.org/en/download/)
* [Angular CLI](https://cli.angular.io/) - Angular CLI needed for running Angular unit tests


## Run Project
After the prerequisites listed above are installed, build and run using the following steps:
* Move to SpaceXSolution/ClientApp directory and run

      npm install
      
* Install Angular CLI globally to run Angular unit tests

      npm install -g @angular/cli

* Move to SpaceXSolution directory and run

      dotnet run --environment "Development"

* Open browser window and navigate to the appropriate URL

      http://localhost:5000 for example

   This will start an Angular front end to illustrate the API implementation
   
## Testing - Unit Tests
* Using **xUnit.net** for .NET Core. Simple unit test created for the API developed. Run via command line by going to XSpaceXSolution.Tests directory and run

      dotnet test

* Using **Jasmine** and **Karma** for Angular unit testing. Both come with the Angular CLI. Simple tests created to verify table is being rendered and that the angular service calling the API is properly working. Run via command by going to SpaceXSolution/ClientApp and run

      ng test


## Relevant files

* SpaceXSolution\Controllers\SpaceXLaunchPadController.cs
* SpaceXSolution\Infrastructure\ISpaceXLaunchPadData.cs
* SpaceXSolution\Infrastructure\SpaceXLaunchPadData.cs
* SpaceXSolution\Models\SDCLaunchPadInfo.cs
* SpaceXSolution\Models\SpaceXLaunchPad.cs
* SpaceXSolution\Models\SpaceXLaunchPadFilter.cs
* SpaceXSolution\Startup.cs
* XSpaceXSolution.Tests\TestSpaceXLaunchPadController.cs
