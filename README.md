<img src="https://img.shields.io/badge/LiFx%20Server%20Framework%20version-%3E3.0.0-green" />
# Loot
[Download here](https://github.com/LiF-x/Loot/releases/latest)

### Installation instructions

1. Download the latest package from the above link.
2. Stop your server
3. Remove older versions of the mod
4. Upload the zip file you downloaded in step 1. to the "mods" folder in your server via file manager or ftp.
5. Extract the zip file inside the mods folder.
6. Delete the mod zip file you uploaded (important!)
7. Start the server

### Configuration

1. Edit the lootTable.cs file
2. Add one line per drop item following this template *dbi.Update("INSERT IGNORE `" @ LiFxLoot::loottable() @ "` VALUES (ContainerID, ItemDropID, Min Quality, Max Quality, Min Quantity, Max Quantity, Chance)");* Where you replace the values according to your drop wishes.