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

!(doc/add-to-sln.png)[Add existing Project]

4. Right-Click on the Project wich needs to access the Sockets
5. Choose `Add` -> `Reference...`

!(doc/add-reference-via-project.png)[Add Reference via Project]

or

4. Select the Project wich needs to access the Sockets
5. Right-Click on References
6. Choose `Add Reference...`

!(doc/add-reference-directly.png)[Add Refrence via directly]

7. On the left panel choose `Shared projects` -> `Solution`
8. Tick `Sockets`
9. Press `OK`

!(doc/add-shared-project.png)[Add shared project]
