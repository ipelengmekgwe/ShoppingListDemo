This code includes a dependency on Duende IdentityServer.
This is an open source product with a reciprocal license agreement. If you plan to use Duende IdentityServer in production this may require a license fee.
To see how to use Azure Active Directory for your identity please see https://aka.ms/aspnetidentityserver
To see if you require a commercial license for Duende IdentityServer please see https://aka.ms/identityserverlicense

==========================================================================================================================================================
Shopping List Demo
------------------

1. Before running this demo application you need to add the Google authentication ClientID and ClientSecret to the appsettings.json file in the server project
	- Here is a useful link to set it up: https://learn.microsoft.com/en-us/aspnet/core/security/authentication/social/google-logins?view=aspnetcore-6.0
2. Run the migrations to update your tables
	- In the Package Manager Console run the command "Update-Database" under the ShoppingListDemo.Server project
3. DONE!!

NOTE: to visit the swagger page go to: https://localhost:{port}/swagger/index.html
