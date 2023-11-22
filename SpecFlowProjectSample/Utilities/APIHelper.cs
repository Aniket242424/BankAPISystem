using SpecflowAssesment.Models;


namespace SpecflowAssesment.Utilities
{
    public class APIHelper
    {
        private readonly InMemoryAccountRepository accountRepository;

        public APIHelper()
        {
            accountRepository = new InMemoryAccountRepository();
        }

        public ApiResponseModel PostCreateAccount(AccountModel account)
        {
            // Validate the input account
            if (account == null)
            {
                return new ApiResponseModel
                {
                    StatusCode = 400, // Bad Request
                    Message = "Invalid account data",
                    Errors = new List<string> { "Invalid account data" }
                };
            }

            accountRepository.AddAccount(account);

            // Create a response with the necessary information
            var response = new ApiResponseModel
            {
                Data = new AccountModel
                {
                    NewBalance = account.InitialBalance,
                    AccountName = account.AccountName,
                    AccountNumber = account.AccountNumber
                },
                Message = "Account created successfully",
                StatusCode = 200,
                Errors = new List<string>()
            };

            return response;
        }


        public ApiResponseModel DeleteAccount(AccountModel account)
        {
            // Validate the input account
            if (account == null || string.IsNullOrEmpty(account.AccountNumber))
            {
                return new ApiResponseModel
                {
                    StatusCode = 400, // Bad Request
                    Message = "Invalid account data",
                    Errors = new List<string> { "Invalid account data" }
                };
            }

            // Perform the delete operation
            accountRepository.DeleteAccount(account);

            // Create a response with the necessary information
            var response = new ApiResponseModel
            {
                Data = null, // Since it's a delete operation, there may not be specific data to return
                Message = $"Account {account.AccountNumber} deleted successfully",
                StatusCode = 200,
                Errors = new List<string>()
            };

            return response;
        }


        public ApiResponseModel UpdateAccountBalance(AccountModel updatedAccount,int balanceToAdd)
        {
            // Validate the input account
            if (updatedAccount == null || string.IsNullOrEmpty(updatedAccount.AccountNumber))
            {
                return new ApiResponseModel
                {
                    StatusCode = 400, // Bad Request
                    Message = "Invalid account data",
                    Errors = new List<string> { "Invalid account data" }
                };
            }

            // Perform the update operation
            updatedAccount.NewBalance = updatedAccount.InitialBalance+ balanceToAdd;
            accountRepository.UpdateAccount(updatedAccount);

            // Create a response with the necessary information
            var response = new ApiResponseModel
            {
                Data = updatedAccount,
                Message = $"{balanceToAdd}$ deposited to Account {updatedAccount.AccountNumber} successfully".Trim(),
                StatusCode = 200,
                Errors = new List<string>()
            };

            return response;
        }


        public ApiResponseModel GetAccount(string accountNumber)
        {
            // Validate the input account number
            if (string.IsNullOrEmpty(accountNumber))
            {
                return new ApiResponseModel
                {
                    StatusCode = 400, // Bad Request
                    Message = "Invalid account number",
                    Errors = new List<string> { "Invalid account number" }
                };
            }

            // Retrieve the account details
            if (accountRepository.TryGetAccount(accountNumber, out var accountDetails))
            {
                // Create a response with the necessary information
                var response = new ApiResponseModel
                {
                    Data = accountDetails,
                    Message = $"Account {accountNumber} details retrieved successfully",
                    StatusCode = 200,
                    Errors = new List<string>()
                };

                return response;
            }
            else
            {
                return new ApiResponseModel
                {
                    StatusCode = 404, // Not Found
                    Message = $"Account {accountNumber} not found",
                    Errors = new List<string> { $"Account {accountNumber} not found" }
                };
            }

        }
    }

}
