using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseAppAdmin.Utility
{
   public class Query
    {
       public const string GetChecklistData = "[dbo].[GetChecklistData]";
       public const string GetChecklistWardMappingMasterData = "[dbo].[GetChecklistWardmappingMasterData]";
       public const string InsertUpdateCheckListData = "[dbo].[InsertUpdateChecklistData]";
       public const string GetCheckListType = "[dbo].[GetCheckListType]";
       public const string CreateUpdateCheckListDataMapping = "[dbo].[CreateUpdateCheckListDataMapping]";
       public const string GetCheckListItems = "[dbo].[GetCheckListItems]";
       public const string InsertUpdateCheckListItems = "[dbo].[CreateUpdateCheckListItem]";
       public const string InsertUpdateOptions = "[dbo].[InsertUpdateOptions]";
       public const string DeleteOptions = "[dbo].[DeleteOptions]";
       public const string DeleteCheckListItem = "[dbo].[DeleteCheckListItem]";
       public const string CreateUpdateConfigHeader = "[dbo].[CreateUpdateConfigHeader]";
       public const string DeleteConfigHeader = "[dbo].[DeleteConfigHeader]";
       public const string GetWarddetails = "[dbo].[GetWarddetails]";
       public const string GetOfflineSync = "[dbo].[GetOfflineSync]";

       
       
    }
}
