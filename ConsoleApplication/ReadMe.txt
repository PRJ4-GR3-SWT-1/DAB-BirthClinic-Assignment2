This README file will explain (in Danish) how to use the system.

1. Der skal på computeren oprettes en local MSQL database server med navnet "DABServer". Programmet sørger selv for at oprette en database der hedder "BirthClinic". 
2. Herefter kan programmet køres.
3. Der er en menu tilgængelig. Man kan vælge mellem 5 forskellige cases: 
	1. Vis planlagte fødsler.
		- Viser planlagte fødsler de kommende 3 dage - inklusiv BirthID, planlagt starttidspunkt, navn på barnet og associerede 
		  klinisk personale.
	2. Ledige rum og klinikarbejdere
		- Viser hvilke ledige rum der er og hvilke klinikarbejdere der er ledige de kommende 5 dage. 
	3. Aktuelt igangværende fødsler
		- Viser igangværende fødsler, hvilket rum det sker i, samt associerede personer (både personale, barn, mor og evt familie).
	4. Værelser i brug lige nu (ikke fødselsrum)
		- Viser hvilke værelser (Maternity rooms & resting rooms) der er i bruge på nuværende tidspunkt. 
		  Viser også information om hvilken type af rum, navnet på rummet, moren i rummet, barn og associerede familiemedlemmer. 
	5. Vis reserverede rum og associeret klinik personale til en specifik fødsel. 
		- Efter indtasting af BirthID (fødsels ID), vil alle associerede rum og klinisk personale blive vist.
   Derudover kan man vælge en af følgende funktionaliteter: 
	F: Færdiggør reservation af rum
		- Her kan vælge at afslutte sin rum-reservation ved at indtaste reservations id.
	B: Lav en reservation til fødsel
		- Man kan oprette en ny fødsels reservation, hvilket kræver barnets (midlertidige) navn, navn på moderen og tidspunktet for fødslen.
		- Ved valg af personale og rum SKAL man vælge en af de viste muligheder.
		- Indtastning af dato og tidspunkt skal overholde de skrevne anvisninger. 
	A: Annuller reservation af rum
		- Man kan annullere en reservation af rum ved at indtaste reservations id.
4. Til sidst kan man afslutte programmet ved at trykke "x".

************************** OBS ******************************
Bemærk at der kan læses nærmere om systemrelevante beslutninger og antagelser i .txt-filen "Decisions and Assumptions".
************************** Ekstra ***************************
For yderligere overblik over indholdet af databasen, se ERD (Entity relationsship Diagram) vedlagt i DDS_ERD_Diagram-mappen. 
