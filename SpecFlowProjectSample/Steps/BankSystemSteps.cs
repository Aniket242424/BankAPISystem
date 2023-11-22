using NUnit.Framework;
using SpecflowAssesment.Models;
using SpecflowAssesment.Utilities;
using System.Net;
using TechTalk.SpecFlow;

[Binding]
public class BankSystemSteps
{
    private readonly APIHelper apiHelper;
    private AccountModel account;
    private ApiResponseModel response;

    public BankSystemSteps()
    {
        apiHelper = new APIHelper();
        account = new AccountModel();
    }

    [Given(@"Account Initial Balance is (\d+)")]
    public void GivenAccountInitialBalanceIs(int initialBalance)
    {
        account.InitialBalance = initialBalance;
        account.NewBalance = initialBalance;
    }

    [Given(@"Account name is ""(.*)""")]
    public void GivenAccountNameIs(string accountName)
    {
        account.AccountName = accountName;
    }

    [Given(@"Address is ""(.*)""")]
    public void GivenAddressIs(string address)
    {
        account.Address = address;
    }

    [Given(@"Account is ""([^""]*)""")]
    public void GivenAccountIs(string accountNumber)
    {
        account.AccountNumber = accountNumber;
    }


    [When(@"POST endpoint triggered to create new account with above details")]
    public void WhenPOSTEndpointTriggeredToCreateNewAccountWithAboveDetails()
    {
        response = apiHelper.PostCreateAccount(account);
    }

    [When(@"GET endpoint triggered to get the account with AccountNumber ""([^""]*)""")]
    public void WhenGETEndpointTriggeredToGetTheAccountWithAccountNumber(string accountNumber)
    {
        response = apiHelper.GetAccount(accountNumber);
    }

  
    [When(@"PUT endpoint triggered to deposit to AccountNumber ""([^""]*)"" with Amount to deposit is \$(.*)")]
    public void WhenPUTEndpointTriggeredToDepositToAccountNumberWithAmountToDepositIs(string accountNumber, int balance)
    {
        response = apiHelper.UpdateAccountBalance(account,balance);
    }



    [When(@"DELETE endpoint triggered to delete the account with AccountNumber ""([^""]*)""")]
    public void WhenDELETEEndpointTriggeredToDeleteTheAccountWithAccountNumber(string accountNumberToDelete)
    {
        response = apiHelper.DeleteAccount(account);
    }

    [Then(@"Verify the response code is (\d+)")]
    public void ThenVerifyTheResponseCodeIs(int expectedStatusCode)
    {
        Assert.AreEqual(expectedStatusCode, response.StatusCode);
    }

    [Then(@"Verify no error is returned")]
    public void ThenVerifyNoErrorIsReturned()
    {
        Assert.IsEmpty(response.Errors);
    }

    [Then(@"Verify the success message ""(.*)""")]
    public void ThenVerifyTheSuccessMessage(string expectedMessage)
    {
        Assert.AreEqual(expectedMessage, response.Message);
    }

    [Then(@"Veriy the updated balance is (.*)")]
    public void ThenVeriyTheUpdatedBalanceIs(int updatedBalance)
    {
        Assert.AreEqual(updatedBalance, response.Data.NewBalance);
    }

    [Then(@"Verify the account details are correctly returned in the JSON response")]
    public void ThenVerifyTheAccountDetailsAreCorrectlyReturnedInTheJSONResponse()
    {
        Assert.IsNotNull(response.Data);
        Assert.AreEqual(account.AccountName, response.Data.AccountName);
        Assert.AreEqual(account.InitialBalance, response.Data.NewBalance);
    }

    [When(@"Amount to deposit is \$(.*)")]
    public void WhenAmountToDepositIs(int p0)
    {
        throw new PendingStepException();
    }

    [When(@"GET endpoint triggered to get the account with AccountNumber ""([^""]*)""X(.*)""([^""]*)""")]
    public void WhenGETEndpointTriggeredToGetTheAccountWithAccountNumberX(string p0, int p1, string p2)
    {
        throw new PendingStepException();
    }


}
