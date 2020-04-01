## TimeTrackingBackend Instructions to run the database code first, using postman, and unit test.

1. Open TimeTrackingBackEnd -> open Package Manager Console
1. Type ``add-migration migration_name``
1.  Type ``update-database``. The database will be created in your local. Note(Database used is MS Sql).
1.  Check database in you local.

## Prereq

1. Install Visual Studio (.net core 2.1)
1. Install Sql Server

## How to run the application
1. Open both solutions TimeTrackingBackEnd and TimeTrackingFrontEnd
1. Double click .sln project inside the both folders.
1. Wait to load the the solutions.
1. Run first the TimeTrackingBackEnd by clicking the green play button and,
1. Next is the TimeTrackingFrontEnd click the green run button as well.

## Unit Testing:
I used Xunit unit test. All test have passed based  on the actual data that is inputed in the database.
Please refer below data for unit test purposes. You can execute this for unit test purposes.

``INSERT INTO [dbo].[Employees] VALUES('Ariann28', '2020-03-30 09:00:00.0000000', '2020-03-30 06:00:00.0000000', 1)``
``INSERT INTO [dbo].[Employees] VALUES('AriannJr', '2020-03-30 09:00:00.0000000', '2020-03-30 06:00:00.0000000', 1)``

Note: You can also try testing it in postman, just be sure to retrieve first the JWT token and copy it to the Authorization type: “Bearer Token” to access the endpoints.

Note: Please run both solution (backend and front end solutions)



## LogIn Instructions
1. Whenever you run the application you can login using the “hardcoded” credential below.
Username: test
Password: test
