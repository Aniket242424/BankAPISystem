# SpecFlowProjectSample

Bank System API Testing
This project focuses on testing the Bank System API using SpecFlow and NUnit. The scenarios cover account creation, deletion, depositing, getting, and withdrawing.


## Project Structure :-

### BankSystemSteps Class:
1. Implements step definitions for the scenarios using SpecFlow.
2. Interacts with the APIHelper class to perform API operations.

### APIHelper Class : 
1. Manages API-related operations.
2. Handles account creation, deletion, deposit, and retrieval.

### Utilizes an in-memory repository for account data : 
1. InMemoryAccountRepository Class
2. Stores account data in-memory.
3. Implements methods for adding, deleting, updating, and retrieving accounts.


#### Running the Tests :

1. Open the project in Visual Studio.
2. Ensure that NUnit Test Adapter is installed.
3. Run the tests using the test explorer in Visual Studio.

Feel free to modify the scenarios, steps, and classes based on your specific requirements.
