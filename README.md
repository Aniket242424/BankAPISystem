# SpecFlowProjectSample

Bank System API Testing
This project aims to test the Bank System API using SpecFlow and NUnit. The scenarios focus on creating, deleting, depositing, getting, and withdrawing from an account.

Scenario Outline
Create, Delete, Deposit, Get, and Withdraw from Account
Given Account Initial Balance is <InitialBalance>

Set the initial balance for the account.
And Account name is "<AccountName>"

Set the account name.
And Address is "<Address>"

Set the address for the account.
And Account is <AccountNumberToDeposit>

Set the account number.
When POST endpoint triggered to create a new account with the above details

Trigger the creation of a new account.
Then Verify the response code is <ResponseCode>

Check if the response code matches the expected code.
And Verify no error is returned

Ensure that no errors are present in the response.
And Verify the success message "<SuccessMessage>"

Check if the success message matches the expected message.
And Verify the account details are correctly returned in the JSON response

Check if the account details match the provided information.
When GET endpoint triggered to get the account with AccountNumber <AccountNumberToGet>

Trigger the retrieval of the account details.
Then Verify the response code is <GetResponseCode>

Check if the response code matches the expected code.
And Verify no error is returned

Ensure that no errors are present in the response.
And Verify the success message "<GetSuccessMessage>"

Check if the success message matches the expected message.
And Verify the account details are correctly returned in the JSON response

Check if the account details match the provided information.
When PUT endpoint triggered to deposit to AccountNumber <AccountNumberToDeposit> with Amount to deposit is $<DepositAmount>

Trigger the deposit operation.
Then Verify the response code is <DepositResponseCode>

Check if the response code matches the expected code.
And Verify no error is returned

Ensure that no errors are present in the response.
And Verify the success message "<DepositSuccessMessage>"

Check if the success message matches the expected message.
And Verify the updated balance is <UpdatedBalance>

Check if the updated balance matches the expected balance.
When DELETE endpoint triggered to delete the account with AccountNumber <AccountNumberToDelete>

Trigger the deletion of the account.
Then Verify the response code is <DeleteResponseCode>

Check if the response code matches the expected code.
And Verify no error is returned

Ensure that no errors are present in the response.
And Verify the success message "<DeleteSuccessMessage>"

Check if the success message matches the expected message.
Examples

Check Feature file for Example Section

Project Structure :-

BankSystemSteps Class:
Implements step definitions for the scenarios using SpecFlow.
Interacts with the APIHelper class to perform API operations.

APIHelper Class : 
Manages API-related operations.
Handles account creation, deletion, deposit, and retrieval.

Utilizes an in-memory repository for account data : 
InMemoryAccountRepository Class
Stores account data in-memory.
Implements methods for adding, deleting, updating, and retrieving accounts.


Running the Tests :

Open the project in Visual Studio.

Ensure that NUnit Test Adapter is installed.

Run the tests using the test explorer in Visual Studio.

Feel free to modify the scenarios, steps, and classes based on your specific requirements.
