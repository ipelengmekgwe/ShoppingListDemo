#nullable disable

using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShoppingListDemo.Server.Models;

namespace ShoppingListDemo.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<ShoppingItem> ShoppingItems { get; set; }
        public DbSet<ItemImage> ItemImages { get; set; }
    }
}