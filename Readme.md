**Back end setup
prerequisite:
-VS 22
-dotnet Net 6.0
-SQLServer
1. After cloning the project navigate to BCityProject/BCity thus where you will get the sln (solution for the project).
2. click sln making sure that you have Visual Studio 22 preferably and it will open 3 projects.
3. right click on the sln to restore nuget packages for it to load all the packages required for it to run
4. run the migrations for the SQLServer database setup eg (add-migrations Init)
5. run update-database to apply the migrations made
6. start the project   
