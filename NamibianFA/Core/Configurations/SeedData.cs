using CenoredIMS.Domain.Abstract;
using CenoredIMS.Domain.Entities;
using CenoredIMS.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CenoredIMS.Core.Configurations
{
    public static class SeedData
    {
        public static List<DefaultUser> DefaultUserSeed()
        {
            return new List<DefaultUser>
            {
                new DefaultUser("Master","",UserRoleEnum.Master,"master@email.com","iammaster"),
                new DefaultUser("Admin","",UserRoleEnum.Administrator,"admin@email.com","iamadmin"),
                new DefaultUser("Manager","",UserRoleEnum.Manager,"manager@email.com","iammanager")
            };
        }

        //employee seed
        public static List<Employee> EmployeeSeed()
        {
            return new List<Employee>
            {
                new Employee(230,"Fortia","Kasete",EmployeeTitleEnum.Mrs,
                                DepartmentEnum.Operations,"Artisan"),
                new Employee(237,"Lucia","Shiimbi",EmployeeTitleEnum.Miss
                                ,DepartmentEnum.Finance,"Accountant"),
                new Employee(131,"Gerson","Uwiteb",EmployeeTitleEnum.Mr,
                                DepartmentEnum.Operations,"Artisan"),
                new Employee(134,"Elias","Frans",EmployeeTitleEnum.Mr,
                                DepartmentEnum.Operations,"General Worker"),
                new Employee(136,"Ephraem V","Mhata",EmployeeTitleEnum.Mr,
                                DepartmentEnum.Operations,"General Worker"),
                new Employee(138,"Eliaser","Amutenya",EmployeeTitleEnum.Mr
                                ,DepartmentEnum.Operations,"General Worker"),
                new Employee(139,"Titus","Howaeb",EmployeeTitleEnum.Mr,
                                DepartmentEnum.Operations,"Utility Man"),
                new Employee(140,"Tobias","Nakanyala",EmployeeTitleEnum.Mr,
                                DepartmentEnum.Operations,""),
                new Employee(144,"Immanuel","Nghilongwa",EmployeeTitleEnum.Mr,
                                DepartmentEnum.Operations,"District Supervisor"),
                new Employee(147,"Oscar","Shaanika",EmployeeTitleEnum.Mr,
                                DepartmentEnum.Operations,"Utility Man")
            };
        }
        //inventory seed
        public static List<Item> InventorySeed()
        {
            return new List<Item>
            {
                new Item("Unifi Ubiquiti AP LR",ItemTypeEnum.WifiDevice,"UAP-LR","UAP-LR",LocationEnum.HeadOffice),
                new Item("CTE",ItemTypeEnum.WifiDevice,"CTE2-S","1110805927",LocationEnum.HeadOffice),
                new Item("AEC",ItemTypeEnum.WifiDevice,"ST1100-700VA","B311KA0F4101",LocationEnum.HeadOffice),
                new Item("Unifi AP",ItemTypeEnum.WifiDevice,"UAP-LR","LV-1201667",LocationEnum.HeadOffice),
                new Item("LAN Buffer",ItemTypeEnum.WifiDevice,"SS-75","SS-75",LocationEnum.HeadOffice),
                new Item("TP LINK AC",ItemTypeEnum.WifiDevice,"TL-WA901ND","212160007839",LocationEnum.HeadOffice),
                new Item("UBIQUITI",ItemTypeEnum.WifiDevice,"UNIFI","CE-400696",LocationEnum.HeadOffice),
                new Item("UBIQUITI",ItemTypeEnum.WifiDevice,"UNIFI","LV1201665",LocationEnum.HeadOffice),
                new Item("UBIQUITI",ItemTypeEnum.WifiDevice,"VAP-LR","1620K802AA87A5815",LocationEnum.HeadOffice),
                new Item("TP LINK",ItemTypeEnum.WifiDevice,"TL-WA901ND","2154049000502",LocationEnum.HeadOffice),

            };
        }
    }
}
