# contacts-app

## Run The Project
You will need the following tools:

* [Visual Studio 2022]
* [.Net Core 6]
* [Docker Desktop]

Follow these steps to get your development environment set up: (Before Run Start the Docker Desktop)
1. Clone the repository
2. Open project in Visual Studio
3. Open terminal from root of the project then type:    docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
4. You can launch microservices as below urls:
* Report API : http://localhost:8001/swagger/index.html
* Contactbook API :  http://localhost:8000/swagger/index.html
* Rabbit Management Dashboard : http://localhost:15672/#/
* Username : guest Password: guest

Google SpreadSheet for Reports: https://docs.google.com/spreadsheets/d/11qqVJ0rZXONJP-QCBxs5S_u5DuxIG8dctRCAPDPsJJE/edit#gid=1009378663

To create report with queue use "CreateReportRequest" in Report API.
