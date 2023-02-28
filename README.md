<h1 align="center"> Bookmaker Integration </h1> <br>

<p align="center">
  This microservice is responsible for storing all the information about the bookmakers available in our platform. Along with that, it also stores information about teams and players that are known in our platform.
</p>

## Table of Contents

- [Domain](#introduction)
- [Features](#features)
- [Requirements](#requirements)
- [Quick Start](#quick-start)

## Domain

![Domain](https://github.com/skullizador/bookmaker-service/blob/main/resources/domain.png)

## Features

Available features for bookmakers:
* Create new bookmaker :heavy_check_mark:
* Delete bookmaker :heavy_check_mark:
* Get bookmaker information :heavy_check_mark:
* Update bookmaker :heavy_check_mark:
* Get all bookmakers :heavy_check_mark:

Available features for teams:
* Create new team :heavy_check_mark:
* Delete team :heavy_check_mark:
* Update team :heavy_check_mark:
* Get team information :heavy_check_mark:
* Get all teams :heavy_check_mark:
* Add new acronym to team :heavy_check_mark:
* Delete team's acronym :heavy_check_mark:
* Get team's acronyms :heavy_check_mark:

## Requirements
The application can be run locally or in a docker container, the requirements for each setup are listed below.

### Docker
* [Docker](https://www.docker.com/get-docker)

## Quick Start 
### Run Docker
TODO: Implement dockerfiles to run the application in a docker container.

First build the image:
```bash
$ docker-compose build
```

When ready, run it:
```bash
$ docker-compose up
```

Application will run by default on port `1234`