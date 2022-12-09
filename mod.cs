/**
* <author>Christophe Roblin</author>
* <email>lifxmod@gmail.com</email>
* <url>lifxmod.com</url>
* <credits>Christophe Roblin <christophe@roblin.no></credits>
* <description>Loot functionality for Life is Feudal: Your Own, works on new containers</description>
* <license>GNU GENERAL PUBLIC LICENSE Version 3, 29 June 2007</license>
*/

if (!isObject(LiFxLoot))
{
    new ScriptObject(LiFxLoot)
    {
    };
}
if(!isDefined("$LiFx::loot::numDrops"))
{
  echo("$LiFx::loot::numDrops was not configured, setting default 4 drops");
  $LiFx::loot::numDrops = 4;
}
package LiFxLoot

{
    function LiFxLoot::setup() {
      LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, dbInit, LiFxLoot);
      LiFx::registerCallback($LiFx::hooks::onServerCreatedCallbacks, Dbchanges, LiFxLoot);
    }
    function LiFxLoot::loottable() {
      return "lifx_loot";
    }
    function LiFxLoot::dbInit() {
      dbi.Update("DROP TABLE IF EXISTS `" @ LiFxLoot::loottable @ "`");
      %sqlTrigger = "CREATE TRIGGER `" @ LiFxLoot::loottable @ "` BEFORE INSERT ON `movable_objects` FOR EACH ROW BEGIN INSERT INTO items SELECT NULL, new.RootContainerID, ItemObjectTypeID, @Quality :=FLOOR(RAND()*(MaxQuality-MinQuality+1)+MinQuality) AS Quality, FLOOR(RAND()*(MaxQuantity-MinQuantity+1)+MinQuantity) AS Quantity, @Durability := (SELECT FLOOR(50 + (1.5 * @Quality) * 100)) AS Durability, (@Durability) AS CreatedDurability, NULL FROM lifx_loot WHERE ContainerObjectTypeID = new.ObjectTypeID and Chance > 0 ORDER BY -LOG(1.0 - RAND()) / Chance LIMIT " @ $LiFx::loot::numDrops @"; END;\n";
      
      %sqlTable = "CREATE TABLE IF NOT EXISTS `" @ LiFxLoot::loottable @ "` (\n";
      %sqlTable = %sqlTable @ "`ContainerObjectTypeID` INT(11) NOT NULL,\n";
      %sqlTable = %sqlTable @ "`ItemObjectTypeID` INT(11) NOT NULL,\n";
      %sqlTable = %sqlTable @ "`MinQuality` INT(11) NOT NULL,\n";
      %sqlTable = %sqlTable @ "`MaxQuality` INT(11) NOT NULL,\n";
      %sqlTable = %sqlTable @ "`MinQuantity` INT(11) NOT NULL,\n";
      %sqlTable = %sqlTable @ "`MaxQuantity` INT(11) NOT NULL,\n";
      %sqlTable = %sqlTable @ "`Chance` INT(11) NOT NULL\n";
      %sqlTable = %sqlTable @ ")\n";
      %sqlTable = %sqlTable @ "COLLATE='utf8mb3_unicode_ci'\n";
      %sqlTable = %sqlTable @ "ENGINE=InnoDB;\n";
      
      dbi.Update("DROP TRIGGER lifx_loot"); // Drop trigger to ensure we have the updated ones at  all times
      dbi.Update(%sqlTrigger); // Insert trigger
      dbi.Update(%sqlTable); // Create the table if it does not exist
    }
    function LiFxLoot::dbChanges() {
      dbi.Update("TRUNCATE TABLE `" @ LiFxLoot::loottable @ "`");
      exec("./lootTable.cs");
    }
    function LiFxLoot::version() {
        return "1.0.0";
    }
};
activatePackage(LiFxLoot);