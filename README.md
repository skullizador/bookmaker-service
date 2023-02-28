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
* [x] Create new bookmaker;
* [x] Delete bookmaker;
* [x] Get bookmaker information;
* [x] Update bookmaker;
* [x] Get all bookmakers;

Available features for teams:
* [x] Create new team;
* [x] Delete team;
* [x] Update team;
* [x] Get team information;
* [x] Get all teams;
* [x] Add new acronym to team;
* [x] Delete team's acronym;
* [x] Get team's acronyms;

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