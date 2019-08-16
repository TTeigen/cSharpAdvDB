# Pierre's Sweets and Treats

#### An application that allows the user to manage a Savory & Sweet shop, 8/16/2019_

#### _By **Trevor Teigen**_

## Description 

User can add treats with various flavors, remove them, or modify them

### Specs


### Specs
| Spec | Input | Output |
| :-------------     | :------------- | :------------- |
| **Show a splash page with navigation options** | View Index | "Welcome" page |
|Just a simple splash page marking the "homepage" of the application|
| **Add a Flavor or Treat** | New Treat or New Flavor | Store Flavor/Treat in Database |
|By storing the flavors and treats in databases we will be able to call/edit them later|
| **Edit Treat or Flavor** | Chocolate Croissant has a sweet flavor not spicy | ChocolateCroissant(TreatId 1) joined with Flavor Sweet (FlavorId 1) instead of Flavor Spicy (FlavorId 2) |
|Being able to update the flavor/treat relationships will change how the user sees them on the corresponding pages|
| **Display information about a specific Flavor/Treat** | Flavor Category "Sweet" | Lists "Chocolate Croissant, Cookie, Twinkie" |
|We want users to be able to sort by flavor or treat and see the corresponding information|
| **Delete Flavor or Treat** | No longer need "Spicy" | Remove's spicy as a flavor from the database |
|If a product is no longer available or a flavor is no longer relevant we want to remove it from the database|


## Setup/Installation Requirements

* go to https://github.com/tteigen/cSharpAdvDB

* Open up your terminal, go to the desktop screem and type in the command "git clone https://github.com/tteigen/cSharpAdvDB

* once you have this webpage cloned to your desktop navigate into the folder and run the command "dotnet run" in the command line.

## Known Bugs
* no known bugs at this time.

## Technologies Used
* c#
* mySql
* .net Core
* Entity

## Support and contact details

_Please contact Trevor Teigen with questions and comments._

### License

*GNU GPLv3*