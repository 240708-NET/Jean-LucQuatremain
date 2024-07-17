-- CREATE database DemoDB;
-- USE DemoDB;

-- CREATE SCHEMA Demo;

/*
CREATE table Demo.DemoTable(
    demo_id int IDENTITY(1, 1) PRIMARY KEY,
    demo_name VARCHAR(255) NOT NULL,
    demo_date TIMESTAMP
)
*/

ALTER table DemoTable
ADD demo_description VARCHAR(255) NOT NULL


EXEC sp_rename 'dbo.DemoTable.demo_description', 'new_column_name', 'COLUMN';

INSERT INTO DemoTable (demo_name, new_column_name) VALUES ('my Value',  'new value description');

SELECT * FROM DemoTable;

INSERT INTO DemoTable(demo_date) VALUES (CURRENT_TIMESTAMP);

UPDATE DemoTable
    SET 



EXEC sp_rename 'DemoTable', 'DemoTable_old';

-- Step 2: Create a new table with the correct DATETIME data type
CREATE TABLE DemoTable (
    demo_id int IDENTITY(1, 1) PRIMARY KEY,
    demo_name VARCHAR(255) NOT NULL,
    demo_date DATETIME
);

-- Step 3: Copy data from the old table to the new table
INSERT INTO DemoTable (demo_id, demo_name, demo_date)
SELECT demo_id, demo_name, GETDATE()
FROM DemoTable_old;

-- Step 4: Drop the old table
DROP TABLE DemoTable_old;

-- Step 5: Rename the new table to the original table name
EXEC sp_rename 'Demo.DemoTable', 'Demo.DemoTable';


DROP TABLE Demo.Demo.DemoTable;