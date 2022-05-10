# TinyWeather: An Extremely Small Weather Client

## Prerequisites

Dotnet Core 6.X

## Setup

1. At the root of the project, open a command line terminal and enter `dotnet restore`. This should load all dependencies for all projects.
2. ApiKey as Secret: I kind of did this weird and fixing it is low on my priority list.
   A. Change directories to `src/app/Weather.Console` and enter `dotnet user-secrets init` followed by `dotnet user-secrets apiKey=<your value here>`
   B. Change directories to `tests/Weather.Test` and enter the same two things.
3. To run tests, go to the project root and enter `dotnet test`.
4. To run the console, change directories to src/app/Weather.Console and enter `dotnet run`

## Todo List

- [x]Make geolocation API call
- [x]Make make weather API call
- [x]Search by coordinates
- [x]Search by zip
- [x]Search by city, state
- [x]Create Weather Object
- [x]Turn JSON into object: AutoMapper?
- [x]Object for parsing search terms
- [x]Build Weather Call
- [x]Build Geolocation Call
- [x]Make async work properly
- [x]Wind direction in words, not degrees, e.g. "Southwest"
- [ ]The secrets should really be in Weather.Lib. Also, move to secrets.json
- [ ]Switch units
