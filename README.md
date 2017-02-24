1> CREATE DATABASE hair_salon;
2> go;
1> USE hair_salon;
2> go;
Changed database context to 'hair_salon'.
1> CREATE TABLE clients (id INT IDENTITY(1, 1), stylist_id INT, name VARCHAR(255), hair_color VARCHAR(50), creation_date
 DATETIME);
2> go;
1> CREATE TABLE stylists (id INT IDENTITY(1,1), name VARCHAR(255));
2> go;
1>
