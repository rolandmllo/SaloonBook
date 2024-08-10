FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG TARGETARCH
WORKDIR /source

# Copy necessary files
COPY *.props ./
COPY *.sln ./

# Copy project files
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
RUN dotnet restore -a $TARGETARCH

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
RUN dotnet publish -a $TARGETARCH --no-restore -o /app

# Final stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /app .
USER $APP_UID
ENTRYPOINT ["dotnet", "WebApp.dll"]