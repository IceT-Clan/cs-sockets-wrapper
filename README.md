# cs-sockets-wrapper
A C# System.Net.Sockets Wrapper for possible easier use

# Usage
Via any git capable shell
```
cd YOURPROJECTFOLDER
git clone https://github.com/IceT-Clan/cs-sockets-wrapper
```
In Visual Studio:

1. Right-Click on the Solution of your Project in the Solution Explorer
2. Choose `Add` -> `Add existing Project...`
3. Open `cs-sockets-wrapper\Sockets.shproj`

![Add existing Project](doc/add-to-sln.png)

4. Right-Click on the Project wich needs to access the Sockets
5. Choose `Add` -> `Reference...`

![Add Reference via Project](doc/add-reference-via-project.png)

or

4. Select the Project wich needs to access the Sockets
5. Right-Click on References
6. Choose `Add Reference...`

![Add Refrence via directly](doc/add-reference-directly.png)

7. On the left panel choose `Shared projects` -> `Solution`
8. Tick `Sockets`
9. Press `OK`

![Add shared project](doc/add-shared-project.png)
