using BusinessObjects;
using EntitySpaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //AccountInfo acc = new AccountInfo();
            esConfigSettings.ConnectionInfo.Default = "SqlDevServer";
            esProviderFactory.Factory = new EntitySpaces.LoaderMT.esDataProviderFactory();

            var emp = new AccountInfo { Name = "Joe", Id = Guid.NewGuid(), Address = "address", Age = 55 };

            DeleteAccount(emp.Id.Value);

            AddAccount(emp);


            PrintAllAccount();
            DeleteAllAccounts();
        }

        static void AddAccount(AccountInfo account)
        {
            var coll = new AccountInfoCollection();
            AccountInfo emp = coll.AddNew();
            emp.Name = account.Name;
            emp.Id = account.Id;
            emp.Address = account.Address;
            emp.Age = account.Age;

            coll.Save();
        }

        static void DeleteAccount(Guid id)
        {
            var accountColl = new AccountInfoCollection();
            accountColl.LoadAll();
            AccountInfo emp = accountColl.FindByPrimaryKey(id);
            if (emp != null)
            {
                emp.MarkAsDeleted();
                accountColl.Save();
            }
        }

        static void DeleteAllAccounts()
        {
            var coll = new AccountInfoCollection();
            coll.LoadAll();
            coll.MarkAllAsDeleted();
            coll.Save();
        }

        static void PrintAllAccount()
        {
            var acc = new AccountInfoCollection();

            if (acc.LoadAll())
            {
                foreach (AccountInfo empp in acc)
                {
                    Console.WriteLine(empp.Address);
                }
            }
        }
    }
}
