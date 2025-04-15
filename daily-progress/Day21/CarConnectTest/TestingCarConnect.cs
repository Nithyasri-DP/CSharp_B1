using NUnit.Framework;
using CarConnect.dao;
using CarConnect.entity;
using CarConnect.exception;
using System;
using System.Collections.Generic;
using CarConnect.service;

namespace CarConnectTest
{
    [TestFixture]
    public class TestingCarConnect
    {
        private AuthenticationService authService;
        private CustomerService customerService;
        private VehicleService vehicleService;

        [SetUp]
        public void Setup()
        {
            authService = new AuthenticationService();
            customerService = new CustomerService();
            vehicleService = new VehicleService();
        }

        // 1. Test customer authentication with invalid credentials
        [TestCase("JAYA", "j67")]
        [TestCase("admin9", "a3")]
        public void TestCustomerAuthenticationWithInvalidCredentials(string username, string password)
        {
            Assert.Throws<AuthenticationException>(() => authService.AuthenticateCustomer(username, password));
        }

        // 2. Test updating customer information
        [TestCase(1, "Ananya", "ananyabhat@email.com")]
        public void TestUpdatingCustomerInformation(int customerId, string newFirstName, string newEmail)
        {
            var customer = customerService.GetCustomerById(customerId);
            customer.FirstName = newFirstName;
            customer.Email = newEmail;

            customerService.UpdateCustomer(customer);
            var updated = customerService.GetCustomerById(customerId);

            Assert.AreEqual(newFirstName, updated.FirstName);
            Assert.AreEqual(newEmail, updated.Email);
        }

        // 3. Test adding a new vehicle
       [TestCase("BMW", "Ford", 2025, "Bllack", "TN002", 4000)]
        public void TestAddingNewVehicle(string model, string make, int year, string color, string regNumber, decimal rate)
        {
            Vehicle vehicle = new Vehicle
            {
                Model = model,
                Make = make,
                VehicleYear = year,
                Color = color,
                RegistrationNumber = regNumber,
                DailyRate = rate,
                VehicleAvailability = true
            };

            Assert.DoesNotThrow(() => vehicleService.AddVehicle(vehicle)); 
        } 

        // 4. Test updating vehicle details
        [TestCase(1, "City", "Honda", 2022, "Grey", "HN-2022-CITY", true, 1800)]
        public void TestUpdatingVehicleDetails(int vehicleId, string model, string make, int year, string color, string regNumber, bool available, decimal rate)
        {
            var vehicle = vehicleService.GetVehicleById(vehicleId);
            vehicle.Model = model;
            vehicle.Make = make;
            vehicle.VehicleYear = year;
            vehicle.Color = color;
            vehicle.RegistrationNumber = regNumber;
            vehicle.VehicleAvailability = available;
            vehicle.DailyRate = rate;

            Assert.DoesNotThrow(() => vehicleService.UpdateVehicle(vehicle));
        }

        // 5. Test getting a list of available vehicles
        [Test]
        public void TestGettingListOfAvailableVehicles()
        {
            List<Vehicle> available = vehicleService.GetAvailableVehicles();
            Assert.IsNotNull(available);
        }

        // 6. Test getting a list of all vehicles
        [Test]
        public void TestGettingListOfAllVehicles()
        {
            List<Vehicle> allVehicles = vehicleService.GetAvailableVehicles(); 
            Assert.IsNotNull(allVehicles);
        }
    }
}