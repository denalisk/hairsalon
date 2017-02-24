# "Hair Salon" An Exercise in Object-Oriented CSharp

#### _Hair Salon_, 02.17.2017

### By _Sam Kirsch_

## Description

#### A website built as an exercise in sql database creation and interaction. Designed to simulate have a number of hair salon employees and their associated clients.

## Specifications

* Users can add Stylists
* Users can add Clients to Stylists
* Users can reassign Clients to new stylists
* Users can edit clients names
* Users can delete clients

#### Stretch Goals

* Spruce up the site
* Implement the rest of the functionality left in the back end

## Setup

* Clone this repository
* Enter these commands into a local SQL database terminal editor:
*  CREATE DATABASE hair_salon;
*  USE hair_salon;
*  CREATE TABLE clients (id INT IDENTITY(1, 1), stylist_id INT, name VARCHAR(255), hair_color VARCHAR(50), creation_date DATETIME);
*  CREATE TABLE stylists (id INT IDENTITY(1,1), name VARCHAR(255));
*  CREATE DATABASE hair_salon_test;
*  USE hair_salon_test;
*  CREATE TABLE clients (id INT IDENTITY(1, 1), stylist_id INT, name VARCHAR(255), hair_color VARCHAR(50), creation_date DATETIME);
*  CREATE TABLE stylists (id INT IDENTITY(1,1), name VARCHAR(255));

* Initialize a local kestrel server
* Navigate to http://localhost:5004/

### Technologies Used

* HTML
* msSql
* CSS with bootstrap
* CSharp using Nancy, Razor, and Xunit

[gh-pages link for this project](https://denalisk.github.io/hairsalon)

##### Copyright (c) 2017 Sam Kirsch.

##### Licensed under the MIT license.
