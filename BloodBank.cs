﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace bloodbank
{
    class BloodBank
    {
        static void Main(string[] args)
        {

            int id = 1;
            List<int> IdList = new List<int>();
            IdList.Add(0);
            string[] types = new string[] { "O+", "O-", "B-", "B+", "A+", "A-", "AB+", "AB-" };
            List<Donor> donors = new List<Donor>();



            void AddUser()
            {
                bool done = false;
                Console.Clear();
                Console.WriteLine("You will be required to fill out all fields for every new user.");
                Thread.Sleep(2000);
                Console.Clear();
                while (!done)
                {
                Begin:
                    Console.WriteLine("Enter new Users name, or enter nothing to finish.");
                    string userInputName = Console.ReadLine();
                    if (userInputName == "")
                    {
                        done = true;
                    }
                    else
                    {
                        Console.WriteLine("Enter users age.");
                        int userInputAge = int.Parse(Console.ReadLine());
                        if (userInputAge < 18)
                        {
                            Console.WriteLine("User must be 18 or older.");
                            Thread.Sleep(2000);
                            Console.Clear();
                            goto Begin;
                        }
                    Blood:
                        Console.WriteLine("Enter new Users blood type.");
                        string userInputBloodType = (Console.ReadLine()).ToUpper();
                        if (types.Contains(userInputBloodType))
                        {
                        }
                        else
                        {
                            Console.WriteLine("Invalid blood type entered. Please enter correct blood type.");
                            Thread.Sleep(2000);
                            Console.Clear();
                            goto Blood;
                        }
                        Console.WriteLine("Enter users phone number.");
                        long userInputPhone = long.Parse(Console.ReadLine());



                        Donor donor = new Donor(userInputName, userInputAge, userInputBloodType, userInputPhone, id);
                        IdList.Add(id);

                        id++;
                        donors.Add(donor);
                    }
                }
            }

            void SearchUser(int parameter)
            {
                string parameterName;
                bool invalid = true;


                if (parameter == 1)
                {
                    parameterName = "name";
                } else if (parameter == 2)
                {
                    parameterName = "age";
                } else if (parameter == 3)
                {
                    parameterName = "blood type";
                } else
                {
                    parameterName = "phone number";
                }
                StartSearch:
                Console.WriteLine("Please enter the " + parameterName + " you would like to see details for. Enter 0 when finished viewing results.");
                if (parameterName == "name")
                {
                    string userPersonChoice = Console.ReadLine();
                    foreach (Donor person in donors)
                    {
                        if (person.name == userPersonChoice)
                        {
                            Console.WriteLine("User name: " + person.name);
                            Console.WriteLine("User age: " + person.age);
                            Console.WriteLine("User Blood Type: " + person.bloodType);
                            Console.WriteLine("User Phone Number: " + person.phoneNumber);
                            Console.WriteLine("User ID: " + person.id + "\n");
                            invalid = false;
                        }
                    }
                    if (invalid == true)
                    {
                        Console.WriteLine("No users with that name found.");
                        goto StartSearch;
                    }
                }

                if (parameterName == "age")
                {
                    int userPersonAge = int.Parse(Console.ReadLine());
                    foreach (Donor person in donors)
                    {
                        if (person.age == userPersonAge)
                        {
                            Console.WriteLine("User name: " + person.name);
                            Console.WriteLine("User age: " + person.age);
                            Console.WriteLine("User Blood Type: " + person.bloodType);
                            Console.WriteLine("User Phone Number: " + person.phoneNumber);
                            Console.WriteLine("User ID: " + person.id + "\n");
                            invalid = false;
                        }
                    }
                    if (invalid == true)
                    {
                        Console.WriteLine("No users with that age found.");
                        goto StartSearch;
                    }
                }


                if (parameterName == "blood type")
                {
                    string userPersonBloodType = (Console.ReadLine()).ToUpper();
                    foreach (Donor person in donors)
                    {
                        if (person.bloodType == userPersonBloodType)
                        {
                            Console.WriteLine("User name: " + person.name);
                            Console.WriteLine("User age: " + person.age);
                            Console.WriteLine("User Blood Type: " + person.bloodType);
                            Console.WriteLine("User Phone Number: " + person.phoneNumber);
                            Console.WriteLine("User ID: " + person.id + "\n");
                            invalid = false;
                        }
                    }
                    if (invalid == true)
                    {
                        Console.WriteLine("No users with that blood type found.");
                        goto StartSearch;
                    }
                }

                if (parameterName == "phone number")
                {
                    long userPersonPhoneNumber = long.Parse(Console.ReadLine());
                    foreach (Donor person in donors)
                    {
                        if (person.phoneNumber == userPersonPhoneNumber)
                        {
                            Console.WriteLine("User name: " + person.name);
                            Console.WriteLine("User age: " + person.age);
                            Console.WriteLine("User Blood Type: " + person.bloodType);
                            Console.WriteLine("User Phone Number: " + person.phoneNumber);
                            Console.WriteLine("User ID: " + person.id + "\n");
                            invalid = false;
                        }
                    }
                    if (invalid == true)
                    {
                        Console.WriteLine("No users with that phone number found.");
                        goto StartSearch;
                    }
                }




                bool run = true;
                while (run && !invalid)
                {
                    if (int.Parse(Console.ReadLine()) == 0)
                    {
                        break;
                    }
                }
            }

            void UpdateUser()
            {
                int userIdChoice = 0;
                bool goBack = false;
                bool check = false;
                while (!check)
                {
                    Console.Clear();
                    Console.WriteLine("To Update user, please enter their ID number. If you do not know their ID number, use the Search User function on the previous page. Enter 0 if you wish to return to the main menu.");
                    userIdChoice = int.Parse(Console.ReadLine());
                    if(userIdChoice == 0)
                    {
                        goBack = true;
                    }
                    if (IdList.Contains(userIdChoice))
                    {
                        check = true;
                    }
                    else
                    {
                        Console.WriteLine("User ID not found. Please enter a valid ID.");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                }
                if (goBack)
                {
                    check = false;
                }
                while (check)
                {
                    Console.WriteLine("What would you like to update?\nName: '1'\nAge: '2'\nBlood Type: '3'\n'Phone Number'4'");
                    int userAttributeToUpdate = int.Parse(Console.ReadLine());

                    switch (userAttributeToUpdate)
                    {
                        case 1:
                            {
                                foreach (Donor person in donors)
                                { 
                                    Console.Clear();
                                    Console.WriteLine("Enter new Name for " + person.name + ".");
                                    person.name = Console.ReadLine();
                                }
                                check = false;
                                break;
                            }
                        case 2:
                            {
                                foreach (Donor person in donors)
                                {
                                    if (person.id == userIdChoice)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Enter new age for " + person.name + ".");
                                        person.age = int.Parse(Console.ReadLine());
                                    }
                                }
                                check = false;
                                break;
                            }
                        case 3:
                            {
                                foreach (Donor person in donors)
                                {
                                    if (person.id == userIdChoice)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Enter new Blood Type for " + person.name + ".");
                                        person.bloodType = Console.ReadLine();
                                    }
                                }
                                check = false;
                                break;
                            }
                        case 4:
                            {
                                foreach (Donor person in donors)
                                {
                                    if (person.id == userIdChoice)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Enter new Phone Number for " + person.name + ".");
                                        person.phoneNumber = long.Parse(Console.ReadLine());
                                    }
                                }
                                check = false;
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("You have entered an incorrect value. Please select Again.");
                                Thread.Sleep(2000);
                                Console.Clear();
                                break;
                            }
                    }
                }
            }

            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do? Type the number associated with your choice. ");
                Thread.Sleep(400);
                Console.WriteLine("Add New User: '1' \nSearch for User: '2' \nUpdate User's info: '3' ");
                int userChoice = int.Parse(Console.ReadLine());
                if (userChoice == 1)
                {
                    Console.Clear();
                    AddUser();
                }
                else if (userChoice == 2)
                {
                    Console.Clear();
                    MetricSearch:
                    Console.WriteLine("What metric would you like to search by?\nName: '1'\nAge: '2'\nBlood Type: '3'\nPhone Number: '4'");
                    int userSearchChoice = int.Parse(Console.ReadLine());
                    if (userSearchChoice == 1 || userSearchChoice == 2 || userSearchChoice == 3 || userSearchChoice == 4)
                    { 
                    } 
                    else
                    {
                        Console.WriteLine("Please enter a correct value to search by.");

                        goto MetricSearch;
                    }
                    Console.Clear();
                    SearchUser(userSearchChoice);
                } 
                else if (userChoice == 3)
                {
                    Console.Clear();
                    UpdateUser();
                }
                
                






                /** TO ADD
                if searching, how will you be searching like by name, age, etc
                more checks for wrong things. like if name has #, or phone isn't right. So the program can't break
                options to back at any point
                **/

                
            }
        }
    }
}
