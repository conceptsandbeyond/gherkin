# IntegrationTests

This project contains integration tests for the application using SpecFlow and xUnit.

## Project Structure

- **Features/**: Contains Gherkin feature files.
- **StepDefinitions/**: Contains C# classes implementing step definitions.
- **Hooks/**: Contains setup and teardown logic.
- **Helpers/**: Contains utility and helper classes.
- **Pages/**: (Optional) Contains page object classes for UI tests.
- **Drivers/**: (Optional) Contains WebDriver setup classes for UI tests.
- **Config/**: Contains configuration files.
- **TestData/**: Contains test data files.
- **Properties/**: Contains project properties and metadata.

## Getting Started

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/your-repo/IntegrationTests.git
   ```

2. **Navigate to the Project Directory:**
   ```bash
   cd IntegrationTests
   ```

3. **Restore NuGet Packages:**
   ```bash
   dotnet restore
   ```

4. **Build the Project:**
   ```bash
   dotnet build
   ```

5. **Run the Tests:**
   ```bash
   dotnet test
   ```

## Writing Tests

- **Feature Files:** Define your test scenarios in Gherkin syntax within the `Features/` directory.
- **Step Definitions:** Implement the steps in C# within the `StepDefinitions/` directory.
- **Hooks:** Use the `Hooks/` directory to manage setup and teardown logic.

## Configuration

Update the `Config/appsettings.json` file with necessary configurations such as API endpoints, database connection strings, and other settings.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any enhancements or bug fixes.

## License

[MIT](LICENSE)
