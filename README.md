# Day-20 Challenge-2: Adding Entity Framework to DA Layer of Day-8's Challenge

- **Author:** Sakthi (Sandy) Santhosh
- **Created on:** 09/05/2024

## Note

To see the differences made to the data access layer, you can view the diff in the latest commit.

## Description

This .NET solution is a part of 3-tier architecture-based application. The goal of the application is to manage employees. This .NET solution implements the 2nd and 3rd layer of the architecture, that is the business logic layer and the data access layer. The DAL (layer-3) provides an interface to the second layer (business logic layer) that the layer can use. This decouples low-level code from high-level code, adhering to dependency inversion, which is one of the principles in the SOLID principles.

## Why Layered Application?

I mean, if you have a look at the code, we see that the business logic layer implements some methods same as the methods implemented in data access layer. But it also isolates the implementation of accessing this data hence decoupling the data access logic from the business of logic. Separation of concern is used here which makes our lifes way easier. All we gotta do is to instantiate the `EmployeeService` with the interface (contract) of data access layer. Since we're passing this contract to the business logic layer, we can be assured that the set of methods are implemented. This also provides one more advantage. Say we change the data layer from a database to a in-memory data store. In that case, the business logic layer has nothing to worry about because it is the responsibility of the data access layer to re-implement the interface.

## Build

Open a shell instance on your machine, navigate to the project folder and run the following command:

```bash
dotnet build --project ./EmployeeLibrary/EmployeeLibrary.csproj
```

This will output the assembly as DLL to `./EmployeeLibrary/bin/` folder.

## Information

### System

- **Operating System:** Debian Headless 12.0
- **Kernel:** `6.1.0-rpi4-rpi-v8`
- **Architecture:** `aarch64` (`arm64`)

### .NET Framework

- **SDK:** 8.0.204
- **Runtimes Installed:**
    - **ASP.NET:** 8.0.4
    - **.NET Core:** 8.0.4

## Contribution

This project was created for learning and development purposes only. Any contributions to the repository is discouraged.
