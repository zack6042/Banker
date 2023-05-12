# Banker
Banker's Algorithm using C#
The project discusses the Banker's Algorithm 
This C# program implements the Banker's algorithm and determines whether a given system is in a safe state or not. The program takes input from the user for the number of processes, the number of resources, and the maximum need and currently allocated resources for each process.
it implements with any number of processes and any number of resources 
the code starts by taking input from the user for all resources matrices {resources,maximum,currently allocated and available} using the function initializevalues()
then it calculates the needed resources for each process need=Max-currently allocated using the function CalculateNeed()
then it checks wether the simulation of resources and processes you mentioned is safe or not using issafe() fn by comparing the need with the available resources and if need =available release those resources to then be used on another process untill a sequence is determined
if the need is bigger than the available in all processes then this simulation is not safe

