using System;
using System.Collections.Generic;
using System.Threading;

namespace Parkering_Prag1._0
{
    class Program
    {
        static public void Main()
        {
            string[] ParkingLots = new string[101];
            { };

            for (var i = 1; i < 101; i++)
            {
                ParkingLots[i] = "EMPTY1 ; EMPTY2";
            }

            bool retry = true;
            while (retry)   //Om användaren anger fel så kommer man tillbaka till menyn.
            {
                Console.WriteLine("Welcome to Prague Parking");
                Console.WriteLine();
                Console.WriteLine("1. Park vehicle");
                Console.WriteLine("2. Unpark vehicle");
                Console.WriteLine("3. Move a vehicle");
                Console.WriteLine("4. Search for a vehicle");
                Console.WriteLine("5. Show all");
                Console.WriteLine();
                Console.WriteLine("6. Exit program (Admin only)");
                Console.WriteLine();
                Console.WriteLine("Choose a number and press \"enter\" for the desired selection:");
                string menyInput = Console.ReadLine();
                int userChoice;
                Int32.TryParse(menyInput, out userChoice);

                //Switch meny
                switch (userChoice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Enter: 1. Car | 2. MC");
                        string vehicletype = Console.ReadLine().ToUpper();
                        int Type;
                        Int32.TryParse(vehicletype, out Type);

                        if (Type == 2)
                        {
                            Console.WriteLine("Enter your license plate number: ");
                            string vehicle = Console.ReadLine().ToUpper();
                            if (vehicle.Length == 10)
                            {
                                ParkVehicleMC(vehicle, ParkingLots);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("License plate number must be 10");
                                break;
                            }
                        }
                        else if (Type == 1)
                        {
                            Console.WriteLine("Enter your license plate number: ");
                            string vehicle1 = Console.ReadLine().ToUpper();
                            if (vehicle1.Length == 10)
                            {
                                ParkVehicle(vehicle1, ParkingLots);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("License plate number must be 10");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("You have entered an invalid input");
                        }

                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Enter: 1. Car | 2. MC");
                        string vehicletype1 = Console.ReadLine().ToUpper();
                        int Type1;
                        Int32.TryParse(vehicletype1, out Type1);

                        if (Type1 == 2)
                        {
                            Console.WriteLine("Enter your license plate number: ");
                            string vehicle = Console.ReadLine().ToUpper();
                            if (vehicle.Length == 10)
                            {
                                UnParkVehicleMC(vehicle, ParkingLots);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("License plate number must be 10 characters");
                                break;
                            }
                        }
                        else if (Type1 == 1)
                        {
                            Console.WriteLine("Enter your license plate number: ");
                            string vehicle1 = Console.ReadLine().ToUpper();
                            if (vehicle1.Length == 10)
                            {
                                UnParkVehicle(vehicle1, ParkingLots);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("License plate number must be 10 characters");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("You have entered an invalid input");
                        }
                        break;
                    case 3:

                        Console.Clear();
                        Console.WriteLine("Enter: 1. Car | 2. MC");
                        string moveVehicle1 = Console.ReadLine().ToUpper();
                        int moveVehicle;
                        Int32.TryParse(moveVehicle1, out moveVehicle);
                        if (moveVehicle == 1)
                        {
                            Console.WriteLine("Enter your license plate number: ");
                            string regplate = Console.ReadLine().ToUpper();
                            MoveVehicle(regplate, ParkingLots);
                        }
                        else if (moveVehicle == 2)
                        {
                            Console.WriteLine("Enter your license plate number: ");
                            string regplate1 = Console.ReadLine().ToUpper();
                            MoveVehicleMC(regplate1, ParkingLots);
                        }
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Search with your license plate number: ");
                        string vehicleOut2 = Console.ReadLine().ToUpper();
                        Console.Clear();
                        SearchVehicle(vehicleOut2, ParkingLots);
                        Thread.Sleep(3000);
                        break;
                    case 5:
                        Console.Clear();
                        ShowAll(ParkingLots);
                        break;
                    case 6:
                        Console.WriteLine("Program is shutting down");
                        retry = false;
                        break;

                    default:
                        retry = true;
                        break;
                }
            }
        }
        //Metod för att parkera bilar
        static void ParkVehicle(string vehicle, string[] ParkingLots)
        {
            for (var y = 1; y < ParkingLots.Length; y++)
            {
                if (ParkingLots[y] == "EMPTY1 ; EMPTY2")
                {
                    ParkingLots[y] = ParkingLots[y].Replace("EMPTY1 ; EMPTY2", vehicle);
                    Console.Clear();
                    Console.WriteLine("Vehicle with license nr: \"{0}\" is parked in lot: \"{1}\"", vehicle, y);
                    Thread.Sleep(3000);
                    Console.Clear();
                    break;
                }
            }
        }
        //Metod för att parkera MC
        static void ParkVehicleMC(string vehicle, string[] ParkingLots)
        {
            for (var y = 1; y < ParkingLots.Length; y++)
            {
                if (ParkingLots[y].Substring(0, 6) == "EMPTY1")
                {
                    ParkingLots[y] = ParkingLots[y].Replace("EMPTY1", vehicle);
                    Console.Clear();
                    Console.WriteLine("Vehicle with license nr: \"{0}\" is parked in lot: \"{1}\"", vehicle, y);
                    Thread.Sleep(3000);
                    Console.Clear();
                    break;
                }
                else if (ParkingLots[y].Length > 13 && ParkingLots[y].Substring(13, 6) == "EMPTY2")
                {
                    ParkingLots[y] = ParkingLots[y].Replace("EMPTY2", vehicle);
                    Console.Clear();
                    Console.WriteLine("Vehicle with license nr: \"{0}\" is parked in slot: \"{1}\"", vehicle, y);
                    Thread.Sleep(3000);
                    Console.Clear();
                    break;
                }
            }
        }
        //Metod för att avparkering av bil
        static void UnParkVehicle(string vehicleOut, string[] ParkingLots)
        {
            for (var y = 1; y < ParkingLots.Length; y++)
            {
                if (ParkingLots[y] == vehicleOut)
                {
                    ParkingLots[y] = ParkingLots[y].Replace(vehicleOut, "EMPTY1 ; EMPTY2");
                    Console.Clear();
                    Console.WriteLine("Vehicle with license nr: \"{0}\" was parked in lot: \"{0}\" has now been removed", vehicleOut, y);
                    Thread.Sleep(3000);
                    Console.Clear();
                    break;
                }
            }
        }
        //Metod för avparkering av MC
        static void UnParkVehicleMC(string vehicleOut, string[] ParkingLots)
        {
            for (var y = 1; y < ParkingLots.Length; y++)
            {

                if (ParkingLots[y] == vehicleOut)
                {
                    ParkingLots[y] = ParkingLots[y].Replace(vehicleOut, "EMPTY1 ; EMPTY2");
                    Console.Clear();
                    Console.WriteLine("Vehicle with license nr: \"{0}\" was parked in lot: \"{1}\" has now been moved", vehicleOut, y);
                    Thread.Sleep(3000);
                    Console.Clear();
                    break;
                }
                if (ParkingLots[y].Substring(0, 10) == "EMPTY1")
                {
                    ParkingLots[y] = ParkingLots[y].Replace(vehicleOut, "EMPTY1");
                    Console.Clear();
                    Console.WriteLine("Vehicle MC with license nr: \"{0}\" was parked in lot: \"{1}\" has now been moved", vehicleOut, y);
                    Thread.Sleep(3000);
                    Console.Clear();
                    break;
                }
                else if (ParkingLots[y].Length > 13 && ParkingLots[y].Substring(13, 10) == "EMPTY2")
                {
                    ParkingLots[y] = ParkingLots[y].Replace(vehicleOut, "EMPTY2");
                    Console.Clear();
                    Console.WriteLine("Vehicle with license nr: \"{0}\" is parked in lot: \"{1}\"", vehicleOut, y);
                    Thread.Sleep(3000);
                    Console.Clear();
                    break;
                }

            }
        }
        //Metod för att söka efter fordon
        static void SearchVehicle(string vehicleOut2, string[] ParkingLots)
        {
            int sum = 0;
            for (var i = 1; i < ParkingLots.Length; i++)
            {
                if (ParkingLots[i].Contains(vehicleOut2))
                {
                    Console.WriteLine("Your vehicle matched with plate number \"{0}\", and is placed in parking lot nr: \"{1}\"", vehicleOut2, i);
                    sum++;
                    break;
                }
            }
            if (sum == 0)
            {
                Console.WriteLine("No license plate matched");
            }
        }
        //Metod för att se hela listan
        static void ShowAll(string[] ParkingLots)
        {
            for (var x = 0; x < ParkingLots.Length; x++)
            {
                Console.WriteLine(ParkingLots[x]);
            }
        }
        //Metod för att flytta bilar
        static void MoveVehicle(string regplate, string[] ParkingLots)
        {
            for (var i = 0; i < ParkingLots.Length; i++)
            {
                if (regplate == ParkingLots[i])
                {
                    Console.Clear();
                    ParkingLots[i] = "EMPTY1 ; EMPTY2";
                    Console.WriteLine("Which lot do you want to move vehicle to: ");
                    string moveNr = Console.ReadLine();
                    int moveVehicle;
                    Int32.TryParse(moveNr, out moveVehicle);
                    if (ParkingLots[moveVehicle] == "EMPTY1 ; EMPTY2")
                    {
                        Console.Clear();
                        ParkingLots[moveVehicle] = ParkingLots[moveVehicle].Replace("EMPTY1 ; EMPTY2", regplate);
                        Console.WriteLine("Your vehicle with regplate \"{0}\" is now moved to lot: \"{1}\"", regplate, moveNr);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("This lot is full");
                        break;
                    }

                }
            }
        }
        //Metod för att flytta MC
        static void MoveVehicleMC(string regplate1, string[] ParkingLots)
        {
            for (var i = 1; i < ParkingLots.Length; i++)
            {
                if (ParkingLots[i].Substring(0, 10) == regplate1)
                {
                    ParkingLots[i] = ParkingLots[i].Replace(regplate1, "EMPTY1");
                    Console.WriteLine("Which lot do you want to move MC vehicle to: ");
                    break;
                }
                else if (ParkingLots[i].Length > 13 && ParkingLots[i].Substring(9, 10) == regplate1)
                {
                    ParkingLots[i] = ParkingLots[i].Replace(regplate1, "EMPTY2");
                    Console.WriteLine("Which lot do you want to move MC vehicle to: ");
                    break;
                }
                else if (ParkingLots[i].Length > 23 && ParkingLots[i].Substring(13, 10) == regplate1)
                {
                    ParkingLots[i] = ParkingLots[i].Replace(regplate1, "EMPTY2");
                    Console.WriteLine("Which lot do you want to move MC vehicle to: ");
                    break;
                }

            }

            var vehicleMove = int.Parse(Console.ReadLine());


            if (ParkingLots[vehicleMove].Substring(0, 6) == "EMPTY1")
            {
                ParkingLots[vehicleMove] = ParkingLots[vehicleMove].Replace("EMPTY1", regplate1);
                Console.WriteLine("Your vehicle with reg plate \"{0}\" has been moved to lot \"{1}\"", regplate1, vehicleMove);

            }
            else if (ParkingLots[vehicleMove].Substring(9, 6) == "EMPTY2")
            {
                ParkingLots[vehicleMove] = ParkingLots[vehicleMove].Replace("EMPTY2", regplate1);
                Console.WriteLine("Your vehicle with reg plate \"{0}\" has been moved to lot \"{1}\"", regplate1, vehicleMove);
            }
            else if (ParkingLots[vehicleMove].Substring(13, 6) == "EMPTY2")
            {
                ParkingLots[vehicleMove] = ParkingLots[vehicleMove].Replace("EMPTY2", regplate1);
                Console.WriteLine("Your vehicle with reg plate \"{0}\" has been moved to lot \"{1}\"", regplate1, vehicleMove);
            }
            else
            {
                Console.WriteLine("This lot is full");
                return;
            }
        }
    }
}
