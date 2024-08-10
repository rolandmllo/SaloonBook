# SaloonBook

SaloonBook is a full-stack web application designed for booking time slots at a salon. The project includes a backend API service (`SaloonBook-WS`), a frontend user interface (`SaloonBook-UI`), and a PostgreSQL database, all of which are containerized and orchestrated using Docker Compose.

🚧 **This project is a Work in Progress (WIP).** While the core functionalities are in place, some features are still under development.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Prerequisites](#prerequisites)
- [Setup and Installation](#setup-and-installation)
- [Running the Project](#running-the-project)
- [API Documentation](#api-documentation)
- [Project Structure](#project-structure)

## Features

- User authentication using JWT.
- Book time slots for salon services.
- Responsive UI built with React, TypeScript, and Next.js.
- API endpoints for managing bookings, users, and services.
- Swagger documentation for easy API exploration.

## Technologies Used

- **Backend**: C# .NET Core
- **Frontend**: React, TypeScript, Next.js
- **Database**: PostgreSQL
- **Authentication**: JSON Web Tokens (JWT)
- **Containerization**: Docker, Docker Compose

## Prerequisites

Ensure you have the following installed on your local development environment:

- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/install/)

## Setup and Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/rolandmllo/SaloonBook.git
   cd SaloonBook
   ```
2. Build and start the Docker containers:
   ```bash
   docker compose up --build
      ```

   This command will:

Build the SaloonBook-WS .NET Core API and expose it on `http://localhost:8001`.
Build the SaloonBook-UI React frontend and expose it on `http://localhost:8000`.
Start a PostgreSQL database on `http://localhost:5445`.
Access the application:
Frontend: `http://localhost:8000`
API: `http://localhost:8001/api/`
Swagger API Documentation: `http://localhost:8001/swagger`

## Running the Project

After setting up the project using Docker Compose, you can interact with the application as follows:

- Frontend: Visit `http://localhost:8000` to access the React application.
- API: The backend API is available at `http://localhost:8001`.
- Swagger Documentation: The API documentation is accessible at `http://localhost:8001/swagger`.

## API Documentation

The backend API (SaloonBook-WS) includes Swagger documentation to help you explore available endpoints. After starting the application, you can visit http://localhost:8001/swagger to view and test the API.

## Project Structure

The project is organized into the following directories:

- `SaloonBook-WS/`: Backend API built with C# .NET Core.
- `SaloonBook-UI/`: Frontend application built with React, TypeScript, and Next.js.
- `docker-compose.yml`: Docker Compose file for orchestrating the containers.
