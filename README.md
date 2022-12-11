<img src="https://img.shields.io/badge/LiFx%20Server%20-%3Ev3.0.0-green" />

# Loot

[Download here](https://github.com/LiF-x/Loot/releases/latest)

## Pre requisite

- This mod requires the LiFx Server Framework version 3.0.0 or newer

### Installation instructions

1. Download the latest package from the above link.
2. Stop your server
3. Remove older versions of the mod. To remove the mod delete the folder Loot from inside the Mods folder of your server.
4. Upload the zip file you downloaded in step 1. to the "mods" folder in your server via file manager or ftp.
5. Extract the zip file inside the mods folder.
6. Delete the mod zip file you uploaded (important!)
7. Start the server

### Configuration

1. Edit the lootTable.cs file
2. Add one line per drop item following this template *dbi.Update("INSERT IGNORE \`" @ LiFxLoot::loottable() @ "\` VALUES (ContainerID, ItemDropID, Min Quality, Max Quality, Min Quantity, Max Quantity, Chance)");* Where you replace the values according to your drop wishes.

#### Column explanation:
| Column | Description |
|-|-|
| ContainerID | The ID of the container of which you want the loot to drigger on, when it is added to the world. |
| ItemDropID | The ID of the loot you wish to put into the container |
| Min Quality | The minimum quality of the object you want to spawn in to the container |
| Max Quality | The maximum quality of the object you want to spawn in to the container |
| Min Quantity | The minimum quantity of objects of the object type you want to spawn in to the container |
| Max Quantity | The maxiumum quantity of objects of the object type you want to spawn in to the container |
| Chance | The relative probability in comparison to other items for the same container ID (if you have five items towards the same containerId where object A, B, C,D has chance of 1 and object E has a chance of 2 then object E has twice the chance to be dropped in the loot compared to any of the one A, B, C and D objects) |
