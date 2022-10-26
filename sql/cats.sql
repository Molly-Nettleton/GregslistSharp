-- NOTE varchar = string
CREATE TABLE IF NOT EXISTS cats(
   id INT AUTO_INCREMENT PRIMARY KEY,
   name VARCHAR(255)
);

INSERT INTO cats (name) VALUES ("Goblin");
INSERT INTO cats (name) VALUES ("Feta");
INSERT INTO cats (name) VALUES ("Monkey");
INSERT INTO cats (name) VALUES ("Mooma");


SELECT * FROM cats WHERE name = "Goblin";
SELECT * FROM cats WHERE name LIKE "M%";
SELECT * FROM cats WHERE id = "3";

UPDATE cats SET
  name = "Robert Bobert"
 WHERE id = 1;


ALTER TABLE cats ADD COLUMN(
  age int DEFAULT 0
);

SELECT * FROM cats;


-- NOTE POSITION 3 WILL REMAIN EMPTY AND NEVER BE FILLED EVEN WHEN NEW ITEM IS ADDED
DELETE FROM cats WHERE id = 3;


DROP TABLE cats