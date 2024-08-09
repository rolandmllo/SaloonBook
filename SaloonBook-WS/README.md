# SaloonBook

## Saloon Booking System

~~~bash
# install or update
dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef

dotnet tool install --global dotnet-aspnet-codegenerator
dotnet tool update --global dotnet-aspnet-codegenerator

# Create db Migration
dotnet ef migrations add InitialCreate --project DAL.App.EF --startup-project WebApp --context ApplicationDbContext

# Apply Migration
dotnet ef database update --project DAL.App.EF --startup-project WebApp --context ApplicationDbContext
~~~



# Create MVC
~~~bash

cd WebApp


dotnet aspnet-codegenerator controller -m App.Domain.Appointment   -name AppointmentController     -outDir Controllers -dc ApplicationDbContext -udl --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -m App.Domain.Category      -name CategoryController        -outDir Controllers -dc ApplicationDbContext -udl --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -m App.Domain.Salon         -name SalonController           -outDir Controllers -dc ApplicationDbContext -udl --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -m App.Domain.Schedule      -name ScheduleController        -outDir Controllers -dc ApplicationDbContext -udl --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -m App.Domain.Service       -name ServiceController         -outDir Controllers -dc ApplicationDbContext -udl --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -m App.Domain.AppointmentServices -name AppointmentServicesController   -outDir Controllers -dc ApplicationDbContext -udl --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -m App.Domain.City          -name CityController         -outDir Controllers -dc ApplicationDbContext -udl --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -m App.Domain.EmployeeServices -name EmployeeServicesController -outDir Controllers -dc ApplicationDbContext -udl --referenceScriptLibraries -f

# Rest api

dotnet aspnet-codegenerator controller -m App.Domain.Appointment   -name AppointmentController     -outDir ApiControllers -api -dc ApplicationDbContext -udl --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -m App.Domain.Category      -name CategoryController        -outDir ApiControllers -api -dc ApplicationDbContext -udl --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -m App.Domain.Salon         -name SalonController           -outDir ApiControllers -api -dc ApplicationDbContext -udl --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -m App.Domain.Schedule      -name ScheduleController        -outDir ApiControllers -api -dc ApplicationDbContext -udl --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -m App.Domain.Service       -name ServiceController         -outDir ApiControllers -api -dc ApplicationDbContext -udl --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -m App.Domain.AppointmentServices -name AppointmentsController         -outDir ApiControllers -api -dc ApplicationDbContext -udl --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -m App.Domain.City           -name CituController         -outDir ApiControllers -api -dc ApplicationDbContext -udl --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -m App.Domain.EmployeeServices -name EmployeeServicesController         -outDir ApiControllers -api -dc ApplicationDbContext -udl --referenceScriptLibraries -f
~~~

Generate Identity UI

~~~bash
cd WebApp
dotnet aspnet-codegenerator identity -dc DAL.App.EF.ApplicationDbContext -f
dotnet aspnet-codegenerator identity -dc ApplicationDbContext -f
#dotnet aspnet-codegenerator identity -dc DAL.App.EF.ApplicationDbContext --userClass AppUser -f 
~~~

# Deployment
rolandmallo/icd0021-22-23-s-dist-22-23s-app:amd64


