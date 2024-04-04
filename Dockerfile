FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080


FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /src
COPY ["PassIn.Api/PassIn.Api.csproj" , "PassIn.Api/"]
COPY ["PassIn.Infra/PassIn.Infra.csproj" , "PassIn.Infra/"]
COPY ["PassIn.Application/PassIn.Application.csproj" , "PassIn.Application/"]
COPY ["PassIn.Communication/PassIn.Communication.csproj" , "PassIn.Communication/"]
COPY ["PassIn.Domain/PassIn.Domain.csproj" , "PassIn.Domain/"]
COPY ["PassIn.Exceptions/PassIn.Exceptions.csproj" , "PassIn.Exceptions/"]

RUN dotnet restore "PassIn.Api/PassIn.Api.csproj"
COPY . .
WORKDIR "/src/PassIn.Api"

RUN dotnet build "PassIn.Api.csproj" -c Release -o /app/build

FROM build as publish
RUN dotnet publish "PassIn.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet","PassIn.Api.dll"]




