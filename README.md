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

Visual Studio launches the Kestrel web server.

The Swagger page /swagger/index.html is displayed.
