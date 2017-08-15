BEGIN TRANSACTION;
CREATE TABLE "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);
INSERT INTO `__EFMigrationsHistory` VALUES ('20170815111219_“InitialMigration”','1.1.2');
CREATE TABLE "Products" (
    "ID" INTEGER NOT NULL CONSTRAINT "PK_Products" PRIMARY KEY AUTOINCREMENT,
    "CategoryID" INTEGER NOT NULL,
    "Description" TEXT,
    "Name" TEXT,
    "Price" INTEGER NOT NULL,
    "Url" TEXT,
    CONSTRAINT "ForeignKey_Product_Category" FOREIGN KEY ("CategoryID") REFERENCES "Categories" ("ID") ON DELETE CASCADE
);
INSERT INTO `Products` VALUES (1,1,'Shprot in oil','Shprots',850,'http://cat-and-labrador.weebly.com/uploads/3/1/9/7/31979707/7669800_orig.jpg');
INSERT INTO `Products` VALUES (2,3,'Frozen chicken legs','Chicken',1300,'http://www.pjmartinelli.co.uk/WebRoot/BT/Shops/BT3174/4A24/DEF2/79E9/4424/2697/0A0A/33E7/DBA0/shutterstock_11340031.jpg');
INSERT INTO `Products` VALUES (3,1,'Tuna fish, kg','Tuna',2500,NULL);
INSERT INTO `Products` VALUES (4,4,'Cereals, dry','Cereals',900,NULL);
INSERT INTO `Products` VALUES (5,4,'Apricots from Armenia, kg','Apricot',600,NULL);
INSERT INTO `Products` VALUES (6,5,'Kitkat Extra large','Kitkat',450,'');
INSERT INTO `Products` VALUES (7,2,'Pork, kg','Pork',4200,NULL);
INSERT INTO `Products` VALUES (8,5,'Twix, normal size','Twix',300,NULL);
INSERT INTO `Products` VALUES (9,3,'Frozen beef, package','Beef',2000,NULL);
INSERT INTO `Products` VALUES (10,2,'Chicken wings, kg','Chickend wings',1850,NULL);
INSERT INTO `Products` VALUES (11,5,'Grand Candy sweets collection, kg','Grand candy',3250,NULL);
INSERT INTO `Products` VALUES (12,5,'Ferrero Roshen chocolate sweets, kg','Roshen Chocolate',3980,NULL);
INSERT INTO `Products` VALUES (13,4,'Beans, kg','Beans',1400,NULL);
INSERT INTO `Products` VALUES (14,4,'Banan, kg','Banan',1250,NULL);
INSERT INTO `Products` VALUES (15,1,'Prawns, kg','Prawns',6700,NULL);
INSERT INTO `Products` VALUES (16,3,'Frozen cranberries, pack','Cranberries',3600,NULL);
INSERT INTO `Products` VALUES (17,1,'Black caviar, 100g','Black Caviar',8900,NULL);
INSERT INTO `Products` VALUES (18,5,'Mozart sweet pack','Mozart chocolate',9500,NULL);
INSERT INTO `Products` VALUES (19,4,'Ananas','Ananas',6000,NULL);
INSERT INTO `Products` VALUES (20,1,'Red fish caviar, black sea, 300g','Red caviar',11000,NULL);
CREATE TABLE "Orders" (
	`ID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`Address`	TEXT NOT NULL,
	`City`	TEXT,
	`Country`	TEXT,
	`Email`	TEXT NOT NULL,
	`FirstName`	TEXT NOT NULL,
	`LastName`	TEXT NOT NULL,
	`OrderDate`	TEXT,
	`Phone`	TEXT,
	`PostalCode`	TEXT,
	`State`	TEXT,
	`Total`	TEXT,
	`Username`	TEXT
);
CREATE TABLE "OrderItems" (
	`ID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`OrderID`	INTEGER,
	`ProductID`	INTEGER NOT NULL,
	`Quantity`	INTEGER NOT NULL,
	`UID`	TEXT,
	FOREIGN KEY(`ProductID`) REFERENCES `Products`(`ID`) ON DELETE CASCADE
);
CREATE TABLE "Categories" (
    "ID" INTEGER NOT NULL CONSTRAINT "PK_Categories" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL
);
INSERT INTO `Categories` VALUES (1,'Fish and Seafood');
INSERT INTO `Categories` VALUES (2,'Meat Products');
INSERT INTO `Categories` VALUES (3,'Frozen Products');
INSERT INTO `Categories` VALUES (4,'Organic Products');
INSERT INTO `Categories` VALUES (5,'Sweets');
CREATE INDEX "IX_Products_CategoryID" ON "Products" ("CategoryID");
CREATE INDEX "IX_OrderItems_ProductID" ON "OrderItems" ("ProductID")
;
COMMIT;
