# Clean Villa Booking Project

This is my simple excercise to learn Clean Architecture & Domain-Driven Desgin

## 🚀 Quick start

1.  **Step 1.**
    Clone the project
    ```sh
    git clone https://github.com/HiImLawtSimp1e/CleanVillaBookingProject.git
    ```
1.  **Step 2.**
    Change ConnectionStrings in `WhiteLagoon.UI`
    ```sh
     "ConnectionStrings": {
    "DefaultConnection": "server=<Your Data Source>;database=<Your Database Name>;trusted_connection=true"
    },
    ```
 1. **Step 3.**
    Add migration in `WhiteLagoon.Infrastructure`
    ```
    add-migration InitialDb
    ```
    import database
    ```
    update-database
    ```
1.  **Step 4.**
    Run project
