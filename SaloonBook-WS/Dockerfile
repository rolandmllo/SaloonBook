# Use the default .NET SDK base image which will automatically match your platform
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy all necessary files for restore as distinct layers
COPY *.props ./
COPY *.sln ./

# Copy all project files
COPY BLL.Base/*.csproj ./BLL.Base/
COPY DAL.Base/*.csproj ./DAL.Base/
COPY DAL.EF.Base/*.csproj ./DAL.EF.Base/
COPY Domain.Base/*.csproj ./Domain.Base/
COPY Helpers.Base/*.csproj ./Helpers.Base/
COPY BLL.Contracts.Base/*.csproj ./BLL.Contracts.Base/
COPY Contracts.Base/*.csproj ./Contracts.Base/
COPY DAL.Contracts.Base/*.csproj ./DAL.Contracts.Base/
COPY Domain.Contracts.Base/*.csproj ./Domain.Contracts.Base/
COPY DAL.App.Contracts/*.csproj ./DAL.App.Contracts/
COPY BLL.App.Contracts/*.csproj ./BLL.App.Contracts/
COPY App.BLL/*.csproj ./App.BLL/
COPY App.Domain/*.csproj ./App.Domain/
COPY BLL.DTO/*.csproj ./BLL.DTO/
COPY DAL.App.EF/*.csproj ./DAL.App.EF/
COPY Public.DTO/*.csproj ./Public.DTO/
COPY Tests/*.csproj ./Tests/
COPY WebApp/*.csproj ./WebApp/

# Restore dependencies
RUN dotnet restore

# Copy the rest of the source files
COPY BLL.Base/. ./BLL.Base/
COPY DAL.Base/. ./DAL.Base/
COPY DAL.EF.Base/. ./DAL.EF.Base/
COPY Domain.Base/. ./Domain.Base/
COPY Helpers.Base/. ./Helpers.Base/
COPY BLL.Contracts.Base/. ./BLL.Contracts.Base/
COPY Contracts.Base/. ./Contracts.Base/
COPY DAL.Contracts.Base/. ./DAL.Contracts.Base/
COPY Domain.Contracts.Base/. ./Domain.Contracts.Base/
COPY DAL.App.Contracts/. ./DAL.App.Contracts/
COPY BLL.App.Contracts/. ./BLL.App.Contracts/
COPY App.BLL/. ./App.BLL/
COPY App.Domain/. ./App.Domain/
COPY BLL.DTO/. ./BLL.DTO/
COPY DAL.App.EF/. ./DAL.App.EF/
COPY Public.DTO/. ./Public.DTO/
COPY Tests/. ./Tests/
COPY WebApp/. ./WebApp/

# Build and publish the app
RUN dotnet publish -c Release -o /app/publish

# Final stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "WebApp.dll"]
