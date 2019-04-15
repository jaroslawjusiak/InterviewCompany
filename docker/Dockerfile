FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /app

# copy all files
COPY . .
# restore packages
WORKDIR /app/InterviewCompany.API
RUN pwd
RUN ls -al
# Restores the dependencies
RUN dotnet restore InterviewCompany.API.sln

#test - if test will fail, pp wil not start
RUN dotnet test

# build
WORKDIR /app/InterviewCompany.API/InterviewCompany.API
# Packs the application and its dependencies into a folder - it will be ready to start
RUN dotnet publish -c Release -o out


FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/InterviewCompany.API/InterviewCompany.API/out ./

# Command and parameter to be executed as soon as container is running
ENTRYPOINT ["dotnet", "InterviewCompany.API.dll"]
