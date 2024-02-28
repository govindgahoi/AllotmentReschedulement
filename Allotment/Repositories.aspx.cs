using System;
using System.Web.UI.WebControls;
//using GleamTech.Examples;
using GleamTech.FileUltimate;

namespace Allotment
{
    public partial class Repositories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fileManager.Width = Unit.Percentage(100); // or new Unit(100, UnitType.Percentage)
            fileManager.Height = 600; //Default unit is pixels.
            fileManager.DisplayLanguage = "en";

            //Create a root folder and add it to the control
            var rootFolder1 = new FileManagerRootFolder();
            rootFolder1.Name = "Repositories";


            rootFolder1.Location = "~/App_Data/RootFolder1";

            fileManager.RootFolders.Add(rootFolder1);
            var accessControl1 = new FileManagerAccessControl();
            accessControl1.Path = @"\";
            accessControl1.AllowedPermissions = FileManagerPermissions.Full;
            rootFolder1.AccessControls.Add(accessControl1);



        }
    }
}