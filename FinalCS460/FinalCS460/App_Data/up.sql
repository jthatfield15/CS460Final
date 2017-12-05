CREATE TABLE dbo.BUYERS
(
	BuyerID		INT IDENTITY(1,1) NOT NULL,
	BuyerName	NVARCHAR(64) NOT NULL,
	CONSTRAINT[PK_dbo.BUYERS] PRIMARY KEY CLUSTERED (BuyerID ASC)
);

CREATE TABLE dbo.SELLERS
(
	SellerID	INT IDENTITY(1,1) NOT NULL,
	SellerName	NVARCHAR(64) NOT NULL,
	CONSTRAINT[PK_dbo.SELLERS] PRIMARY KEY CLUSTERED (SellerID ASC)
);

CREATE TABLE dbo.ITEMS
(
	ItemID		INT IDENTITY(1,1) NOT NULL,
	ItemName	NVARCHAR(64) NOT NULL,
	ItemDesc	NVARCHAR(128) NOT NULL,
	SellerID	INT NOT NULL,
	CONSTRAINT[PK_dbo.ITEMS] PRIMARY KEY CLUSTERED (ItemID ASC),
	CONSTRAINT[FK_dbo.ITEMS_SELLERS] FOREIGN KEY (SellerID)
		REFERENCES dbo.SELLERS (SellerID)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

CREATE TABLE dbo.BIDS
(
	BidID		INT IDENTITY(1,1) NOT NULL,
	Price		FLOAT NOT NULL,
	BidDateTime	DATETIME NOT NULL,
	ItemID		INT NOT NULL,
	BuyerID		INT NOT NULL,
	CONSTRAINT[PK_dbo.BIDS] PRIMARY KEY CLUSTERED (BidID ASC),
	CONSTRAINT[FK_dbo.BIDS_ITEMS] FOREIGN KEY (ItemID)
		REFERENCES dbo.ITEMS (ItemID)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	CONSTRAINT[FK_dbo.BIDS_BUYERS] FOREIGN KEY (BuyerID)
		REFERENCES dbo.BUYERS (BuyerID)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

INSERT INTO dbo.BUYERS (BuyerName) VALUES
('Jane Stone'),
('Tom McMasters'),
('Otto Vanderwall');

INSERT INTO dbo.SELLERS (SellerName) VALUES
('Gayle Hardy'),
('Lyle Banks'),
('Pearl Greene');

INSERT INTO dbo.ITEMS (SellerID, ItemName, ItemDesc) VALUES
(3, 'Abraham Lincoln Hammer'    ,'A bench mallet fashioned from a broken rail-splitting maul in 1829 and owned by Abraham Lincoln'),
(1, 'Albert Einsteins Telescope','A brass telescope owned by Albert Einstein in Germany, circa 1927'),
(2, 'Bob Dylan Love Poems'      ,'Five versions of an original unpublished, handwritten, love poem by Bob Dylan');

INSERT INTO dbo.BIDS (ItemID, BuyerID, Price, BidDateTime) VALUES
(1, 3, 250000,'12/04/2017 09:04:22'),
(3, 1, 95000 ,'12/04/2017 08:44:03');