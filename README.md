# BuyService
The goal of thie project is to demonstrate docker containers using the micro services pattern.

### Prerequisites
* [Docker Desktop for Windows](https://hub.docker.com/editions/community/docker-ce-desktop-windows)

Use your prefered Code Editor.
* [Visual Studio 2022](https://visualstudio.microsoft.com/vs/#download) with the ASP.NET and web development workload.  

  
    
    
* [Visual Studio Code](https://code.visualstudio.com/download)
  * [C# for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
  * [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)

### Building the app

#### 1. Clone repository

```
git clone https://github.com/AshleyDhevalall/BuyService.git
```

* Navigate to cloned repository folder

#### 2. Building the docker image
* Run the command below in the cloned repository folder to build the docker image
```
docker build --network=host --no-cache .
```

Open the web browser and navigate to http://localhost:5000/WeatherForecast. You should see weather data in JSON format, similar to following:

[
    {"date":"2019-11-07T23:31:57.0527092+00:00","temperatureC":4,"temperatureF":39,"summary":"Bracing"},
    {"date":"2019-11-08T23:31:57.0539243+00:00","temperatureC":-19,"temperatureF":-2,"summary":"Freezing"},
    {"date":"2019-11-09T23:31:57.0539269+00:00","temperatureC":2,"temperatureF":35,"summary":"Freezing"},
    {"date":"2019-11-10T23:31:57.0539275+00:00","temperatureC":-4,"temperatureF":25,"summary":"Freezing"},
    {"date":"2019-11-11T23:31:57.053928+00:00","temperatureC":9,"temperatureF":48,"summary":"Bracing"}
 ]
By default Docker will assign a randomly chosen host port to a port exposed by a container (the container port). In our application the exposed (container) port is 5000. When you issue Run command for an image, VS Code will try to use the same port number for the host port and container port. This makes it easy to remember which port to use to communicate with the container, but it won't work if the host port is already in use.

If you cannot see the data from the container in your browser, make sure there are no errors reported by the docker run command (look at the command output in the terminal window). You can also verify which host port is using by the container by right-clicking the container in the Docker Explorer and choosing Inspect. This will open a JSON document that describes the container in detail. Search for PortBindings element, for example:

Visual Studio launches the Kestrel web server.

The Swagger page /swagger/index.html is displayed.
