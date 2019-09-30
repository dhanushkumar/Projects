README

App will not work if the following conditions are met

1. If the number of players entered is not an integer
2. If the number of players are less than 0 or more than 23 (less than 24) 
3. If User Id is not specified

TESTING THE APPLICATION
-------------------------------------------------------------------------------------------------------
The application is developed using .net Core (C#) as the language. Compiled library can be located in the netcoreapp2.1 folder (Three Card Poker\Three Card Poker\bin\Release\netcoreapp2.1). Name of the library is 
Three Card Poker.dll
To Run the Test
./run_tests "Three Card Poker.dll" 


Patterns Used
----------------------------------------------------------------------------------------------------------------------

Each rule has its Strategy. Naturally, Strategy pattern comes in to mind. However, the pattern is not a perfect implementation in this application due to time constraints. I was also hoping to use a provider  pattern for input. This is to swap the entry point from manual to read from folder. I didn't get that far, as a result dropped the idea