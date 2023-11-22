    Feature: Bank System API Testing

    Scenario Outline: Create, delete, deposit, get, and withdraw from Account
        Given Account Initial Balance is <InitialBalance>
        And Account name is "<AccountName>"
        And Address is "<Address>"
        And Account is <AccountNumberToDeposit>
        When POST endpoint triggered to create new account with above details
        Then Verify the response code is <ResponseCode>
        And Verify no error is returned
        And Verify the success message <SuccessMessage>
        And Verify the account details are correctly returned in the JSON response

        When GET endpoint triggered to get the account with AccountNumber <AccountNumberToGet>
        Then Verify the response code is <GetResponseCode>
        And Verify no error is returned
        And Verify the success message <GetSuccessMessage>
        And Verify the account details are correctly returned in the JSON response

        When PUT endpoint triggered to deposit to AccountNumber <AccountNumberToDeposit> with Amount to deposit is $<DepositAmount>
        Then Verify the response code is <DepositResponseCode>
        And Verify no error is returned
        And Verify the success message <DepositSuccessMessage> 
        And Veriy the updated balance is <UpdatedBalance>

        When DELETE endpoint triggered to delete the account with AccountNumber <AccountNumberToDelete>
        Then Verify the response code is <DeleteResponseCode>
        And Verify no error is returned
        And Verify the success message <DeleteSuccessMessage>
    
        Examples:
        | InitialBalance | AccountName     | Address              | ResponseCode | SuccessMessage                 | AccountNumberToDelete | DeleteResponseCode | DeleteSuccessMessage                | AccountNumberToDeposit | DepositAmount | DepositResponseCode | DepositSuccessMessage                         | AccountNumberToGet | GetResponseCode | GetSuccessMessage                             | UpdatedBalance  |
        | 1000           | "Rajesh Mittal" | "Ahmedabad, Gujarat" | 200          | "Account created successfully" | "X123"                | 200                | "Account X123 deleted successfully" | "X123"                 | 500           | 200                 | "500$ deposited to Account X123 successfully" | "X123"             | 200             | "Account X123 details retrieved successfully" | 1500            |
        | 500            | "John Doe"      | "New York, USA"      | 200          | "Account created successfully" | "Y456"                | 200                | "Account Y456 deleted successfully" | "Y456"                 | 200           | 200                 | "200$ deposited to Account Y456 successfully" | "Y456"             | 200             | "Account Y456 details retrieved successfully" | 700             |

