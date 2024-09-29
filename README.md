# ATM System Project

A modular ATM console application built with **C#** that simulates basic banking operations such as authentication, balance inquiry, debit, and credit transactions. The project emphasizes **modularity**, **maintainability**, and **testability** by dividing functionalities into separate projects and employing **Behavior-Driven Development (BDD)** with **SpecFlow**, **NUnit**, and **Moq** for comprehensive testing.

## Table of Contents

1. [Project Structure](#project-structure)
2. [Installation](#installation)
3. [Usage](#usage)
4. [Features](#features)
5. [Testing](#testing)
6. [Technologies Used](#technologies-used)
7. [Future Enhancements](#future-enhancements)
8. [Author](#author)
9. [License](#license)

---

## Project Structure

The project is organized into multiple smaller projects to ensure clear separation of concerns and facilitate easier testing and maintenance.

ATMSystem/ 
<br/> │ ├── ATM.CredentialCheck/ 
<br/>│ ├── Interfaces/ 
<br/>│ │ └── ICredentialService.cs 
<br/>│ ├── Services/
<br/>│ │ └── CredentialService.cs
<br/>│ └── ATM.CredentialCheck.csproj
<br/>│ ├── ATM.CheckBalance/
<br/>│ ├── Interfaces/
<br/>│ │ └── IBalanceService.cs
<br/>│ ├── Services/
<br/>│ │ └── BalanceService.cs 
<br/>│ └── ATM.CheckBalance.csproj
<br/>│ ├── ATM.DebitAmount/
<br/>│ ├── Interfaces/
<br/>│ │ └── IDebitService.cs
<br/>│ ├── Services/
<br/>│ │ └── DebitService.cs
<br/>│ └── ATM.DebitAmount.csproj
<br/>│ ├── ATM.CreditAmount/
<br/>│ ├── Interfaces/
<br/>│ │ └── ICreditService.cs
<br/>│ ├── Services/
<br/>│ │ └── CreditService.cs
<br/>│ └── ATM.CreditAmount.csproj
<br/>│ ├── ATM.Models/
<br/>│ ├── Account.cs
<br/>│ └── ATM.Models.csproj
<br/>│ ├── ATM.ConsoleApp/
<br/>│ ├── Program.cs
<br/>│ └── ATM.ConsoleApp.csproj
<br/>│ ├── ATM.Tests.CredentialCheck/
<br/>│ ├── Features/
<br/>│ │ └── CredentialCheck.feature
<br/>│ ├── Steps/
<br/>│ │ └── CredentialCheckSteps.cs
<br/>│ ├── ATM.Tests.CredentialCheck.csproj
<br/>│ └── specflow.json
<br/>│ ├── ATM.Tests.CheckBalance/
<br/>│ ├── Features/
<br/>│ │ └── CheckBalance.feature
<br/>│ ├── Steps/
<br/>│ │ └── CheckBalanceSteps.cs
<br/>│ ├── ATM.Tests.CheckBalance.csproj
<br/>│ └── specflow.json
<br/>│ ├── ATM.Tests.DebitAmount/
<br/>│ ├── Features/
<br/>│ │ └── DebitAmount.feature
<br/>│ ├── Steps/
<br/>│ │ └── DebitAmountSteps.cs
<br/>│ ├── ATM.Tests.DebitAmount.csproj
<br/>│ └── specflow.json
<br/>│ ├── ATM.Tests.CreditAmount/
<br/>│ ├── Features/
<br/>│ │ └── CreditAmount.feature
<br/>│ ├── Steps/
<br/>│ │ └── CreditAmountSteps.cs
<br/>│ ├── ATM.Tests.CreditAmount.csproj
<br/>│ └── specflow.json
<br/>│ ├── ATM.Tests.Integration/
<br/>│ ├── Features/
<br/>│ │ └── ATMIntegration.feature
<br/>│ ├── Steps/
<br/>│ │ └── ATMIntegrationSteps.cs
<br/>│ ├── ATM.Tests.Integration.csproj
<br/>│ └── specflow.json
<br/>│ ├── ATMSystem.sln
<br/>│ └── README.md


### Description of Each Project

- **ATM.CredentialCheck**: Handles card and PIN authentication.
- **ATM.CheckBalance**: Manages balance inquiries.
- **ATM.DebitAmount**: Processes debit (withdrawal) transactions.
- **ATM.CreditAmount**: Processes credit (deposit) transactions.
- **ATM.Models**: Contains shared models such as the `Account` class.
- **ATM.ConsoleApp**: The main console application that integrates all functionalities.
- **ATM.Tests.\***: Contains SpecFlow feature files and step definitions for each corresponding core project.
- **ATMSystem.sln**: The Visual Studio solution file encompassing all projects.

---

## Installation

### Prerequisites

Ensure you have the following installed on your machine:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or later with the **.NET desktop development** workload.
- [Git](https://git-scm.com/downloads) (optional, for cloning the repository).

### Steps

1. **Clone the Repository**

   ```bash
   git clone https://github.com/conceptsandbeyond/gherkin.git
   cd gherkin
   ```
2. **Open the Solution**

   ``
   Open ATMSystem.sln in Visual Studio.
   ``

3. **Restore NuGet Packages**
   - In Visual Studio, right-click on the solution in Solution Explorer and select Restore NuGet Packages.

   - Alternatively, use the command line:

   ``` bash
   dotnet restore
   ```

4. **Build the Solution**
   - In Visual Studio, select **Build > Rebuild Solution**
   - Or via command line::

      ``` bash
      dotnet build
      ```
## Usage
### Running the Console Application

1. Set as Startup Project
   - In Solution Explorer, right-click on **ATM.ConsoleApp** and select Set as Startup Project.
2. Run the Application
   - Press F5 or select **Debug > Start Debugging**. 
   - Alternatively, run via command line: ``dotnet run --project ATM.ConsoleApp``
3. Interact with the ATM
   - **Authentication**: Enter your card number and PIN when prompted.
     - **Valid Card Number**: `1234567890123456`
     - **Valid PIN**: `1234`
   - **Options**:
       1. **Check Balance**: View your current account balance.
       2. **Debit Amount**: Withdraw funds from your account.
       3. **Credit Amount**: Deposit funds into your account.
       4. **Exit**: Terminate the application.
          

#### Example Interaction

Welcome to the ATM
Enter card number: 1234567890123456
Enter PIN: ****
Login successful!

Select an option:
1. Check Balance
2. Debit Amount
3. Credit Amount
4. Exit
   Choice: 1
   Your balance is: $1,000.00

Select an option:
1. Check Balance
2. Debit Amount
3. Credit Amount
4. Exit
   Choice: 2
   Enter amount to debit: 200
   Amount debited successfully.
   New balance: $800.00

Select an option:
1. Check Balance
2. Debit Amount
3. Credit Amount
4. Exit
   Choice: 4
   Thank you for using the ATM. Goodbye!
   
 
## Testing

   The project incorporates **Behavior-Driven Development (BDD)** using SpecFlow alongside NUnit.

### Running Tests

1. #### Via Visual Studio
   - Open **Test Explorer** (`Test > Test Explorer`).
   - Click **Run All** to execute all tests.
   
2. #### Via Command
    ``dotnet test``

## Test Projects Overview
- #### ATM.Tests.CredentialCheck
  - **CredentialCheck.feature**: Scenarios for card and PIN validation.
  - **CredentialCheckSteps.cs**: Step definitions utilizing NUnit assertions.

- #### ATM.Tests.CheckBalance

  - **CheckBalance.feature**: Scenarios for balance inquiries.
  - **CheckBalanceSteps.cs**: Step definitions.
  
- #### ATM.Tests.DebitAmount
 
  - **DebitAmount.feature**: Scenarios for debit transactions.
  - **DebitAmountSteps.cs**: Step definitions.

 - #### ATM.Tests.CreditAmount

   - **CreditAmount.feature**: Scenarios for credit transactions.
   - **CreditAmountSteps.cs**: Step definitions.

 - #### ATM.Tests.Integration

   - **ATMIntegration.feature**: End-to-end scenarios combining multiple functionalities.
   - **ATMIntegrationSteps.cs**: Step definitions.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any enhancements or bug fixes.

## License

[MIT](LICENSE)
