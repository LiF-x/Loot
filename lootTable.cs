
///////////////////////////////////////Loot Table /////////////////////////////////////////////
// Add dbi Update commands to populate the loot table for the mod as shown in the below example
//
//  Chance is relative to each other, 0 means it is not lootable (disabled)
// 
//  Example:
//  Drop 1 has Chance 1
//  Drop 2 has Chance 2
//
//  Drop 2 is then twice more likely to be dropped than Drop 1 (2/1)
// 
// dbi.Update("INSERT IGNORE `" @ LiFxLoot::loottable() @ "` VALUES (ContainerID, ItemDropID, Min Quality, Max Quality, Min Quantity, Max Quantity, Chance)");
//