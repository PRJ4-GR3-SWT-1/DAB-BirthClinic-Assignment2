This README file will explain (in Danish) how to use the system.

1. Der skal på computeren oprettes en local MSQL database server med navnet "DABServer" og herefter en database der hedder "BirthClinic". 
2. MÅSKE: Herefter køres Update-Database i VS-Package-Manager-Console. 
3. Herefter kan programmet køres.
4. Der er en menu tilgængelig. Man kan vælge mellem 5 forskellige cases: 
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
	A: Annuller reservation af rum
		- Man kan annullere en reservation af rum ved at indtaste reservations id.
5. Til sidst kan man afslutte programmet ved at trykke "x".




Bemærk at der kan læses nærmere om systemrelevante beslutninger og antagelser i .txt-filen "Decisions and Assumptions".