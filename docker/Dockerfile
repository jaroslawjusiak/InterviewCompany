FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /app

# copy all files
COPY . .
# restore packages
WORKDIR /app/InterviewCompany.API
RUN pwd
RUN ls -al
RUN dotnet restore InterviewCompany.API.sln

#test
RUN dotnet test

# build
WORKDIR /app/InterviewCompany.API/InterviewCompany.API
RUN dotnet publish -c Release -o out


FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/InterviewCompany.API/InterviewCompany.API/out ./

ENTRYPOINT ["dotnet", "InterviewCompany.API.dll"]
