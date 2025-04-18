﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarConnect.entity;

namespace CarConnect.dao
{
    public interface IVehicleService
    {
        Vehicle GetVehicleById(int vehicleId);
        List<Vehicle> GetAvailableVehicles();
        void AddVehicle(Vehicle vehicleData);
        void UpdateVehicle(Vehicle vehicleData);
        void RemoveVehicle(int vehicleId);
    }
}
